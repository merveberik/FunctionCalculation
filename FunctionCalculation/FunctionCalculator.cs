using System;

namespace FunctionCalculation
{
    class FunctionCalculator
    {

        static void Main(string[] args)
        {
            Function functionCalculation = new BaseFunctionCalculation();
            functionCalculation.setCacheSize(5);
            functionCalculation.Calculate(1);
            functionCalculation.Calculate(2);
            functionCalculation.Calculate(3);
            functionCalculation.Calculate(4);
            functionCalculation.Calculate(5);
            functionCalculation.getCacheElement(0);
            functionCalculation.getCacheElement(1);
            functionCalculation.getCacheElement(2);
            functionCalculation.getCacheElement(3);
            functionCalculation.getCacheElement(4);
        }

        abstract class Function
        {
            public int sizeOfArray;
            public abstract double Calculate(int n);
            public abstract void setCacheSize(int size);
            public abstract int getCacheElement(int index);
        }
        class BaseFunctionCalculation : Function
        {
            double[] sumBuffer = new double[5];
            double functionSum;
            
            int value;
            int control;
            public override double Calculate(int n)
            {
                UInt16 j;
                double sinValue;
                functionSum = 0;
                
                for (j = 0; j <= n; j++)
                {
                    double radiansValue = (j * (Math.PI)) / 180;
                    sinValue = Math.Sin(radiansValue) * j;
                    functionSum += sinValue;
                    
                }

                if(control == 0)
                {
                    value = 0;
                }
                if (sumBuffer[0] == 0)
                {
                    sumBuffer[0] = functionSum;

                }
                else
                {
                    value++;
                    control++;
                    if (sumBuffer[value] == 0)
                    {
                        sumBuffer[value] = functionSum;
                    }
                }

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
                Console.WriteLine(sumBuffer[index]);
                return 0;
            }

        }

    }
}
