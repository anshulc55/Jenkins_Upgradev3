using System;
using Pi.Math; 

public class Program
{
    public static void Main()
    {
        int decimalPlaces = 100; // Set the number of decimal places you want
        bool recordMetrics = true; // Set whether to record metrics or not

        // Calculate Pi using your MachinFormula class
        HighPrecision pi = MachinFormula.Calculate(decimalPlaces, recordMetrics);

        // Print the result
        Console.WriteLine($"Pi to {decimalPlaces} decimal places: {pi}");
    }
}
