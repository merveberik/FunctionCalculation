using System;

namespace FunctionCalculation
{
    class FunctionCalculator
    {

        static void Main(string[] args)
        {
            Function functionCalculation = new BaseFunctionCalculation();
            functionCalculation.setCacheSize(2);
            functionCalculation.Calculate(2);
            functionCalculation.Calculate(3);
            functionCalculation.getCacheElement(1);

        }

        abstract class Function
        {
            public abstract double Calculate(int n);
            public abstract void setCacheSize(int size);
            public abstract int getCacheElement(int index);
        }
        class BaseFunctionCalculation : Function
        {
            double[] sumBuffer = new double[1];
            double functionSum;
            int sizeOfArray;

            public override double Calculate(int n)
            {
                byte j;
                double sinValue;
                functionSum = 0;

                for (j = 0; j <= n; j++)
                {
                    double radiansValue = (j * (Math.PI)) / 180;
                    sinValue = Math.Sin(radiansValue) * j;
                    functionSum += sinValue;
                    
                }
                if (sumBuffer[sizeOfArray - 2] == 0)
                {
                    sumBuffer[sizeOfArray - 2] = functionSum;
                }
                else if (sumBuffer[sizeOfArray - 2] != 0)
                {
                    sumBuffer[sizeOfArray - 1] = functionSum;
                }

                //Console.WriteLine(sumBuffer[0]);
                //Console.WriteLine(sumBuffer[1]);
                return 0;
            }

            public override void setCacheSize(int size)
            {
                sumBuffer = new double[size];
                for (int i = 0; i < size; i++)
                {
                    sumBuffer[i] = 0;
                }
                sizeOfArray = sumBuffer.Length;
            }

            public override int getCacheElement(int index)
            {
                //cacheElement = sumBuffer[index];
                //Console.WriteLine(cacheElement);
                //sumBuffer[index] = functionSum;

                Console.WriteLine(sumBuffer[index]);
                return 0;
            }

        }

    }
}
