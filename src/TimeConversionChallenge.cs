using System;

namespace hackerrank_problems
{
    public class TimeConversionChallenge
    {
        public static string TimeConversion(string s)
        {
            //entry point
            /*var dateInString = "12:00:00AM";
            var dateInMilitaryFormat = timeConversion(dateInString);
            
            Console.WriteLine(dateInMilitaryFormat);*/
            
            DateTime date = DateTime.Parse(s);
            var result = date.ToString("H:mm:ss");
            
            return result;
        }
    }
}