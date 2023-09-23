using System;
using Pi.Math; // Import the necessary namespaces

int decimalPlaces = 100; // Set the number of decimal places you want
bool recordMetrics = true; // Set whether to record metrics or not

HighPrecision pi = MachinFormula.Calculate(decimalPlaces, recordMetrics);

// Print the result
Console.WriteLine($"Pi to {decimalPlaces} decimal places: {pi}");
