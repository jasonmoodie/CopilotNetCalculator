namespace CopilotNetCalculator.Models
{
    public class CalculatorModel
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public double Result { get; set; }
        public string? Operation { get; set; }

        public double Add()
        {
            return Operand1 + Operand2;
        }

        public double Subtract()
        {
            return Operand1 - Operand2;
        }

        public double Multiply()
        {
            return Operand1 * Operand2;
        }

        public double Divide()
        {
            if (Operand2 == 0)
            {
                throw new DivideByZeroException("Operand2 cannot be zero.");
            }
            return Operand1 / Operand2;
        }

        // TODO: Add method here
    
    }
}