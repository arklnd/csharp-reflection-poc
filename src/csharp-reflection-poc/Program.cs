using System;

using CsharpReflectionPoc;

Console.WriteLine("=== C# Calculator with Method Chaining Demo ===\n");

// Example 1: Basic arithmetic operations
Console.WriteLine("Example 1: Basic arithmetic operations");
var calc1 = new Calculator(10)
    .Add(5)
    .Subtract(3)
    .Multiply(2)
    .Divide(4)
    .DisplayResult();

Console.WriteLine($"Result 1: {calc1.GetResult()}\n");

// Example 2: Complex calculations with chaining
Console.WriteLine("Example 2: Complex calculations");
var calc2 = new Calculator(25)
    .SquareRoot()
    .Add(10)
    .Square()
    .Subtract(100)
    .DisplayResult();

Console.WriteLine($"Result 2: {calc2.GetResult()}\n");

// Example 3: Error handling demonstration
Console.WriteLine("Example 3: Error handling");
var calc3 = new Calculator(16)
    .Divide(0)  // Division by zero error
    .Add(5)
    .SquareRoot()
    .DisplayResult();

Console.WriteLine($"Result 3: {calc3.GetResult()}\n");

// Example 4: Using clear and chaining multiple operations
Console.WriteLine("Example 4: Using clear and multiple operations");
var calc4 = new Calculator(100)
    .Add(50)
    .Clear()
    .Add(7)
    .Multiply(6)
    .Subtract(2)
    .Divide(10)
    .DisplayResult();

Console.WriteLine($"Result 4: {calc4.GetResult()}\n");

// Example 5: Negative number square root demonstration
Console.WriteLine("Example 5: Negative square root handling");
var calc5 = new Calculator(10)
    .Subtract(15)
    .SquareRoot()  // Square root of negative number error
    .Add(20)
    .DisplayResult();

Console.WriteLine($"Result 5: {calc5.GetResult()}\n");