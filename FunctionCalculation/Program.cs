using System;

namespace FunctionCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            byte i;
            double functionSum;
            functionSum = 0;
            int n;
            n = 3;

            for (i = 0; i <= n; i++)
            {
                double radiansValue = (i * (Math.PI)) / 180;
                double sinValue = Math.Sin(radiansValue) *i;
                functionSum = functionSum + sinValue;
            }
                
            Console.WriteLine("Summation of function value is " + functionSum);

        }
    }
}
