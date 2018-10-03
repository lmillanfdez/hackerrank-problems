using System;
using System.Collections.Generic;

namespace hackerrank_problems
{
    public class ExtraLongFactorialsChallenge
    {
        public static void ExtraLongFactorials(int n)
        {
            //entry point logic
            //extraLongFactorials(30);
            var resultingString = "2";
            var index = 3;
            
            if (n == 1)
            {
                resultingString = "1";
            }
            else if(n == 2)
            {
                resultingString = "2";
            }
            else
            {
                while (index <= n)
                {
                    var indexToString = index.ToString();

                    resultingString = resultingString.Length >= indexToString.Length
                                            ? Multiplying2String(resultingString, indexToString)
                                                    : Multiplying2String(indexToString, resultingString);
                    index++;
                }
            }
            
            Console.WriteLine(resultingString);
        }

        //it assumes the firstOperand to be greater or equal in size than the secondOperand
        private static string Adding2String(string firstOperand, string secondOperand)
        {
            var resultingString = "";
            
            var remainder = 0;
            var i = 1;
            
            while (firstOperand.Length - i >= 0)
            {
                var resultingSum = remainder;

                if (i <= secondOperand.Length)
                    resultingSum += int.Parse(secondOperand[secondOperand.Length - i].ToString());

                resultingSum += int.Parse(firstOperand[firstOperand.Length - i].ToString());

                remainder = resultingSum / 10;
                var digit = resultingSum % 10;

                resultingString = digit + resultingString;

                i++;
            }
            
            if(remainder > 0)
                resultingString = remainder + resultingString;

            return resultingString;
        }

        //it assumes the first operand is greater in size than the second operand
        private static string Multiplying2String(string firstOperand, string secondOperand)
        {
            var sumOperators = new List<string>();
            
            for (int i = 0; i < secondOperand.Length; i++)
            {
                var remainder = 0;
                var tempString = "";
                
                for (int j = firstOperand.Length - 1; j >= 0; j--)
                {
                    var resultingProduct = int.Parse(secondOperand[i].ToString())
                                                        * int.Parse(firstOperand[j].ToString());

                    resultingProduct += remainder;

                    var digit = resultingProduct % 10;
                    remainder = resultingProduct / 10;

                    tempString = digit + tempString;
                }
                
                if(remainder > 0)
                    tempString = remainder + tempString;

                var posfix = new String('0', secondOperand.Length - i - 1);
                tempString += posfix;
                
                sumOperators.Add(tempString);
            }

            var tempResultingSum = "0";

            foreach (var number in sumOperators)
            {
                tempResultingSum = tempResultingSum.Length >= number.Length
                                        ? Adding2String(tempResultingSum, number)
                                            : Adding2String(number, tempResultingSum);
            }
            
            return tempResultingSum;
        }
    }
}