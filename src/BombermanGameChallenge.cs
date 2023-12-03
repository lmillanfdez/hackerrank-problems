using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems
{
    class BombermanGameChallenge
    {

        /*
        * Complete the 'bomberMan' function below.
        *
        * The function is expected to return a STRING_ARRAY.
        * The function accepts following parameters:
        *  1. INTEGER n
        *  2. STRING_ARRAY grid
        */

        public static List<string> BomberMan(int n, List<string> grid)
        {
            if(n < 2)
                return grid;
            
            var bombChar = 'O';
            var blankChar = '.';

            var rows = grid.Count();
            var columns = grid.First().Length;
            var resultingGrid = new List<string>();
            
            for(var i = 0; i < rows; i++)
            {
                var resultingString = string.Empty;
                char c;
                
                for(var j = 0; j < columns; j++)
                {
                    if(grid[i][j] == bombChar)
                    {
                        c = n % 4 == 0 || n % 4 == 1 || n % 4 == 2 ? bombChar : blankChar;
                    }
                    else if((j > 0 && grid[i][j - 1] == bombChar) 
                            || (j < columns - 1 && grid[i][j + 1] == bombChar)
                            || (i > 0 && grid[i - 1][j] == bombChar)
                            || (i < rows - 1 && grid[i + 1][j] == bombChar))
                    {
                        if(IsCoveredCell(i, j, rows, columns, grid))
                            c = n % 4 == 0 || n % 4 == 1 || n % 4 == 2 ? bombChar : blankChar;
                        else
                            c = n % 2 == 0 ? bombChar : blankChar;
                    }
                    else
                    {
                        c = n % 4 == 0 || n % 4 == 2 || n % 4 == 3 ? bombChar : blankChar;
                    }
                        
                    resultingString += c.ToString();
                }   
                
                resultingGrid.Add(resultingString);
            }
            
            return resultingGrid;
        }

        private static bool IsCoveredCell(int i, int j, int rows, int columns, List<string> grid)
        {
            var upperRow = i == 0 || (i > 1 && grid[i - 2][j] == 'O') 
                                || ((j > 0 && grid[i - 1][j - 1] == 'O') || grid[i - 1][j] == 'O' || (j < columns - 1 && grid[i - 1][j + 1] == 'O'));
            var bottomRow = i == rows - 1 || (i < rows - 2 && grid[i + 2][j] == 'O') 
                                || ((j > 0 && grid[i + 1][j - 1] == 'O') || grid[i + 1][j] == 'O' || (j < columns - 1 && grid[i + 1][j + 1] == 'O'));

            var leftCol = j == 0 || (j > 1 && grid[i][j - 2] == 'O') 
                                || ((i > 0 && grid[i - 1][j - 1] == 'O') || grid[i][j - 1] == 'O' || (i < rows - 1 && grid[i + 1][j - 1] == 'O'));
            var rightCol = j == columns - 1 || (j < columns - 2 && grid[i][j + 2] == 'O')
                                || ((i > 0 && grid[i - 1][j + 1] == 'O') || grid[i][j + 1] == 'O' || (i < rows - 1 && grid[i + 1][j + 1] == 'O'));

            return upperRow && bottomRow && leftCol && rightCol;
        }
    }
}