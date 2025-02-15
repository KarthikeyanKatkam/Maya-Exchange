using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Models;
using Maya.Exchange.Data;
using Maya.Exchange.Common;

namespace Maya.Exchange.Services
{
    public interface ISupportService
    {
        Task<SupportTicket> CreateTicket(TicketRequest request);
        Task<SupportTicket> UpdateTicket(string ticketId, TicketUpdateRequest request);
        Task<List<SupportTicket>> GetUserTickets(string userId);
        Task<SupportTicket> GetTicketById(string ticketId);
        Task<List<SupportTicket>> GetAllTickets(TicketFilter filter);
        Task AddTicketComment(string ticketId, TicketComment comment);
    }

    public class SupportService : ISupportService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SupportService> _logger;
        private readonly IDbContext _dbContext;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public SupportService(
            IConfiguration config,
            ILogger<SupportService> logger,
            IDbContext dbContext,
            IUserService userService,
            IEmailService emailService)
        {
            _config = config;
            _logger = logger;
            _dbContext = dbContext;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<SupportTicket> CreateTicket(TicketRequest request)
        {
            var user = await _userService.GetUserById(request.UserId);
            if (user == null)
                throw new NotFoundException("User not found");

            var ticket = new SupportTicket
            {
                Id = Guid.NewGuid().ToString(),
                UserId = request.UserId,
                Subject = request.Subject,
                Description = request.Description,
                Category = request.Category,
                Priority = request.Priority,
                Status = TicketStatus.Open,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dbContext.SupportTickets.InsertOneAsync(ticket);

            // Send confirmation email
            await _emailService.SendTicketConfirmation(user.Email, ticket);

            _logger.LogInformation($"Support ticket created: {ticket.Id}");
            return ticket;
        }

        public async Task<SupportTicket> UpdateTicket(string ticketId, TicketUpdateRequest request)
        {
            var ticket = await _dbContext.SupportTickets.FindOneAsync(t => t.Id == ticketId);
            if (ticket == null)
                throw new NotFoundException("Ticket not found");

            ticket.Status = request.Status;
            ticket.UpdatedAt = DateTime.UtcNow;
            
            if (!string.IsNullOrEmpty(request.Resolution))
                ticket.Resolution = request.Resolution;

            await _dbContext.SupportTickets.ReplaceOneAsync(t => t.Id == ticketId, ticket);
            return ticket;
        }

        public async Task<List<SupportTicket>> GetUserTickets(string userId)
        {
            return await _dbContext.SupportTickets
                .Find(t => t.UserId == userId)
                .SortByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<SupportTicket> GetTicketById(string ticketId)
        {
            var ticket = await _dbContext.SupportTickets.FindOneAsync(t => t.Id == ticketId);
            if (ticket == null)
                throw new NotFoundException("Ticket not found");
            return ticket;
        }

        public async Task<List<SupportTicket>> GetAllTickets(TicketFilter filter)
        {
            var query = _dbContext.SupportTickets.Find(_ => true);

            if (filter.Status.HasValue)
                query = query.Where(t => t.Status == filter.Status.Value);
            
            if (filter.Priority.HasValue)
                query = query.Where(t => t.Priority == filter.Priority.Value);

            if (!string.IsNullOrEmpty(filter.Category))
                query = query.Where(t => t.Category == filter.Category);

            return await query
                .SortByDescending(t => t.CreatedAt)
                .Skip(filter.Skip)
                .Limit(filter.Limit)
                .ToListAsync();
        }

        public async Task AddTicketComment(string ticketId, TicketComment comment)
        {
            var ticket = await GetTicketById(ticketId);
            
            if (ticket.Comments == null)
                ticket.Comments = new List<TicketComment>();

            comment.CreatedAt = DateTime.UtcNow;
            ticket.Comments.Add(comment);
            ticket.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SupportTickets.ReplaceOneAsync(t => t.Id == ticketId, ticket);
        }
    }
}
