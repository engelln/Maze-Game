using UnityEngine;

public class Maze
{
    private CellType[,] maze;


    public Maze(MazeEntry[,] cells)
    {
        maze = new CellType[cells.GetLength(0), cells.GetLength(1)];
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if(cells[i,j].GetType() == typeof(CellEntry) || (cells[i, j].GetType() == typeof(WallEntry) && !((WallEntry)cells[i, j]).isActive()))
                {
                    maze[i, j] = CellType.Open;
                }
                else
                {
                    maze[i, j] = CellType.Closed;
                }
            }
        }
    }

    public CellType[,] getArray()
    {
        return maze;
    }


}
