using System;

namespace hackerrank_problems
{
    public class PlusMinusChallenge
    {
        public static void PlusMinus(int[] arr)
        {
            //entry point logic
            /*var testingArray = new []{ -4, 3, -9, 0, 4, 1 };
            plusMinus(testingArray);*/
            
            decimal positiveNumbers = 0;
            decimal negativeNumbers = 0;
            decimal equalToZeroNumbers = 0;

            foreach (var num in arr)
            {
                if (num > 0)
                    positiveNumbers++;
                else if (num < 0)
                    negativeNumbers++;
                else
                    equalToZeroNumbers++;
            }
            
            Console.WriteLine("{0}\n{1}\n{2}", 
                Math.Round(positiveNumbers / arr.Length, 6), 
                Math.Round(negativeNumbers / arr.Length, 6), 
                Math.Round(equalToZeroNumbers / arr.Length, 6));
        }
    }
}