public class Notification
{
    private readonly string _message;

    public Notification(string message)
    {
        _message = message;
    }

    public string GetMessage()
    {
        return _message;
    }
}