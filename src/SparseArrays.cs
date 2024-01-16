using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems;

public class SparseArrays
{
    public static List<int> MatchingStrings(List<string> stringList, List<string> queries)
    {
        var dict = new Dictionary<string, int>();
        
        foreach(var item in stringList)
        {
            if(dict.ContainsKey(item))
                dict[item] += 1;
            else
                dict.Add(item, 1);
        }
        
        var result = queries.Select((item, _) => dict.ContainsKey(item) ? dict[item] : 0);
        
        return result.ToList();
    }
}