using System.Collections.Generic;

namespace hackerrank_problems
{
    public class CycleDetectionChallenge
    {
        public class SinglyLinkedListNode 
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData) {
                this.data = nodeData;
                this.next = null;
            }
        }
        
        public static bool hasCycle(SinglyLinkedListNode head) 
        {
            //entry point logic
            /*var firstNode = new CycleDetectionChallenge.SinglyLinkedListNode(1);
            var secondNode = new CycleDetectionChallenge.SinglyLinkedListNode(2);
            var thirdNode = new CycleDetectionChallenge.SinglyLinkedListNode(3);

            thirdNode.next = firstNode;

            firstNode.next = secondNode;
            secondNode.next = thirdNode;
            
            System.Console.Write(CycleDetectionChallenge.hasCycle(firstNode) ? "It has cycles" : "It hasn't cycles");*/
            
            var visitedNodes = new Dictionary<SinglyLinkedListNode, bool>();

            while (head != null)
            {
                if (visitedNodes.ContainsKey(head))
                    return true;
                
                visitedNodes.Add(head, true);
                head = head.next;
            }

            return false;
        }
    }
}