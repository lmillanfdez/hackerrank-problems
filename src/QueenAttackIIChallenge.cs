using System;
using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems
{
    public class QueenAttackIIChallenge
    {
        private enum Directions {N, NW, W, SW, S, SE, E, NE }
        
        public static int QueensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            //entry point logic
            /*private enum Directions {N, NW, W, SW, S, SE, E, NE }
            Console.WriteLine(queensAttack(5, 3, 4, 3, new []{ new []{5, 5}, new []{4, 2}, new []{2, 3} }));*/
            
            var amountOfAttackedCells = new Dictionary<Directions, int>()
            {
                { Directions.N, r_q - 1},
                { Directions.NW, Math.Min(r_q - 1, c_q - 1)},
                { Directions.W, c_q - 1},
                { Directions.SW, Math.Min(n - r_q, c_q - 1)},
                { Directions.S, n - r_q},
                { Directions.SE, Math.Min(n - r_q, n - c_q)},
                { Directions.E, n - c_q},
                { Directions.NE, Math.Min(r_q - 1, n - c_q)}
            };

            for (var i = 0; i < k; i++)
            {
                var distanceFromQueen = -1;
                
                var obstacleRow = obstacles[i][0];
                var obstacleColunm = obstacles[i][1];

                var rowsDifference = Math.Abs(obstacleRow - r_q);
                var colunmsDifference = Math.Abs(obstacleColunm - c_q);
                
                Directions obstacleDirection = GetDirections(obstacleRow, obstacleColunm, r_q, c_q);

                if (rowsDifference == 0)
                {
                    distanceFromQueen = Math.Abs(obstacleColunm - c_q);
                }
                else if (colunmsDifference == 0)
                {
                    distanceFromQueen = Math.Abs(obstacleRow - r_q);
                }
                else if(rowsDifference == colunmsDifference)
                {
                    distanceFromQueen = rowsDifference;
                }
                
                if(distanceFromQueen < 0)
                    continue;
                
                amountOfAttackedCells[obstacleDirection] = Math.Min(amountOfAttackedCells[obstacleDirection],
                                                                                                distanceFromQueen - 1);
            }

            var amountOfCells = amountOfAttackedCells.Values.Sum();
            
            return amountOfCells;
        }

        private static Directions GetDirections(int obstacleRow, int obstacleColumn, int queenRow, int queenColumn)
        {
            if (obstacleRow < queenRow)
                return obstacleColumn < queenColumn ? Directions.NW : obstacleColumn == queenColumn ? 
                                                                                    Directions.N : Directions.NE;

            if (obstacleRow == queenRow)
                return obstacleColumn < queenColumn ? Directions.W : Directions.E;

            return obstacleColumn < queenColumn ? Directions.SW : obstacleColumn == queenColumn ? 
                                                                                    Directions.S : Directions.SE;   
        }
    }
}