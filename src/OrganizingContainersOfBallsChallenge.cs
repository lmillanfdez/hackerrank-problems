using System.Collections.Generic;

namespace hackerrank_problems
{
    public class OrganizingContainersOfBallsChallenge
    {
        public static string OrganizingContainers(int[][] container)
        {
            //entry point logic
            /*var containers = new[] {new[] {0, 2}, new[] {1, 1}};
            
            Console.WriteLine(organizingContainers(containers));*/
            
            const string possibleResult = "Possible";
            const string impossibleResult = "Impossible";

            var choosenTypes = new Dictionary<int, bool>();
            
            for (var i = 0; i < container.Length; i++)
                choosenTypes.Add(i, false);
            
            var amountOfBallsOfType = new int[container.Length];
            var amountOfBallsInContainer = new int[container.Length];

            for (var i = 0; i < container.Length; i++)
            {
                for (var j = 0; j < container[i].Length; j++)
                {
                    amountOfBallsInContainer[i] += container[i][j];
                    amountOfBallsOfType[j] += container[i][j];
                }
            }
            
            //determining which containers can store which types of balls
            var distribution = new bool[container.Length][];

            for (var i = 0; i < container.Length; i++)
            {
                distribution[i] = new bool[container[i].Length];
                
                for (var j = 0; j < container[i].Length; j++)
                    distribution[i][j] = amountOfBallsOfType[j] == amountOfBallsInContainer[i];
            }

            return IsPossible(distribution, 0, choosenTypes) ? possibleResult : impossibleResult;
        }

        private static bool IsPossible(bool[][] distribution, int row, Dictionary<int, bool> choosenTypes)
        {
            if (row == distribution.Length)
                return true;
            
            for (var column = 0; column < distribution[row].Length; column++)
            {
                if (distribution[row][column] && !choosenTypes[column])
                {
                    choosenTypes[column] = true;

                    if (IsPossible(distribution, row + 1, choosenTypes))
                        return true;

                    choosenTypes[column] = false;
                }
            }

            return false;
        }
    }
}