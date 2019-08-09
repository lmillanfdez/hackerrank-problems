using System.Collections.Generic;
using System.Text;

using hackerrank_problems.utils;

namespace hackerrank_problems
{
    public class LevelOrderTraversalChallenge
    {
        public static string levelOrder(Node root)
        {
            string resultingString = "";

            Queue<Node> nodesQueue = new Queue<Node>();
            nodesQueue.Enqueue(root);

            StringBuilder sb = new StringBuilder();
            Node currentNode;
            List<string> nodesIds = new List<string>();

            while(nodesQueue.Count > 0)
            {
                if(!string.IsNullOrEmpty(resultingString))
                    sb.Append(" -> ");

                sb.Append((currentNode = nodesQueue.Dequeue()).ToString());

                if(currentNode.LeftChild != null)
                    nodesQueue.Enqueue(currentNode.LeftChild);

                if(currentNode.RightChild != null)
                    nodesQueue.Enqueue(currentNode.RightChild);
            }

            return sb.ToString();
        }
    }
}