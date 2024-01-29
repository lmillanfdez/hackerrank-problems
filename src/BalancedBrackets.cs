using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace hackerrank_problems;

public class BalancedBrackets
{
    public static string isBalanced(string s)
    {
        var bracketStack = new Stack<char>();
        var openBracket = new Regex(@"[({\[]");
        var closeBracket = new Regex(@"[)}\]]");
        
        foreach(char c in s)
        {
            if(openBracket.IsMatch(c.ToString()))
                bracketStack.Push(c);
            else
            {
                if(!bracketStack.TryPop(out char result))
                    return "NO";
                    
                var invertedBracket = result switch
                {
                    '{' => '}',
                    '[' => ']',
                    '(' => ')',
                    _ => '\0'        
                };
                
                if(invertedBracket != c)
                    return "NO";
            }
        }
        
        if(bracketStack.TryPeek(out char sResult))
            return "NO";
            
        return "YES";
    }
}