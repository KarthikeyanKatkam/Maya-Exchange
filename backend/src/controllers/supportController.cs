using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportController : ControllerBase
    {
        private readonly ILogger<SupportController> _logger;
        private readonly ISupportService _supportService;
        private readonly INotificationService _notificationService;

        public SupportController(
            ILogger<SupportController> logger,
            ISupportService supportService,
            INotificationService notificationService)
        {
            _logger = logger;
            _supportService = supportService;
            _notificationService = notificationService;
        }

        [HttpPost("ticket")]
        [Authorize]
        public async Task<IActionResult> CreateSupportTicket([FromBody] SupportTicketRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var ticket = await _supportService.CreateTicket(userId, request);
                await _notificationService.SendTicketCreationNotification(userId, ticket.TicketId);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating support ticket: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("tickets")]
        [Authorize]
        public async Task<IActionResult> GetUserTickets([FromQuery] TicketQueryParams queryParams)
        {
            try
            {
                var userId = User.GetUserId();
                var tickets = await _supportService.GetUserTickets(userId, queryParams);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving support tickets: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("ticket/{ticketId}")]
        [Authorize]
        public async Task<IActionResult> GetTicketDetails(string ticketId)
        {
            try
            {
                var userId = User.GetUserId();
                var ticket = await _supportService.GetTicketDetails(userId, ticketId);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving ticket details: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("ticket/{ticketId}/reply")]
        [Authorize]
        public async Task<IActionResult> AddTicketReply(string ticketId, [FromBody] TicketReplyRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var reply = await _supportService.AddTicketReply(userId, ticketId, request);
                await _notificationService.SendTicketReplyNotification(userId, ticketId);
                return Ok(reply);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding ticket reply: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("ticket/{ticketId}/close")]
        [Authorize]
        public async Task<IActionResult> CloseTicket(string ticketId)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _supportService.CloseTicket(userId, ticketId);
                await _notificationService.SendTicketClosedNotification(userId, ticketId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error closing ticket: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("faqs")]
        public async Task<IActionResult> GetFAQs([FromQuery] FAQQueryParams queryParams)
        {
            try
            {
                var faqs = await _supportService.GetFAQs(queryParams);
                return Ok(faqs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving FAQs: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }
    }
}
