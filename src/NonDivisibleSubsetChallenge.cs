using System;
using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems
{
    public class NonDivisibleSubsetChallenge
    {
        public static int NonDivisibleSubset(int k, int[] S)
        {
            //entry point logic
            /*var elements = new[] {2, 7, 12, 17, 22};

            Console.WriteLine(nonDivisibleSubset(5, elements));*/
            
            var resultingValue = 0;
            var remainderGroups = new Dictionary<int, int>();

            foreach (var element in S)
            {
                var remainder = element % k;
                int numberOfElements;
                
                if(remainderGroups.TryGetValue(remainder, out numberOfElements))
                    remainderGroups[remainder] = numberOfElements + 1;
                else
                    remainderGroups.Add(remainder, 1);
            }
            
            foreach (int remainderGroupsKey in remainderGroups.Keys.OrderBy(item => item))
                if (remainderGroupsKey > k / 2)
                {
                    //we are going to analyze a remainder which is greater than k / 2,
                    //just in case its complementing remainder does not exist,
                    //since we are iterating through a sorted keys collection
                    if (!remainderGroups.ContainsKey(k - remainderGroupsKey))
                        resultingValue += remainderGroups[remainderGroupsKey];
                }
                else if (Double.Parse(remainderGroupsKey.ToString()) == Double.Parse(k.ToString()) / 2)
                {
                    //among all those numbers having a remainder which is equal to the (k/2)-th,
                    //we will be having into account only one
                    resultingValue += 1;
                }
                else if (remainderGroupsKey > 0)
                {
                    //if there are sets of numbers having complementing remainders,
                    //we will be adding to the resulting set, that set having the greatest amount of numbers
                    resultingValue += Math.Max(remainderGroups[remainderGroupsKey],
                        remainderGroups.ContainsKey(k - remainderGroupsKey) ? remainderGroups[k - remainderGroupsKey] : 0);
                }

            //you must only add one number having a 0-value remainder when divided by k to the resulting subset
            if (remainderGroups.ContainsKey(0))
                resultingValue += 1;

            return resultingValue;
        }
    }
}