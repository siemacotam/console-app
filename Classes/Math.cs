using System;

namespace HelloWorld.Classes;

public class Math
{
    public static void PerformMathOperation(Func<string?, string?, double?> operation)
    {
        Console.Write("Put first number: ");
        var a = Console.ReadLine();

        Console.WriteLine("Put second number: ");
        var b = Console.ReadLine();

        var result = operation(a, b);

        if (result.HasValue)
        {
            Console.WriteLine($"Result is {result}");
        }
    }
    private static double? TryConvertToDouble(string? input)
    {
        if (double.TryParse(input, out double result))
        {
            return result;
        }
        Console.WriteLine("Invalid number format. Please enter a valid integer or decimal number.");
        return null;
    }

    public static double? Addition(string? a, string? b)
    {
        double? num1 = TryConvertToDouble(a);
        double? num2 = TryConvertToDouble(b);
        return num1.HasValue && num2.HasValue ? num1.Value + num2.Value : null;
    }

    public static double? Subtraction(string? a, string? b)
    {
        double? num1 = TryConvertToDouble(a);
        double? num2 = TryConvertToDouble(b);
        return num1.HasValue && num2.HasValue ? num1.Value - num2.Value : null;
    }

    public static double? Multiplication(string? a, string? b)
    {
        double? num1 = TryConvertToDouble(a);
        double? num2 = TryConvertToDouble(b);
        return num1.HasValue && num2.HasValue ? num1.Value * num2.Value : null;
    }

    public static double? Division(string? a, string? b)
    {
        double? num1 = TryConvertToDouble(a);
        double? num2 = TryConvertToDouble(b);

        if (!num1.HasValue || !num2.HasValue)
        {
            return null;
        }

        if (num2.Value == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
            return null;
        }

        return num1.Value / num2.Value;
    }
}