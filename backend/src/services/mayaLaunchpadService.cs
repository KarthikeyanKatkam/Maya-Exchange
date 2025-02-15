using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Maya.Exchange.Models;
using Maya.Exchange.Interfaces;
using Maya.Exchange.Data;
using Maya.Exchange.Common;

namespace Maya.Exchange.Services
{
    public interface IMayaLaunchpadService
    {
        Task<LaunchpadProject> CreateProject(LaunchpadProjectRequest request);
        Task<List<LaunchpadProject>> GetActiveProjects();
        Task<LaunchpadProject> GetProjectById(string projectId);
        Task<ParticipationResult> ParticipateInProject(string userId, string projectId, decimal amount);
        Task<List<UserParticipation>> GetUserParticipations(string userId);
        Task<ProjectStats> GetProjectStats(string projectId);
    }

    public class MayaLaunchpadService : IMayaLaunchpadService
    {
        private readonly ILogger<MayaLaunchpadService> _logger;
        private readonly IMongoDatabase _database;
        private readonly IKycService _kycService;
        private readonly IWalletService _walletService;
        private readonly IBlockchainService _blockchainService;

        public MayaLaunchpadService(
            ILogger<MayaLaunchpadService> logger,
            IMongoDatabase database,
            IKycService kycService,
            IWalletService walletService,
            IBlockchainService blockchainService)
        {
            _logger = logger;
            _database = database;
            _kycService = kycService;
            _walletService = walletService;
            _blockchainService = blockchainService;
        }

        public async Task<LaunchpadProject> CreateProject(LaunchpadProjectRequest request)
        {
            try
            {
                var project = new LaunchpadProject
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    Description = request.Description,
                    TokenSymbol = request.TokenSymbol,
                    TokenPrice = request.TokenPrice,
                    TotalSupply = request.TotalSupply,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Status = ProjectStatus.Pending,
                    CreatedAt = DateTime.UtcNow
                };

                var collection = _database.GetCollection<LaunchpadProject>("launchpadProjects");
                await collection.InsertOneAsync(project);
                return project;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating launchpad project: {ex.Message}");
                throw new LaunchpadException("Failed to create project", ex);
            }
        }

        public async Task<List<LaunchpadProject>> GetActiveProjects()
        {
            try
            {
                var collection = _database.GetCollection<LaunchpadProject>("launchpadProjects");
                var filter = Builders<LaunchpadProject>.Filter.Where(p => 
                    p.Status == ProjectStatus.Active && 
                    p.EndDate > DateTime.UtcNow);
                return await collection.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting active projects: {ex.Message}");
                throw new LaunchpadException("Failed to retrieve active projects", ex);
            }
        }

        public async Task<ParticipationResult> ParticipateInProject(string userId, string projectId, decimal amount)
        {
            try
            {
                // Validate KYC status
                var kycStatus = await _kycService.ValidateKycStatus(userId);
                if (!kycStatus.IsValid)
                {
                    return new ParticipationResult
                    {
                        Success = false,
                        Message = "KYC validation failed"
                    };
                }

                // Get project details
                var project = await GetProjectById(projectId);
                if (project == null)
                {
                    return new ParticipationResult
                    {
                        Success = false,
                        Message = "Project not found"
                    };
                }

                // Validate participation amount
                if (amount <= 0 || amount > project.MaxParticipationAmount)
                {
                    return new ParticipationResult
                    {
                        Success = false,
                        Message = "Invalid participation amount"
                    };
                }

                // Process participation transaction
                var participation = new UserParticipation
                {
                    UserId = userId,
                    ProjectId = projectId,
                    Amount = amount,
                    TokensAllocated = amount / project.TokenPrice,
                    ParticipationDate = DateTime.UtcNow
                };

                var collection = _database.GetCollection<UserParticipation>("userParticipations");
                await collection.InsertOneAsync(participation);

                return new ParticipationResult
                {
                    Success = true,
                    ParticipationId = participation.Id,
                    TokensAllocated = participation.TokensAllocated
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing participation: {ex.Message}");
                throw new LaunchpadException("Failed to process participation", ex);
            }
        }

        public async Task<ProjectStats> GetProjectStats(string projectId)
        {
            try
            {
                var participationsCollection = _database.GetCollection<UserParticipation>("userParticipations");
                var participations = await participationsCollection
                    .Find(p => p.ProjectId == projectId)
                    .ToListAsync();

                return new ProjectStats
                {
                    ProjectId = projectId,
                    TotalParticipants = participations.Count,
                    TotalAmountRaised = participations.Sum(p => p.Amount),
                    TotalTokensAllocated = participations.Sum(p => p.TokensAllocated)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting project stats: {ex.Message}");
                throw new LaunchpadException("Failed to retrieve project stats", ex);
            }
        }

        public async Task<LaunchpadProject> GetProjectById(string projectId)
        {
            try
            {
                var collection = _database.GetCollection<LaunchpadProject>("launchpadProjects");
                return await collection.Find(p => p.Id == projectId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting project by ID: {ex.Message}");
                throw new LaunchpadException("Failed to retrieve project", ex);
            }
        }

        public async Task<List<UserParticipation>> GetUserParticipations(string userId)
        {
            try
            {
                var collection = _database.GetCollection<UserParticipation>("userParticipations");
                return await collection.Find(p => p.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting user participations: {ex.Message}");
                throw new LaunchpadException("Failed to retrieve user participations", ex);
            }
        }
    }
}
