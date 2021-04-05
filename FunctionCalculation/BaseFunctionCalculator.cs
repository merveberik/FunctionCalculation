using System;

namespace FunctionCalculation
{
    class BaseFunctionCalculator
    {

        static void Main(string[] args)
        {

            Calculate(3);

        }

        public static void Calculate(int n)
        {
            byte i;
            double functionSum;
            functionSum = 0;
            for (i = 0; i <= n; i++)
            {
                double radiansValue = (i * (Math.PI)) / 180;
                double sinValue = Math.Sin(radiansValue) * i;
                functionSum = functionSum + sinValue;
            }
            Console.WriteLine("Summation of function value is " + functionSum);


        }
    }
}
