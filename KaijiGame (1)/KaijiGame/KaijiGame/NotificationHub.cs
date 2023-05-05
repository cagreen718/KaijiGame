using System;

public class NotificationHub : IObserver<Notification>
{
    private IDisposable _unsubscriber;

    public void Subscribe(IObservable<Notification> provider)
    {
        if (provider != null)
        {
            _unsubscriber = provider.Subscribe(this);
        }
    }

    public void Unsubscribe()
    {
        _unsubscriber.Dispose();
    }

    public void OnCompleted()
    {
        Console.WriteLine("Notification Hub: Completed");
        Unsubscribe();
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"Notification Hub: Error - {error.Message}");
    }

    public void OnNext(Notification notification)
    {
        Console.WriteLine($"Notification Hub: {notification.GetMessage()}");
    }
}