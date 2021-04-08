using System;

namespace FunctionCalculation
{
    class FunctionCalculator
    {

        static void Main(string[] args)
        {
            Function functionCalculation = new BaseFunctionCalculation();
            functionCalculation.SetCacheSize(5);
            functionCalculation.Calculate(1);
            functionCalculation.Calculate(2);
            functionCalculation.Calculate(3);
            functionCalculation.Calculate(4);
            functionCalculation.Calculate(5);
            functionCalculation.GetCacheElement(0);
            functionCalculation.GetCacheElement(1);
            functionCalculation.GetCacheElement(2);
            functionCalculation.GetCacheElement(3);
            functionCalculation.GetCacheElement(4);
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
            double _functionSum;
            int _control;
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

                if(_control == 0)
                {
                    sizeOfArray = 0;
                }
                if (_sumBuffer[0] == 0)
                {
                    _sumBuffer[0] = _functionSum;

                }
                else
                {
                    sizeOfArray++;
                    _control++;
                    if (_sumBuffer[sizeOfArray] == 0)
                    {
                        _sumBuffer[sizeOfArray] = _functionSum;
                    }
                }

                return 0;
            }

            public override void SetCacheSize(int size)
            {
                _sumBuffer = new double[size];
                for (var i = 0; i < size; i++)
                {
                    _sumBuffer[i] = 0;
                }
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
