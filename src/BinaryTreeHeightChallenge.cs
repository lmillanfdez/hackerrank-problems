using System;
using hackerrank_problems.utils;

namespace hackerrank_problems
{
    public class BinaryTreeHeightChallenge
    {
        public static int Height(Node root)
        {
            //entry point logic
            /*var root = new Node{Data = 1};
            
            var leftChildLevel1 = new Node{Data = 2};
            leftChildLevel1.RightChild = new Node {Data = 3};
            
            var rightChildLevel1 = new Node{Data = 4};

            root.LeftChild = leftChildLevel1;
            root.RightChild = rightChildLevel1;
            
            Console.WriteLine(BinaryTreeHeightChallenge.Height(root));*/
            
            if (root == null 
                || root.LeftChild == null && root.RightChild == null)
                return 0;

            var rootHeight = Math.Max(Height(root.LeftChild), Height(root.RightChild));
            return rootHeight + 1;
        } 
    }
}