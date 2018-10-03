using System.Collections.Generic;

namespace hackerrank_problems
{
    public class ClimbingLeaderBoardChallenge
    {
        private static int[] ClimbingLeaderboard(int[] scores, int[] alice)
        {
            //entry point logic
            /*var scores = new[] {100, 50, 40, 40, 20, 10};
            var alice = new[] {5, 25, 50, 120};
            
            Console.WriteLine(String.Join("\n", climbingLeaderboard(scores, alice)));*/
            
            List<int> resultingRanks = new List<int>();
            
            int amountOfScores = scores.Length;
            int currentScore = -1;
            int rankCounter = 0;

            for (int i = 0; i < amountOfScores; i++)
            {
                if (currentScore < 0 || currentScore != scores[i])
                {
                    currentScore = scores[i];
                    rankCounter++;
                }
            }
            
            for (int i = 0; i < alice.Length; i++)
            {
                while (alice[i] >= currentScore && amountOfScores > 0)
                {
                    amountOfScores--;
                    
                    if (currentScore == scores[amountOfScores])
                        continue;
                    
                    currentScore = scores[amountOfScores];
                    rankCounter--;
                }

                int currentRank = alice[i] >= currentScore ? 1 : rankCounter + 1;
                resultingRanks.Add(currentRank);
            }
            
            return resultingRanks.ToArray();
        }
    }
}