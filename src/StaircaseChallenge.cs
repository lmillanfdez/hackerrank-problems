using System;

namespace hackerrank_problems
{
    public class StaircaseChallenge
    {
        public static void Staircase(int n)
        {
            //entry point logic
            /*var n = 10;
            staircase(n);*/
            
            const char SPACE_CHARACTER = ' ';
            const char NUMBER_CHARACTER = '#';
            
            for (var i = n; i > 0; i--)
            {
                var stringWithSpaces = new String(SPACE_CHARACTER, i - 1);
                var stringWithNumberCharacter = new String(NUMBER_CHARACTER, n - i + 1);
                
                Console.WriteLine(String.Concat(stringWithSpaces, stringWithNumberCharacter));
            }
        }
    }
}