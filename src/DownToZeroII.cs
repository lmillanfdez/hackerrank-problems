using System;
using System.Collections.Generic;

namespace hackerrank_problems
{
    class DownToZeroII
    {
        public static int downToZero(int n)
        {
            //entry point logic
            /* Console.Write(DownToZeroII.downToZero(94)); */

            if(n <= 4)
                return n <= 3 ? n : --n;

            var memory = new Dictionary<int, bool>();

            int currentDivider;
            int currentLevelAmount = 1;
            int nextLevelAmount = 0;
            int amountLevels = 1;
            
            var queue = new Queue<int>(new []{n});

            while(queue.TryDequeue(out currentDivider))
            {
                var currentDividerMinusOne = currentDivider - 1;

                if(currentDividerMinusOne == 4 || currentDividerMinusOne == 3)
                {
                    return amountLevels + 3;
                }
                else if(!memory.GetValueOrDefault(currentDividerMinusOne))
                {
                    memory.Add(currentDividerMinusOne, true);
                    queue.Enqueue(currentDividerMinusOne);

                    nextLevelAmount++;
                }

                var incrementalStep = 1;
                var squareRoot = Convert.ToInt32(Math.Sqrt(currentDivider));
                var tempDivider = 2;
                int complementaryDivider;
                
                if(currentDivider % 2 > 0)
                {
                    tempDivider = 3;
                    incrementalStep = 2;
                }

                while(tempDivider <= squareRoot)
                {
                    if(currentDivider % tempDivider == 0)
                    {
                        complementaryDivider = currentDivider / tempDivider;

                        if(complementaryDivider == 4 || complementaryDivider == 3)
                        {
                            return amountLevels + 3;
                        }
                        else if(!memory.GetValueOrDefault(complementaryDivider))
                        {
                            memory.Add(complementaryDivider, true);
                            queue.Enqueue(complementaryDivider);

                            nextLevelAmount++;
                        }
                    }

                    tempDivider += incrementalStep;
                }

                if(--currentLevelAmount == 0)
                {
                    currentLevelAmount = nextLevelAmount;
                    nextLevelAmount = 0;

                    if(currentLevelAmount > 0)
                        amountLevels++;
                }
            }

            return amountLevels;
        }
    }
}