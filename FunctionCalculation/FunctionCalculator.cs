using System;
using System.Collections.Generic;

namespace FunctionCalculation
{
    class FunctionCalculator
    {

        static void Main(string[] args)
        {
            Function functionCalculation = new BaseFunctionCalculation();
            functionCalculation.SetCacheSize(3);

            int[] calculateNumber = { 5, 20, 10, 5, 5, 5, 2, 3 };
            int[] getNumber = { 0, 1, 2, 3 };
            foreach (var item in calculateNumber)
            {
                functionCalculation.Calculate(item);
            }
            foreach (var item in getNumber)
            {
                functionCalculation.GetCacheElement(item);
            }

        }

        abstract class Function
        {
            public static int sizeOfArray;
            public static int index = 0;
            public abstract double Calculate(int n);
            public abstract void SetCacheSize(int size);
            public abstract int GetCacheElement(int index);
        }
        class BaseFunctionCalculation : Function
        {
            double[] _sumBuffer;
            double _functionSum, _tempSumBuffer;
            int _tempNumber;
            int[] _numberSorting;
            bool _sameNumber, _firstCheckSameNumber = true, _calculate = true;

            public override double Calculate(int n)
            {   /* Check if the first number is same number */
                for (int i = 0; i < index; i++)
                {
                    if (_numberSorting[i] == n)
                    {
                        _calculate = false;
                        if (_firstCheckSameNumber == true)
                        {
                            _firstCheckSameNumber = false;
                            return 0;
                        }
                    }
                }
                /* Check if queue is full delete clean last index */
                if (index > sizeOfArray - 1)
                {
                    index = sizeOfArray - 1;
                    Array.Clear(_numberSorting, sizeOfArray - 1, 1);
                }
                _numberSorting[index] = n;
                _sameNumber = false;

                /* Calculate if not calculated */
                if (_calculate)
                {
                    _functionSum = 0;
                    for (int j = 0; j <= n; j++)
                    {
                        double radiansValue = (j * (Math.PI)) / 180;
                        var sinValue = Math.Sin(radiansValue) * j;
                        _functionSum += sinValue;

                    }
                    _sumBuffer[index] = _functionSum;

                }
                _calculate = true;

                for (int i = 0; i < _numberSorting.Length; i++)
                {
                    for (int j = i; j < _numberSorting.Length; j++)
                    {
                        /* If number is zero, do not shift */
                        if (_numberSorting[j] == 0)
                        {
                            break;
                        }
                        /* Shift number, Check, if there is same number and different index */
                        if (_numberSorting[index] == _numberSorting[j] && index != j)
                        {
                            if (j == 0)
                            {
                                _sameNumber = true;
                                break;
                            }
                            else
                            {
                                /* shift number */
                                _tempNumber = _numberSorting[j - 1];
                                _numberSorting[j - 1] = _numberSorting[index];
                                _numberSorting[j] = _tempNumber;
                                _sameNumber = true;
                                /* shift result */
                                _tempSumBuffer = _sumBuffer[j - 1];
                                _sumBuffer[j - 1] = _sumBuffer[index];
                                _sumBuffer[i] = _tempSumBuffer;
                            }

                            break;
                        }
                        /* Shift number, Check, if there is different number and same index */
                        if (_numberSorting[i] != _numberSorting[j] && j == index)
                        {
                            _tempNumber = _numberSorting[j];
                            _numberSorting[j] = _numberSorting[i];
                            _numberSorting[i] = _tempNumber;

                            _tempSumBuffer = _sumBuffer[j];
                            _sumBuffer[j] = _sumBuffer[i];
                            _sumBuffer[i] = _tempSumBuffer;
                        }
                    }
                    /* If shift same number break loop */
                    if (_sameNumber == true)
                    {
                        break;
                    }
                }

                index++;
                return 1;
            }

            public override void SetCacheSize(int size)
            {
                _numberSorting = new int[size];
                _sumBuffer = new double[size];
                sizeOfArray = _sumBuffer.Length;
            }

            public override int GetCacheElement(int index)
            {
                try
                {
                    Console.WriteLine(_sumBuffer[index]);
                }
                catch (Exception)
                {
                    Console.WriteLine(-1);
                }
                return 0;
            }

        }

    }
}
