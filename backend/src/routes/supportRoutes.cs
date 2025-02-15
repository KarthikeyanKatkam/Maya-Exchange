using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Models;
using MayaExchange.Services;
using MayaExchange.Middleware;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/support")]
    public class SupportRoutes : ControllerBase
    {
        private readonly ISupportService _supportService;
        private readonly IAuthenticationService _authService;

        public SupportRoutes(
            ISupportService supportService,
            IAuthenticationService authService)
        {
            _supportService = supportService;
            _authService = authService;
        }

        [HttpPost("ticket")]
        [Authorize]
        public async Task<IActionResult> CreateSupportTicket([FromBody] SupportTicket ticket)
        {
            try
            {
                var userId = User.Identity.Name;
                var createdTicket = await _supportService.CreateTicketAsync(userId, ticket);
                return CreatedAtAction(nameof(GetTicketById), new { id = createdTicket.Id }, createdTicket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("tickets")]
        [Authorize]
        public async Task<IActionResult> GetUserTickets()
        {
            try
            {
                var userId = User.Identity.Name;
                var tickets = await _supportService.GetUserTicketsAsync(userId);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ticket/{id}")]
        [Authorize]
        public async Task<IActionResult> GetTicketById(string id)
        {
            try
            {
                var userId = User.Identity.Name;
                var ticket = await _supportService.GetTicketByIdAsync(id, userId);
                if (ticket == null)
                    return NotFound();
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("ticket/{id}/reply")]
        [Authorize]
        public async Task<IActionResult> AddTicketReply(string id, [FromBody] TicketReply reply)
        {
            try
            {
                var userId = User.Identity.Name;
                var updatedTicket = await _supportService.AddTicketReplyAsync(id, userId, reply);
                if (updatedTicket == null)
                    return NotFound();
                return Ok(updatedTicket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("ticket/{id}/close")]
        [Authorize]
        public async Task<IActionResult> CloseTicket(string id)
        {
            try
            {
                var userId = User.Identity.Name;
                var result = await _supportService.CloseTicketAsync(id, userId);
                if (!result)
                    return NotFound();
                return Ok(new { Message = "Ticket closed successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
