using System;
using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems
{
    public class FormingAMagicSquareChallenge
    {
        public static int FormingMagicSquare(int[][] s)
        {
            //entry point logic
            /*var templateMatrix = new[]
            {
                new[] {4, 5, 8}, 
                new[] {2, 4, 1}, 
                new[] {1, 9, 7}
            };
            
            Console.WriteLine(formingMagicSquare(templateMatrix));*/      
            
            var templateMatrix = new[]
            {
                new[] {2, 9, 4}, 
                new[] {7, 5, 3}, 
                new[] {6, 1, 8}
            };

            List<int> values = new List<int>
            {
                ApplyingTemplateMatrix(s, templateMatrix),
                ApplyingTemplateMatrix(s, SwapColumns(templateMatrix)),
                ApplyingTemplateMatrix(s, SwapRows(templateMatrix)),
                ApplyingTemplateMatrix(s, SwapColumns(templateMatrix)),
                ApplyingTemplateMatrix(s, TransponseMatrix(templateMatrix)),
                ApplyingTemplateMatrix(s, SwapRows(templateMatrix)),
                ApplyingTemplateMatrix(s, SwapColumns(templateMatrix)),
                ApplyingTemplateMatrix(s, SwapRows(templateMatrix))
            };

            return values.Min();
        }

        private static int ApplyingTemplateMatrix(int[][] s, int[][] templateMatrix)
        {
            var minimumChanges = 0;

            for (var i = 0; i < s.Length; i++)
                for (var j = 0; j < s[i].Length; j++)
                    minimumChanges += Math.Abs(s[i][j] - templateMatrix[i][j]);

            return minimumChanges;
        }

        private static int[][] TransponseMatrix(int[][] matrix)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    var temp = matrix[i][j];

                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            return matrix;
        }

        private static int[][] SwapColumns(int[][] matrix)
        {
            for (var i = 0; i < 3; i++)
            {
                var temp = matrix[i][0];

                matrix[i][0] = matrix[i][2];
                matrix[i][2] = temp;
            }

            return matrix;
        }

        private static int[][] SwapRows(int[][] matrix)
        {
            for (var i = 0; i < 3; i++)
            {
                var temp = matrix[0][i];

                matrix[0][i] = matrix[2][i];
                matrix[2][i] = temp;
            }

            return matrix;
        }

        private static void PrintMatrix(int[][] matrix, int minimumChanges)
        {
            var outputString = "";
            
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length - 1; j++)
                {
                    outputString += matrix[i][j] + "\t";
                }

                outputString += matrix[i][matrix[i].Length - 1] + "\n";
            }
            
            Console.WriteLine("{0}\n{1}\n", outputString, minimumChanges);
        }
    }
}