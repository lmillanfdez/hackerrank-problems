using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems;

public class ComponentsInAGraph
{
    public static List<int> componentsInGraph(List<List<int>> gb)
    {
        var edges = new Dictionary<int, List<int>>();
        
        foreach(var item in gb)
        {
            if(edges.TryGetValue(item[0], out List<int> fValue))
                fValue.Add(item[1]);
            else
                edges.Add(item[0], new List<int>(){ item[1] });
                
            if(edges.TryGetValue(item[1], out List<int> sValue))
                sValue.Add(item[0]);
            else
                edges.Add(item[1], new List<int>(){ item[0] });
        }
        
        var visited = new Dictionary<int, bool>();
        var result = new int[2];
        
        foreach(var key in edges.Keys)
        {
            var size = DFS(key, edges, visited);
            
            if(size > 1)
            {
                if(result[0] == 0 && result[1] == 0)
                {
                    result[0] = size;
                    result[1] = size;
                }
                
                if(size < result[0])
                    result[0] = size;
                else if(size > result[1])
                    result[1] = size;
            }
        }
        
        return result.ToList();
    }
    
    private static int DFS(int key, Dictionary<int, List<int>> edges, 
                        Dictionary<int, bool> visited)
    {
        if(visited.TryGetValue(key, out bool value))
            return 0;
            
        visited.Add(key, true);
        edges.TryGetValue(key, out List<int> nodes);
        
        int size = 0;
        
        foreach(var item in nodes)
            size += DFS(item, edges, visited);
            
        return size + 1;
    }
}