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
            double[] _sumBuffer = new double[index];
            double _functionSum;
            int temp;
            int[] numberSorting = new int[3];
            bool sameNumber, firstCheckSameNumber = true;

            public override double Calculate(int n)
            {
                for (int i = 0; i < index; i++)
                {
                    if (numberSorting[i] == n && firstCheckSameNumber == true)
                    {
                        firstCheckSameNumber = false;
                        return 0;
                    }
                }
                if (index > 2)
                {
                    index = 2;
                    Array.Clear(numberSorting, 2, 1);
                }
                numberSorting[index] = n;
                sameNumber = false;
                for (int i = 0; i < numberSorting.Length; i++)
                {
                    for (int j = i; j < numberSorting.Length; j++)
                    {
                        if (numberSorting[j] == 0)
                        {
                            break;
                        }
                        if (numberSorting[index] == numberSorting[j] && index != j)
                        {
                            if (j == 0)
                            {
                                temp = numberSorting[j];
                                numberSorting[j] = numberSorting[index];
                                numberSorting[j] = temp;
                                sameNumber = true;
                                break;
                            }
                            temp = numberSorting[j - 1];
                            numberSorting[j - 1] = numberSorting[index];
                            numberSorting[j] = temp;
                            sameNumber = true;
                            break;
                        }
                        if (numberSorting[i] != numberSorting[j] && j == index)
                        {

                            temp = numberSorting[j];
                            numberSorting[j] = numberSorting[i];
                            numberSorting[i] = temp;

                        }
                    }
                    if (sameNumber == true)
                    {
                        break;
                    }
                }

                _functionSum = 0;
       

                for (int j = 0; j <= n; j++)
                {
                    double radiansValue = (j * (Math.PI)) / 180;
                    var sinValue = Math.Sin(radiansValue) * j;
                    _functionSum += sinValue;

                }
                _sumBuffer[index] = _functionSum;

                index++;
                return 1;
            }

            public override void SetCacheSize(int size)
            {
                _sumBuffer = new double[size];
                sizeOfArray = _sumBuffer.Length;

            }

            public override int GetCacheElement(int index)
            {
                try
                {
                    Console.WriteLine(numberSorting[index]);
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
