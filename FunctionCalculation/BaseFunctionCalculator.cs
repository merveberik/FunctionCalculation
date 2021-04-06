using System;

namespace FunctionCalculation
{
    class BaseFunctionCalculator
    {

        static void Main(string[] args)
        {
      
            FunctionCalculation functionCalculation = new Function();
            double sum = functionCalculation.Calculate(3);
            Console.WriteLine("Summation of function value is " + sum);

        }


        abstract class FunctionCalculation
        {
            public abstract double Calculate(int n);
            public abstract void setCacheSize(int size);
        }
        class Function : FunctionCalculation
        {
            public override double Calculate(int n)
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

            public override void setCacheSize(int size)
            {
                throw new NotImplementedException();
            }
        }

    }
}
