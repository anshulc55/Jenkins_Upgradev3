using Pi.Math;
using PowerArgs;
using System;
using System.IO;

namespace Pi.Runtime.NetFx
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = Args.Parse<Arguments>(args);
            switch (arguments.Mode)
            {
                case RunMode.Web:
                    Console.WriteLine("TODO...");
                    break;

                case RunMode.Console:
                    Console.WriteLine(GetPi(arguments.DecimalPlaces));
                    break;

                case RunMode.File:
                    File.WriteAllText(arguments.OutputPath, GetPi(arguments.DecimalPlaces));
                    Console.WriteLine($"Wrote pi to: {arguments.DecimalPlaces} dp; at: {arguments.OutputPath}");
                    break;
            }
        }
        private static string GetPi(int decimalPlaces)
        {
            return MachinFormula.Calculate(decimalPlaces).ToString();
        }
    }
}