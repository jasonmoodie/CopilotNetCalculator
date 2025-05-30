using Xunit;
using CopilotNetCalculator.Models;

namespace CopilotNetCalculator.Tests.Models
{
    public class CalculatorModelTests
    {
        // Tests the Add method with two positive numbers
        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            // Arrange
            var calculator = new CalculatorModel
            {
                Operand1 = 5,
                Operand2 = 3
            };

            // Act
            var result = calculator.Add();

            // Assert
            Assert.Equal(8, result);
        }

        // Tests the Add method with various input combinations
        [Theory]
        [InlineData(10, 5, 15)]
        [InlineData(-5, 3, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(-10, -5, -15)]
        [InlineData(2.5, 3.7, 6.2)]
        public void Add_VariousInputs_ReturnsExpectedSum(double operand1, double operand2, double expected)
        {
            // Arrange
            var calculator = new CalculatorModel
            {
                Operand1 = operand1,
                Operand2 = operand2
            };

            // Act
            var result = calculator.Add();

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        // Tests the Subtract method with two positive numbers
        [Fact]
        public void Subtract_TwoPositiveNumbers_ReturnsDifference()
        {
            // Arrange
            var calculator = new CalculatorModel
            {
                Operand1 = 10,
                Operand2 = 3
            };

            // Act
            var result = calculator.Subtract();

            // Assert
            Assert.Equal(7, result);
        }

        // Tests the Subtract method with various input combinations
        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(5, 10, -5)]
        [InlineData(0, 5, -5)]
        [InlineData(-5, -3, -2)]
        [InlineData(7.5, 2.3, 5.2)]
        public void Subtract_VariousInputs_ReturnsExpectedDifference(double operand1, double operand2, double expected)
        {
            // Arrange
            var calculator = new CalculatorModel
            {
                Operand1 = operand1,
                Operand2 = operand2
            };

            // Act
            var result = calculator.Subtract();

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        // Tests the Multiply method with two positive numbers
        [Fact]
        public void Multiply_TwoPositiveNumbers_ReturnsProduct()
        {
            // Arrange
            var calculator = new CalculatorModel
            {
                Operand1 = 4,
                Operand2 = 5
            };

            // Act
            var result = calculator.Multiply();

            // Assert
            Assert.Equal(20, result);
        }

        // Tests the Multiply method with various input combinations
        [Theory]
        [InlineData(3, 4, 12)]
        [InlineData(-2, 5, -10)]
        [InlineData(-3, -4, 12)]
        [InlineData(0, 100, 0)]
        [InlineData(2.5, 4, 10)]
        public void Multiply_VariousInputs_ReturnsExpectedProduct(double operand1, double operand2, double expected)
        {
            // Arrange
            var calculator = new CalculatorModel
            {
                Operand1 = operand1,
                Operand2 = operand2
            };

            // Act
            var result = calculator.Multiply();

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        // Add additional test here
        
    }
}
