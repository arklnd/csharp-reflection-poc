using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;
using CsharpReflectionPoc;

Console.WriteLine("=== C# Calculator with Reflection Demo ===\n");

// Execute the analysis and examples
AnalyzeAssemblyReflections();

// ASCII Art Explanation of LLM Integration Pattern
Console.WriteLine(@"
╔══════════════════════════════════════════════════════════════════════════════════════════╗
║                    🤖 LLM-POWERED DYNAMIC CODE EXECUTION PIPELINE 🤖                    ║
╠══════════════════════════════════════════════════════════════════════════════════════════╣
║                                                                                          ║
║  ┌─────────────────┐    ┌──────────────────┐    ┌─────────────────────────────────┐      ║
║  │  STEP 1: SCAN   │───▶│   STEP 2: FEED   │───▶│    STEP 3: GENERATE & EXECUTE   │      ║
║  │   REFLECTION    │    │    TO LLM        │    │      DYNAMIC CALCULATOR         │      ║
║  └─────────────────┘    └──────────────────┘    └─────────────────────────────────┘      ║
║           │                       │                              │                       ║
║           ▼                       ▼                              ▼                       ║
║                                                                                          ║
║  📋 AnalyzeAssemblyReflections()   🧠 LLM Context Analysis       ⚡ ExecuteCalculator   ║
║     discovers:                       understands:                 FromString()           ║
║                                                                                          ║
║   • Calculator class structure      • Available methods:          runs dynamically:      ║
║   • Method signatures:                - Add(Double number)                               ║
║     - Add(Double)                     - Subtract(Double)         ""Calculator(25)        ║
║     - Subtract(Double)                - Multiply(Double)           .SquareRoot()         ║
║     - Multiply(Double)                - Divide(Double)             .Add(10)              ║
║     - Divide(Double)                  - Square()                  .Square()              ║
║     - Square()                        - SquareRoot()              .Subtract(100)         ║
║     - SquareRoot()                    - Clear()                   .DisplayResult()""     ║
║     - Clear()                         - DisplayResult()                                  ║
║     - DisplayResult()                 - GetResult()               🔄 Method chaining     ║
║     - GetResult()                                                 🧮 Reflection-based    ║
║   • Constructor: Calculator(Double)   • Method chaining pattern   📊 Error handling      ║
║   • Return types & parameters         • Error conditions                                 ║
║   • Field information                 • Usage patterns                                   ║
║                                                                                          ║
║  💡 THE MAGIC: Assembly metadata becomes LLM context for intelligent code generation     ║
║                                                                                          ║
║  🔄 WORKFLOW:                                                                            ║
║     1. Reflection scans → discovers API surface                                          ║
║     2. Metadata feeds LLM → understands capabilities                                     ║
║     3. LLM generates → valid calculator expressions                                      ║
║                                                                                          ║
╚══════════════════════════════════════════════════════════════════════════════════════════╝
");

Console.WriteLine("=== String-based Calculator Examples ===\n");

// Example 1: Basic arithmetic operations  
ExecuteCalculatorFromString("Calculator(10).Add(5).Subtract(3).Multiply(2).Divide(4).DisplayResult()");

// Example 2: Complex calculations with chaining
ExecuteCalculatorFromString("Calculator(25).SquareRoot().Add(10).Square().Subtract(100).DisplayResult()");

// Example 3: Error handling demonstration
ExecuteCalculatorFromString("Calculator(16).Divide(0).Add(5).SquareRoot().DisplayResult()");

// Example 4: Using clear and multiple operations
ExecuteCalculatorFromString("Calculator(100).Add(50).Clear().Add(7).Multiply(6).Subtract(2).Divide(10).DisplayResult()");

// Example 5: Negative number square root demonstration
ExecuteCalculatorFromString("Calculator(10).Subtract(15).SquareRoot().Add(20).DisplayResult()");


// Function 1: Read assembly reflections in detail
static void AnalyzeAssemblyReflections()
{
    Console.WriteLine("=== Assembly Reflection Analysis ===\n");
    
    // Get the current assembly
    Assembly assembly = Assembly.GetExecutingAssembly();
    Console.WriteLine($"Assembly Name: {assembly.FullName}");
    Console.WriteLine($"Assembly Location: {assembly.Location}");
    Console.WriteLine($"Assembly Image Runtime Version: {assembly.ImageRuntimeVersion}\n");
    
    // Get all types in the CsharpReflectionPoc namespace
    Type[] types = assembly.GetTypes();
    var namespaceTypes = types.Where(t => t.Namespace == "CsharpReflectionPoc").ToArray();
    
    Console.WriteLine($"Types found in CsharpReflectionPoc namespace: {namespaceTypes.Length}\n");
    
    foreach (Type type in namespaceTypes)
    {
        Console.WriteLine($"--- Type: {type.Name} ---");
        Console.WriteLine($"Full Name: {type.FullName}");
        Console.WriteLine($"Base Type: {type.BaseType?.Name ?? "None"}");
        Console.WriteLine($"Is Class: {type.IsClass}");
        Console.WriteLine($"Is Public: {type.IsPublic}");
        Console.WriteLine($"Is Abstract: {type.IsAbstract}");
        Console.WriteLine($"Is Sealed: {type.IsSealed}");
        
        // Constructors
        ConstructorInfo[] constructors = type.GetConstructors();
        Console.WriteLine($"\nConstructors ({constructors.Length}):");
        foreach (ConstructorInfo constructor in constructors)
        {
            var parameters = constructor.GetParameters();
            var paramString = string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
            Console.WriteLine($"  {constructor.Name}({paramString})");
        }
        
        // Methods
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        Console.WriteLine($"\nPublic Methods ({methods.Length}):");
        foreach (MethodInfo method in methods)
        {
            var parameters = method.GetParameters();
            var paramString = string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
            Console.WriteLine($"  {method.ReturnType.Name} {method.Name}({paramString})");
        }
        
        // Properties
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine($"\nPublic Properties ({properties.Length}):");
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"  {property.PropertyType.Name} {property.Name} (CanRead: {property.CanRead}, CanWrite: {property.CanWrite})");
        }
        
        // Fields
        FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine($"\nPrivate Fields ({fields.Length}):");
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine($"  {field.FieldType.Name} {field.Name}");
        }
        
        Console.WriteLine();
    }
}

// Function 2: Execute calculator operations from string
static void ExecuteCalculatorFromString(string calculatorExpression)
{
    Console.WriteLine($"=== Executing: {calculatorExpression} ===\n");
    
    try
    {
        // Parse the initial value from Constructor
        var constructorMatch = Regex.Match(calculatorExpression, @"Calculator\((\d+(?:\.\d+)?)\)");
        if (!constructorMatch.Success)
        {
            Console.WriteLine("Error: Invalid calculator expression format. Must start with Calculator(number)");
            return;
        }
        
        double initialValue = double.Parse(constructorMatch.Groups[1].Value, CultureInfo.InvariantCulture);
        Calculator calculator = new Calculator(initialValue);
        
        // Extract all method calls
        var methodPattern = @"\.(\w+)\(([^)]*)\)";
        var methodMatches = Regex.Matches(calculatorExpression, methodPattern);
        
        foreach (Match match in methodMatches)
        {
            string methodName = match.Groups[1].Value;
            string parameterString = match.Groups[2].Value;
            
            // Get the method using reflection
            Type calculatorType = typeof(Calculator);
            MethodInfo? method = calculatorType.GetMethod(methodName);
            
            if (method == null)
            {
                Console.WriteLine($"Error: Method '{methodName}' not found in Calculator class");
                continue;
            }
            
            // Prepare parameters
            object[] parameters = [];
            var methodParameters = method.GetParameters();
            
            if (methodParameters.Length > 0 && !string.IsNullOrEmpty(parameterString))
            {
                // Parse the parameter (assuming single double parameter for arithmetic operations)
                if (double.TryParse(parameterString.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double paramValue))
                {
                    parameters = [paramValue];
                }
                else
                {
                    Console.WriteLine($"Error: Invalid parameter '{parameterString}' for method '{methodName}'");
                    continue;
                }
            }
            
            // Invoke the method
            try
            {
                var result = method.Invoke(calculator, parameters);
                // The result should be the calculator instance for method chaining
                if (result is Calculator calc)
                {
                    calculator = calc;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error invoking method '{methodName}': {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        
        Console.WriteLine($"\nFinal Result: {calculator.GetResult()}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error parsing calculator expression: {ex.Message}\n");
    }
}
