using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Maya.Exchange.Utils;
using Newtonsoft.Json;

namespace Maya.Exchange.Tests.Integration
{
    public class AuthRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public AuthRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Register_WithValidData_ReturnsSuccess()
        {
            // Arrange
            var registerData = new
            {
                Email = "test@example.com",
                Password = "Test123!@#",
                PhoneNumber = "+1234567890"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(registerData),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/api/auth/register", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var loginData = new
            {
                Email = "test@example.com",
                Password = "Test123!@#"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(loginData),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/api/auth/login", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result.token);
        }

        [Fact]
        public async Task Register_WithInvalidEmail_ReturnsBadRequest()
        {
            // Arrange
            var registerData = new
            {
                Email = "invalid-email",
                Password = "Test123!@#",
                PhoneNumber = "+1234567890"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(registerData),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/api/auth/register", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Register_WithInvalidPassword_ReturnsBadRequest()
        {
            // Arrange
            var registerData = new
            {
                Email = "test@example.com",
                Password = "weak",
                PhoneNumber = "+1234567890"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(registerData),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/api/auth/register", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginData = new
            {
                Email = "test@example.com",
                Password = "WrongPassword123!@#"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(loginData),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/api/auth/login", content);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
