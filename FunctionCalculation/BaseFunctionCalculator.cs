using System;

namespace FunctionCalculation
{
    class BaseFunctionCalculator
    {

        static void Main(string[] args)
        {
            BaseFunctionCalculator calculator = new BaseFunctionCalculator();
            double sum = calculator.Calculate(3);
            Console.WriteLine("Summation of function value is " + sum);

        }

        public double Calculate(int n)
        {
            byte i;
            double functionSum;
            functionSum = 0;
            for (i = 0; i <= n; i++)
            {
                double radiansValue = (i * (Math.PI)) / 180;
                double sinValue = Math.Sin(radiansValue) * i;
                functionSum += sinValue;
            }
            return functionSum;
        }

    }
}
