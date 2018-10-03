using System;

namespace hackerrank_problems
{
    public class MiniMaxSumChallenge
    {
        public static void MiniMaxSum(int[] arr) 
        {
            //entry point logic
            /*var nums = new[] { 1, 2, 3, 4, 5 };
            miniMaxSum(nums);*/
            
            var minMax = new []{ long.MaxValue, 0L };
            var total = 0L;
            
            foreach(var elem in arr)
                total += elem;

            foreach(var elem in arr)
            {
                minMax[0] = Math.Min(minMax[0], total - elem); 
            }            
            
            Console.WriteLine("{0}\n{1}", minMax[0], minMax[1]);
        }
    }
}