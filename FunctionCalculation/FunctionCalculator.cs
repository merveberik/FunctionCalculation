using System;

namespace FunctionCalculation
{
    class FunctionCalculator
    {

        static void Main(string[] args)
        {
            Function functionCalculation = new BaseFunctionCalculation();
            functionCalculation.SetCacheSize(3);
            functionCalculation.Calculate(1);
            functionCalculation.Calculate(2);
            functionCalculation.Calculate(3);
            functionCalculation.GetCacheElement(0);
            functionCalculation.GetCacheElement(1);
            functionCalculation.GetCacheElement(2);
        }

        abstract class Function
        {
            public static int sizeOfArray;
            public abstract double Calculate(int n);
            public abstract void SetCacheSize(int size);
            public abstract int GetCacheElement(int index);
        }
        class BaseFunctionCalculation : Function
        {
            double[] _sumBuffer = new double[sizeOfArray];
            int[] array = new int[3];
            double _functionSum;
            public override double Calculate(int n)
            {
                UInt16 j;
                _functionSum = 0;

                for (j = 0; j <= n; j++)
                {
                    double radiansValue = (j * (Math.PI)) / 180;
                    var sinValue = Math.Sin(radiansValue) * j;
                    _functionSum += sinValue;
                }

                if (_sumBuffer[sizeOfArray-1] == 0)
                {
                    _sumBuffer[sizeOfArray-1] = _functionSum;

                }
                else
                {
                    sizeOfArray--;
                    if (_sumBuffer[sizeOfArray-1] == 0)
                    {
                        _sumBuffer[sizeOfArray-1] = _functionSum;
                    }
                }

                return 0;
            }

            public override void SetCacheSize(int size)
            {
                _sumBuffer = new double[size];
                sizeOfArray = _sumBuffer.Length;
            }

            public override int GetCacheElement(int index)
            {
                Console.WriteLine(_sumBuffer[index]);
                return 0;
            }

        }

    }
}
