public class WallEntry : MazeEntry
{
    private bool active;


    public WallEntry()
    {
        active = true;
    }

    public void deactivate()
    {
        active = false;
    }

    public bool isActive()
    {
        return active;
    }
}