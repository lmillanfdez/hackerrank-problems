using System;
using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems
{
    public class SwapNodesChallenge
    {
        //entry point
        /* var indexes = new List<List<int>>()
        {
            new List<int>(){ 2, 3 },
            new List<int>(){ -1, -1 },
            new List<int>(){ -1, -1 }
        };

        var queries = new List<int>() { 1, 1 };

        var result = swapNodes(indexes, queries);

        Console.Write(String.Join("\n", result.Select(x => String.Join(" ", x)))); */


        public static List<List<int>> swapNodes(List<List<int>> indexes, List<int> queries)
        {
            var result = new List<List<int>>();
            
            foreach(var query in queries)
            {
                string inOrder = String.Empty;
                
                swapNodes(indexes, 0, query, 1, ref inOrder);
                
                result.Add(inOrder.Trim().Split(' ').Select(item => Convert.ToInt32(item)).ToList());
            }
            
            return result;
        }
        
        private static void swapNodes(List<List<int>> indexes, int currentNodeIndex, int k, int depth, ref string inOrder)
        {
            if(depth % k == 0)
            {
                int tmpIndex = indexes[currentNodeIndex][0];
                
                indexes[currentNodeIndex][0] = indexes[currentNodeIndex][1];
                indexes[currentNodeIndex][1] = tmpIndex;
            }
            
            if(indexes[currentNodeIndex][0] > 0)
                swapNodes(indexes, indexes[currentNodeIndex][0] - 1, k, depth + 1, ref inOrder);
                
            inOrder = $"{inOrder} {currentNodeIndex + 1}";
            
            if(indexes[currentNodeIndex][1] > 0)
                swapNodes(indexes, indexes[currentNodeIndex][1] - 1, k, depth + 1, ref inOrder);
        }
    }
}