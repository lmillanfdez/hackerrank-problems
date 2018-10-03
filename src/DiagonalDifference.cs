namespace hackerrank_problems
{
    public class DiagonalDifference
    {
        private static int DiagonalDifference(int[][] a)
        {
            //entry point logic
            /*var testingArray = new []{new []{11, 2, 4}, new []{4, 5, 6}, new []{10, 8, -12}};
            var absoulteDifference = DiagonalDifference(testingArray);*/
            
            var aDiagonal = 0;
            var bDiagonal = 0;
            var arrayDimension = a.GetLength(0);
            
            for (var i = 0; i < arrayDimension; i++)
            {
                aDiagonal += a[i][i];
                bDiagonal += a[arrayDimension - (i + 1)][i];
            }

            return Math.Abs(aDiagonal - bDiagonal);
        }
    }
}