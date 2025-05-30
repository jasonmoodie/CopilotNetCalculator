using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Xunit;

namespace CopilotNetCalculator.Tests.Integration
{
    public class CalculatorIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CalculatorIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_Calculator_Index_ReturnsSuccessAndCorrectContentType()
        {
            // Act
            var response = await _client.GetAsync("/Calculator");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Get_Calculator_Root_ReturnsSuccessAndCorrectContentType()
        {
            // Act
            var response = await _client.GetAsync("/Calculator/Index");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);        }

        [Fact]
        public async Task Post_Calculator_Calculate_WithValidData_ReturnsSuccess()
        {
            // Arrange
            var formData = new Dictionary<string, string>
            {
                {"Operand1", "10"},
                {"Operand2", "5"},
                {"Operation", "Add"}
            };
            var content = new FormUrlEncodedContent(formData);

            // Act
            var response = await _client.PostAsync("/Calculator/Calculate", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            // The response should contain the calculator interface and the result should be in the display
            Assert.Contains("calc-display", responseString);
            Assert.Contains("15", responseString); // Expected result of 10 + 5 should be displayed
        }        [Theory]
        [InlineData("10", "5", "Add", "15")]
        [InlineData("10", "3", "Subtract", "7")]
        [InlineData("4", "6", "Multiply", "24")]
        [InlineData("15", "3", "Divide", "5")]
        public async Task Post_Calculator_Calculate_VariousOperations_ReturnsExpectedResults(
            string operand1, string operand2, string operation, string expectedResult)
        {
            // Arrange
            var formData = new Dictionary<string, string>
            {
                {"Operand1", operand1},
                {"Operand2", operand2},
                {"Operation", operation}
            };
            var content = new FormUrlEncodedContent(formData);

            // Act
            var response = await _client.PostAsync("/Calculator/Calculate", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("calc-display", responseString);
            Assert.Contains(expectedResult, responseString);
        }

        [Fact]
        public async Task Get_Calculator_ReturnsCalculatorInterface()
        {
            // Act
            var response = await _client.GetAsync("/Calculator");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            // Verify the calculator interface elements are present
            Assert.Contains("calc-container", content);
            Assert.Contains("calc-display", content);
            Assert.Contains("calc-buttons", content);
            Assert.Contains("data-action=\"add\"", content);
            Assert.Contains("data-action=\"subtract\"", content);
            Assert.Contains("data-action=\"multiply\"", content);
            Assert.Contains("data-action=\"divide\"", content);
        }

        [Fact]
        public async Task Post_Calculator_Calculate_WithInvalidOperation_ReturnsSuccess()
        {
            // Arrange
            var formData = new Dictionary<string, string>
            {
                {"Operand1", "10"},
                {"Operand2", "5"},
                {"Operation", "InvalidOperation"}
            };
            var content = new FormUrlEncodedContent(formData);

            // Act
            var response = await _client.PostAsync("/Calculator/Calculate", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("calc-display", responseString);
        }
    }
}
