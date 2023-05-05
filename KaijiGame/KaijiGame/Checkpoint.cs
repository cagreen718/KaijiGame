public class Checkpoint
{
    private int _stars;
    private IRoomComponent _currentRoom;

    public Checkpoint(int stars, IRoomComponent currentRoom)
    {
        _stars = stars;
        _currentRoom = currentRoom;
    }

    public int Stars
    {
        get { return _stars; }
        set { _stars = value; }
    }

    public IRoomComponent CurrentRoom
    {
        get { return _currentRoom; }
        set { _currentRoom = value; }
    }

    public void Save()
    {
        Console.WriteLine("Game saved at current checkpoint.");
    }

    public static bool Load(string cheatCode, out Checkpoint checkpoint)
    {
        if (cheatCode == "zuwa zuwa")
        {
            checkpoint = new Checkpoint(0, null);
            Console.WriteLine("Game loaded from last checkpoint.");
            return true;
        }
        else
        {
            checkpoint = null;
            return false;
        }
    }
}