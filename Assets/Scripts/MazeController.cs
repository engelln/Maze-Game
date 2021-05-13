using System;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public int x, y;
    public GameObject wall;

    private MazeGenerator mazeGenerator;
    private Maze currentMaze;


	private void Start()
	{
        mazeGenerator = new MazeGenerator();
        currentMaze = mazeGenerator.createMaze(x, y);
        drawMaze();
	}

    private void drawMaze()
    {
        CellType[,] mazeGrid = currentMaze.getArray();
        for (int i = 0; i < mazeGrid.GetLength(0); i++)
        {
            for (int j = 0; j < mazeGrid.GetLength(1); j++)
            {
                if (mazeGrid[i,j] == CellType.Closed)
                {
                    Instantiate(wall, new Vector3(i - x, -j, 0), Quaternion.identity);
                }
            }
        }
    }

    public Maze getMaze()
    {
        return currentMaze;
    }
}
