using Microsoft.AspNetCore.Mvc;
using Xunit;
using CopilotNetCalculator.Controllers;
using CopilotNetCalculator.Models;

namespace CopilotNetCalculator.Tests.Controllers
{
    /// <summary>
    /// Unit tests for the CalculatorController.
    /// Tests controller methods directly (not through HTTP requests).
    /// </summary>
    public class CalculatorControllerTests
    {
        private readonly CalculatorController _controller;

        public CalculatorControllerTests()
        {
            _controller = new CalculatorController();
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Calculate_AddOperation_ReturnsViewWithCorrectResult()
        {
            // Arrange
            var model = new CalculatorModel
            {
                Operand1 = 10,
                Operand2 = 5,
                Operation = "Add"
            };

            // Act
            var result = _controller.Calculate(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);
            var returnedModel = Assert.IsType<CalculatorModel>(result.Model);
            Assert.Equal(15, returnedModel.Result);
        }

        [Fact]
        public void Calculate_SubtractOperation_ReturnsViewWithCorrectResult()
        {
            // Arrange
            var model = new CalculatorModel
            {
                Operand1 = 10,
                Operand2 = 3,
                Operation = "Subtract"
            };

            // Act
            var result = _controller.Calculate(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var returnedModel = Assert.IsType<CalculatorModel>(result.Model);
            Assert.Equal(7, returnedModel.Result);
        }

        [Fact]
        public void Calculate_MultiplyOperation_ReturnsViewWithCorrectResult()
        {
            // Arrange
            var model = new CalculatorModel
            {
                Operand1 = 4,
                Operand2 = 6,
                Operation = "Multiply"
            };

            // Act
            var result = _controller.Calculate(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var returnedModel = Assert.IsType<CalculatorModel>(result.Model);
            Assert.Equal(24, returnedModel.Result);
        }

        [Fact]
        public void Calculate_DivideOperation_ReturnsViewWithCorrectResult()
        {
            // Arrange
            var model = new CalculatorModel
            {
                Operand1 = 20,
                Operand2 = 4,
                Operation = "Divide"
            };

            // Act
            var result = _controller.Calculate(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var returnedModel = Assert.IsType<CalculatorModel>(result.Model);
            Assert.Equal(5, returnedModel.Result);
        }

        [Fact]
        public void Calculate_DivideByZero_ReturnsViewWithError()
        {
            // Arrange
            var model = new CalculatorModel
            {
                Operand1 = 10,
                Operand2 = 0,
                Operation = "Divide"
            };

            // Act
            var result = _controller.Calculate(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var returnedModel = Assert.IsType<CalculatorModel>(result.Model);
            Assert.Equal(0, returnedModel.Result);
        }

        [Fact]
        public void Calculate_UnknownOperation_ReturnsViewWithError()
        {
            // Arrange
            var model = new CalculatorModel
            {
                Operand1 = 1,
                Operand2 = 2,
                Operation = "Modulo"
            };

            // Act
            var result = _controller.Calculate(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var returnedModel = Assert.IsType<CalculatorModel>(result.Model);
            Assert.Equal(0, returnedModel.Result);
        }
    }
}
