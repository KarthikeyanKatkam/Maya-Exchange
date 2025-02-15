using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Api.Models;
using Maya.Exchange.Api.Services;
using Maya.Exchange.Api.Tests.Helpers;

namespace Maya.Exchange.Api.Tests.Integration
{
    public class UpiRoutesTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UpiRoutesTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = fixture.Client;
        }

        [Fact]
        public async Task InitiateUpiPayment_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var request = new UpiPaymentRequest
            {
                Amount = 1000.00m,
                Currency = "INR",
                VirtualPaymentAddress = "user@upi",
                Purpose = "Test Payment"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/upi/initiate", request);
            var result = await response.Content.ReadAsAsync<UpiPaymentResponse>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.TransactionId.Should().NotBeNullOrEmpty();
            result.Status.Should().Be("INITIATED");
        }

        [Fact]
        public async Task VerifyUpiPayment_ValidTransaction_ReturnsStatus()
        {
            // Arrange
            var transactionId = "TEST-UPI-TXN-001";

            // Act
            var response = await _client.GetAsync($"/api/upi/verify/{transactionId}");
            var result = await response.Content.ReadAsAsync<UpiTransactionStatus>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.TransactionId.Should().Be(transactionId);
            result.Status.Should().NotBeNull();
        }

        [Fact]
        public async Task UpiPaymentCallback_ValidCallback_ProcessesSuccessfully()
        {
            // Arrange
            var callback = new UpiCallbackData
            {
                TransactionId = "TEST-UPI-TXN-001",
                Status = "SUCCESS",
                ResponseCode = "00",
                ApprovalReference = "REF123456"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/upi/callback", callback);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetUpiTransactionHistory_ReturnsTransactionList()
        {
            // Arrange
            var userId = "TEST-USER-001";

            // Act
            var response = await _client.GetAsync($"/api/upi/transactions/{userId}");
            var result = await response.Content.ReadAsAsync<UpiTransactionHistory>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Transactions.Should().NotBeNull();
        }

        [Fact]
        public async Task ValidateUpiAddress_ValidAddress_ReturnsTrue()
        {
            // Arrange
            var upiAddress = "valid.user@upi";

            // Act
            var response = await _client.GetAsync($"/api/upi/validate/{upiAddress}");
            var result = await response.Content.ReadAsAsync<UpiAddressValidation>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.IsValid.Should().BeTrue();
        }
    }
}
