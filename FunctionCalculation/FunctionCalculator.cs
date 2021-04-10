using System;
using System.Collections.Generic;

namespace FunctionCalculation
{
    class FunctionCalculator
    {

        static void Main(string[] args)
        {
            Function functionCalculation = new BaseFunctionCalculation();
            functionCalculation.SetCacheSize(4);
            functionCalculation.Calculate(2);
            functionCalculation.Calculate(1);
            functionCalculation.Calculate(3);
            functionCalculation.Calculate(2);
            functionCalculation.Calculate(2);
            functionCalculation.GetCacheElement(0);
            functionCalculation.GetCacheElement(1);
            functionCalculation.GetCacheElement(2);
            functionCalculation.GetCacheElement(3);
            //functionCalculation.GetCacheElement(5);

        }

        abstract class Function
        {
            public static int sizeOfArray;
            public static int sizeValue = 1, index = 0;
            public abstract double Calculate(int n);
            public abstract void SetCacheSize(int size);
            public abstract int GetCacheElement(int index);
        }
        class BaseFunctionCalculation : Function
        {
            double[] _sumBuffer = new double[sizeValue];
            double _functionSum;
            int temp;
            int[] numbers = new int[5];
            bool sameNumber;

            public override double Calculate(int n)
            {

                numbers[index] = n;
                sameNumber = false;
                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i; j < numbers.Length; j++)
                    {
                        if (numbers[j] == 0)
                        {
                            break;
                        }
                        if (numbers[index] == numbers[j] && index != j)
                        {
                            if (j == 0)
                            {
                                numbers[index] = -1;
                                break;
                            }
                            temp = numbers[j - 1];
                            numbers[j - 1] = numbers[index];
                            numbers[j] = temp;
                            numbers[index] = -1;
                            sameNumber = true;
                            break;
                        }
                        if (numbers[i] != numbers[j] && j == index)
                        {

                            temp = numbers[j];
                            numbers[j] = numbers[i];
                            numbers[i] = temp;

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
                //Console.WriteLine(_sumBuffer[index]);
                try
                {
                    Console.WriteLine(numbers[index]);
                }
                catch (Exception)
                {
                    Console.WriteLine("No memory " + -1);
                }


                return 0;
            }




        }

    }
}
