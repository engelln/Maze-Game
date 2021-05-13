public class CellEntry : MazeEntry
{
    private bool visited;
    private int x, y;


    public CellEntry(int x, int y)
    {
        visited = false;
        this.x = x;
        this.y = y;
    }

    public void visit()
    {
        visited = true;
    }

    public bool isVisited()
    {
        return visited;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }
}