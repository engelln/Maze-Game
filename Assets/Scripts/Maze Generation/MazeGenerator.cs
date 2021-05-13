using System;
using System.Collections.Generic;

public class MazeGenerator
{
    private MazeEntry[,] maze;
    private CellEntry[,] cells;
    private int x, y;
    private Random rng = new Random();


    public Maze createMaze(int x, int y)
    {
        this.x = x;
        this.y = y;
        cells = new CellEntry[x, y];
        maze = createTemplate((2 * x + 1), (2 * y + 1));
        generate();
        ((WallEntry)maze[(2 * x + 1) / 2,0]).deactivate();
        ((WallEntry)maze[(2 * x + 1) / 2,(2 * y + 1) - 1]).deactivate();
        return new Maze(maze);
    }

    private void generate()
    {
        Stack<CellEntry> stack = new Stack<CellEntry>();
        CellEntry current = cells[x / 2,0];
        current.visit();
        while (areUnvisitedCells())
        {
            List<CellEntry> currentNeighbors = getUnvisitedNeighbors(current);
            if (currentNeighbors.Count != 0)
            {
                CellEntry chosenNeighbor = currentNeighbors[rng.Next(currentNeighbors.Count)];
                stack.Push(current);
                removeWall(current, chosenNeighbor);
                current = chosenNeighbor;
                current.visit();
            }
            else if (stack.Count != 0)
            {
                current = stack.Pop();
            }

        }
    }

    private void removeWall(CellEntry a, CellEntry b)
    {
        int wallX = (a.getX() + b.getX()) / 2;
        int wallY = (a.getY() + b.getY()) / 2;
        WallEntry wall = (WallEntry)maze[wallX,wallY];
        wall.deactivate();

    }

    private bool areUnvisitedCells()
    {
        foreach (CellEntry c in cells)
        {
            if (!c.isVisited())
            {
                return true;
            }
            
        }
        return false;
    }

    public List<CellEntry> getNeighbors(CellEntry c)
    {
        int cellX = (c.getX() - 1) / 2;
        int cellY = (c.getY() - 1) / 2;
        List<CellEntry> neighbors = new List<CellEntry>();
        if (!(cellY + 1 >= y))
        {
            neighbors.Add(cells[cellX,cellY + 1]);
        }
        if (!(cellY - 1 < 0))
        {
            neighbors.Add(cells[cellX,cellY - 1]);
        }
        if (!(cellX + 1 >= x))
        {
            neighbors.Add(cells[cellX + 1,cellY]);
        }
        if (!(cellX - 1 < 0))
        {
            neighbors.Add(cells[cellX - 1,cellY]);
        }
        return neighbors;
    }

    public List<CellEntry> getUnvisitedNeighbors(CellEntry c)
    {
        List<CellEntry> neighbors = getNeighbors(c);
        List<CellEntry> unvisitedNeighbors = new List<CellEntry>();
        foreach (CellEntry neighbor in neighbors)
        {
            if (!neighbor.isVisited())
            {
                unvisitedNeighbors.Add(neighbor);
            }
        }
        return unvisitedNeighbors;
    }

    public MazeEntry[,] createTemplate(int x, int y)
    {
        MazeEntry[,] maze = new MazeEntry[x,y];

        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (i == 0 || j == 0)
                {
                    maze[i,j] = new WallEntry();
                }
                else if (i % 2 != 0 && j % 2 != 0)
                {
                    CellEntry c = new CellEntry(i, j);
                    maze[i,j] = c;
                    cells[(i - 1) / 2,(j - 1) / 2] = c;
                }
                else
                {
                    maze[i,j] = new WallEntry();
                }
            }
        }
        return maze;
    }
}
