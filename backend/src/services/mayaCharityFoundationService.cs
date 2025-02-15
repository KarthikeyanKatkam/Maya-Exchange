using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Maya.Models;
using Maya.Utils;
using Maya.Config;

namespace Maya.Services
{
    public interface IMayaCharityFoundationService
    {
        Task<CharityProject> CreateProject(CharityProject project);
        Task<List<CharityProject>> GetAllProjects();
        Task<CharityProject> GetProjectById(string id);
        Task<DonationResult> ProcessDonation(string projectId, Donation donation);
        Task<List<Donation>> GetDonationHistory(string userId);
        Task<CharityImpactReport> GenerateImpactReport(string projectId);
    }

    public class MayaCharityFoundationService : IMayaCharityFoundationService
    {
        private readonly IMongoCollection<CharityProject> _projects;
        private readonly IMongoCollection<Donation> _donations;
        private readonly IConfiguration _configuration;
        private readonly IKycService _kycService;

        public MayaCharityFoundationService(
            IMongoClient mongoClient,
            IConfiguration configuration,
            IKycService kycService)
        {
            var database = mongoClient.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _projects = database.GetCollection<CharityProject>("CharityProjects");
            _donations = database.GetCollection<Donation>("Donations");
            _configuration = configuration;
            _kycService = kycService;
        }

        public async Task<CharityProject> CreateProject(CharityProject project)
        {
            project.Id = Guid.NewGuid().ToString();
            project.CreatedAt = DateTime.UtcNow;
            project.Status = ProjectStatus.Active;
            
            await _projects.InsertOneAsync(project);
            return project;
        }

        public async Task<List<CharityProject>> GetAllProjects()
        {
            return await _projects.Find(p => true).ToListAsync();
        }

        public async Task<CharityProject> GetProjectById(string id)
        {
            return await _projects.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DonationResult> ProcessDonation(string projectId, Donation donation)
        {
            // Verify KYC status
            var kycStatus = await _kycService.VerifyUserKyc(donation.UserId);
            if (!kycStatus.IsVerified)
            {
                return new DonationResult 
                { 
                    Success = false,
                    Message = "KYC verification required before making donations"
                };
            }

            var project = await GetProjectById(projectId);
            if (project == null)
            {
                return new DonationResult
                {
                    Success = false,
                    Message = "Project not found"
                };
            }

            donation.Id = Guid.NewGuid().ToString();
            donation.ProjectId = projectId;
            donation.Timestamp = DateTime.UtcNow;
            donation.Status = DonationStatus.Completed;

            await _donations.InsertOneAsync(donation);

            // Update project funding
            var update = Builders<CharityProject>.Update
                .Inc(p => p.CurrentFunding, donation.Amount);
            await _projects.UpdateOneAsync(p => p.Id == projectId, update);

            return new DonationResult
            {
                Success = true,
                Message = "Donation processed successfully",
                DonationId = donation.Id
            };
        }

        public async Task<List<Donation>> GetDonationHistory(string userId)
        {
            return await _donations.Find(d => d.UserId == userId)
                                 .SortByDescending(d => d.Timestamp)
                                 .ToListAsync();
        }

        public async Task<CharityImpactReport> GenerateImpactReport(string projectId)
        {
            var project = await GetProjectById(projectId);
            var donations = await _donations.Find(d => d.ProjectId == projectId).ToListAsync();

            return new CharityImpactReport
            {
                ProjectId = projectId,
                ProjectName = project.Name,
                TotalDonations = donations.Count,
                TotalAmount = donations.Sum(d => d.Amount),
                BeneficiariesHelped = project.BeneficiariesCount,
                GeneratedAt = DateTime.UtcNow
            };
        }
    }
}
