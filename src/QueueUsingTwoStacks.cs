using System;
using System.Collections.Generic;
using System.IO;

namespace hackerrank_problems;

class QueueUsingTwoStacks {
    static void Main(String[] args) {
        var numLines = Convert.ToInt32(Console.ReadLine().Trim());
        var customQueue = new CustomQueue<int>();
        var results = new List<string>();
        
        while(numLines-- > 0)
        {
            var arguments = Console.ReadLine().Trim().Split(' ');
            
            switch(Convert.ToInt32(arguments[0]))
            {
                case 1:
                    customQueue.Enqueue(Convert.ToInt32(arguments[1]));
                    break;
                case 2:
                    customQueue.Dequeue();
                    break;
                default:
                    var element = customQueue.Peek();
                    results.Add(element.ToString());
                    break;
            }
        }
        
        Console.WriteLine(string.Join('\n', results));
    }
}

class CustomQueue<T>
{
    private Stack<T> IncomingStack { get; set; } = new Stack<T>();
    private Stack<T> OutgoingStack { get; set; } = new Stack<T>();
    
    public void Enqueue(T element)
    {
        IncomingStack.Push(element);
    }
    
    public T Dequeue()
    {
        if(!OutgoingStack.TryPop(out T fResult))
        {
            MoveElements();
            
            if(OutgoingStack.TryPop(out T tResult))
                return tResult;
            else
                throw new InvalidOperationException("Queue is empty.");
        }
        else
        {
            return fResult;
        }
    }
    
    public T Peek()
    {
        if(!OutgoingStack.TryPeek(out T fResult))
        {
            MoveElements();
            
            if(OutgoingStack.TryPeek(out T tResult))
                return tResult;
            else
                throw new InvalidOperationException("Queue is empty.");
        }
        else
        {
            return fResult;
        }
    }
    
    private void MoveElements()
    {
        while(IncomingStack.TryPop(out T result))
        {
            OutgoingStack.Push(result);
        }
    }
}