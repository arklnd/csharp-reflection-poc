using System;

namespace CsharpReflectionPoc
{
    public class Calculator(double initialValue = 0)
    {
        private double _value = initialValue;

        public Calculator Add(double number)
        {
            _value += number;
            Console.WriteLine($"Added {number}, current value: {_value}");
            return this;
        }

        public Calculator Subtract(double number)
        {
            _value -= number;
            Console.WriteLine($"Subtracted {number}, current value: {_value}");
            return this;
        }

        public Calculator Multiply(double number)
        {
            _value *= number;
            Console.WriteLine($"Multiplied by {number}, current value: {_value}");
            return this;
        }

        public Calculator Divide(double number)
        {
            if (number == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
                return this;
            }
            _value /= number;
            Console.WriteLine($"Divided by {number}, current value: {_value}");
            return this;
        }

        public Calculator Square()
        {
            _value = Math.Pow(_value, 2);
            Console.WriteLine($"Squared, current value: {_value}");
            return this;
        }

        public Calculator SquareRoot()
        {
            if (_value < 0)
            {
                Console.WriteLine("Error: Cannot take square root of negative number!");
                return this;
            }
            _value = Math.Sqrt(_value);
            Console.WriteLine($"Square root taken, current value: {_value}");
            return this;
        }

        public Calculator Clear()
        {
            _value = 0;
            Console.WriteLine("Calculator cleared, current value: 0");
            return this;
        }

        public double GetResult()
        {
            return _value;
        }

        public Calculator DisplayResult()
        {
            Console.WriteLine($"Final result: {_value}");
            return this;
        }
    }
}