using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Maya.Exchange.Tests.Integration
{
    public class SupportRoutesTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public SupportRoutesTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = fixture.Client;
        }

        [Fact]
        public async Task CreateSupportTicket_ValidRequest_ReturnsCreated()
        {
            // Arrange
            var ticket = new SupportTicketRequest
            {
                UserId = "test-user-id",
                Subject = "Test Support Ticket",
                Description = "This is a test support ticket",
                Category = "Technical",
                Priority = "Medium"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(ticket),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/api/support/tickets", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetSupportTickets_ValidRequest_ReturnsOk()
        {
            // Act
            var response = await _client.GetAsync("/api/support/tickets");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetKycSupportStatus_ValidRequest_ReturnsOk()
        {
            // Arrange
            string userId = "test-user-id";

            // Act
            var response = await _client.GetAsync($"/api/support/kyc-status/{userId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateSupportTicket_ValidRequest_ReturnsOk()
        {
            // Arrange
            string ticketId = "test-ticket-id";
            var update = new SupportTicketUpdateRequest
            {
                Status = "In Progress",
                Resolution = "Working on the issue"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(update),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PutAsync($"/api/support/tickets/{ticketId}", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task SubmitKycSupportRequest_ValidRequest_ReturnsCreated()
        {
            // Arrange
            var kycRequest = new KycSupportRequest
            {
                UserId = "test-user-id",
                DocumentType = "Passport",
                IssueDescription = "Document verification failed",
                AdditionalInfo = "Passport number: ABC123"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(kycRequest),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/api/support/kyc-request", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
