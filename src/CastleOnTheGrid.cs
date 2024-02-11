using System;
using System.Collections.Generic;
using System.Linq;

namespace hackerrank_problems;

public class CastleOnTheGrid
{
    public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
    {
        var cellsToVisit = new Queue<Cell>();
        var visited = new Dictionary<string, Cell>();
        
        var initialCell = new Cell
        {
            X = startX,
            Y = startY,
            DiscoveredFrom = Direction.None,
            Distance = 0
        };
        
        cellsToVisit.Enqueue(initialCell);
        visited.Add($"{startX},{startY}", initialCell);
        
        while(cellsToVisit.TryDequeue(out Cell result))
        {
            if(result.X == goalX && result.Y == goalY)
                return result.Distance;

            if(result.MustAnalyze)
            {
                var axis = GetAxisFromCell(result);
            
                foreach(var item in axis)
                    AddRecheableCells(item, result, grid, cellsToVisit, visited);
            }
        }
        
        return -1;
    }
    
    private static void AddRecheableCells(Axis axis, Cell cell, List<string> grid, 
                                        Queue<Cell> cellsToVisit, Dictionary<string, Cell> visited)
    {
        int x, y;
        int dimension = grid.Count();
        bool canGoNegative = true, canGoPositive = true;
        
        var positionMapper = GetPositionMapper(axis, cell, grid, dimension);
        
        for(int i = 1; i < dimension; i++)
        {
            if(canGoNegative)
            {
                (x, y) = positionMapper(-i);
                
                if(x < 0)
                    canGoNegative = false;
                else
                {
                    if(visited.TryGetValue($"{x},{y}", out Cell visitedCell))
                    {
                        if((axis == Axis.Vertical && (visitedCell.DiscoveredFrom == Direction.Left || visitedCell.DiscoveredFrom == Direction.Right))
                            || (axis == Axis.Horizontal && (visitedCell.DiscoveredFrom == Direction.Up || visitedCell.DiscoveredFrom == Direction.Down)))
                            visitedCell.MustAnalyze = false;
                    }
                    else
                    {
                        var newCell = new Cell { X = x, Y = y, 
                                DiscoveredFrom = axis == Axis.Vertical ? Direction.Down : Direction.Right, Distance = cell.Distance + 1};
                                    
                        cellsToVisit.Enqueue(newCell);
                        visited.Add($"{x},{y}", newCell);
                    }
                }
            }
            
            if(canGoPositive)
            {
                (x, y) = positionMapper(i);
                
                if(x < 0)
                    canGoPositive = false;
                else
                {
                    if(visited.TryGetValue($"{x},{y}", out Cell visitedCell))
                    {
                        if((axis == Axis.Vertical && (visitedCell.DiscoveredFrom == Direction.Left || visitedCell.DiscoveredFrom == Direction.Right))
                            || (axis == Axis.Horizontal && (visitedCell.DiscoveredFrom == Direction.Up || visitedCell.DiscoveredFrom == Direction.Down)))
                            visitedCell.MustAnalyze = false;
                    }
                    else
                    {
                        var newCell = new Cell { X = x, Y = y, 
                                DiscoveredFrom = axis == Axis.Vertical ? Direction.Up : Direction.Left, Distance = cell.Distance + 1};
                                    
                        cellsToVisit.Enqueue(newCell);
                        visited.Add($"{x},{y}", newCell);
                    }
                }
            }
        }
    }
    
    private static Func<int, (int, int)> GetPositionMapper(Axis axis, Cell cell, List<string> grid, 
                                                            int dimension)
    {
        Func<int, (int, int)> positionMapper = axis switch
        {
            Axis.Vertical => (int i) => cell.X + i >= 0 && cell.X + i < dimension  
                                            && grid[cell.X + i][cell.Y] != 'X'
                                        ? (cell.X + i, cell.Y) : (-1, -1),
            Axis.Horizontal => (int i) => cell.Y + i >= 0 && cell.Y + i < dimension  
                                            && grid[cell.X][cell.Y + i] != 'X'
                                        ? (cell.X, cell.Y + i) : (-1, -1),
            _ => throw new InvalidOperationException()
        };
        
        return positionMapper;
    }
    
    private static IEnumerable<Axis> GetAxisFromCell(Cell cell)
    {
        var axis = new List<Axis>();
        
        switch(cell.DiscoveredFrom)
        {
            case Direction.Up:
            case Direction.Down:
                axis.Add(Axis.Horizontal);
                break;
            case Direction.Left:
            case Direction.Right:
                axis.Add(Axis.Vertical);
                break;
            case Direction.None:
                axis.Add(Axis.Horizontal);
                axis.Add(Axis.Vertical);
                break;
            default:
                throw new InvalidOperationException();
        }
        
        return axis;
    }
}

enum Direction { Up, Down, Left, Right, None };
enum Axis { Horizontal, Vertical };

class Cell
{
    public int X {get; set;}
    public int Y {get; set;}
    public Direction DiscoveredFrom {get; set;}
    public int Distance {get; set;}
    public bool MustAnalyze {get; set;} = true;
}