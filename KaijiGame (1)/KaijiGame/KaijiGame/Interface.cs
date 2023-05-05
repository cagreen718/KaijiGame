using KaijiGame;
using System;

namespace YourNamespace
{
    // Interface for any component that can be traded
    public interface ITradeComponent
    {
        string GetName();
        int GetCardCount();
        CardColor GetColor();
        CardColor GetTradeFor();
        float GetTradeRatio();
        void AddCard(CardColor card);
        bool RemoveCard(CardColor card);
        CardColor GetCardByName(string name);
        CardColor GetCardByIndex(int index);
        int GetIndexOfCard(CardColor card);
    }
    public interface ICardColor
    {
        string GetName();
        string GetColor();
    }


    // Interface for any component that can play Rock-Paper-Scissors
    public interface IPlayable
    {
        string GetName();
        int GetWins();
        int GetLosses();
        int GetTies();
        void AddWin();
        void AddLoss();
        void AddTie();
        void ResetScore();
        CardColor Play();
    }

    // Interface for any component that can be observed
    public interface IObserver
    {
        void Update(Notification notification);
    }

    // Interface for any component that can be observed
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(Notification notification);
    }

    // Class representing a notification
    public class Notification
    {
        public string Text { get; }

        public Notification(string text)
        {
            Text = text;
        }
    }

    // Interface for the game clock
    public interface IGameClock
    {
        float GetTime();
        void Pause();
        void Resume();
    }

    // Interface for the command words
    public interface ICommandWords
    {
        string Move { get; }
        string Trade { get; }
        string Play { get; }
        string Exit { get; }
        string Help { get; }
    }

    // Interface for the components of the game world
    public interface IGameComponent
    {
        string Name { get; }
        EnemyChar enemy { get; }
        TradeChar trader { get; }
        Door door { get; }
        void Enter();
        void Exit();
    }

    // Interface for the rooms
    public interface IRoom : IGameComponent
    {
        
        bool HasEnemy();
        bool HasTrader();
    }
    public interface IRoomComponent
    {
        void Enter();
        void Leave();
    }

    // Interface for the doors
    public interface IDoor : IGameComponent
    {
        bool CanEnter();
    }

    // Interface for the commands
    public interface ICommand : IGameComponent
    {
        void Execute();
        bool IsValid();
    }

    // Interface for the characters that can trade
    public interface ITradeable : IGameComponent, ITradeComponent
    {
        int GetCardCount();
        void RemoveCard(string cardName);
        string GetName();
        bool GetTradeFor(string cardName, out string tradeCard);
        void AddCard(string cardName);
        double GetTradeRatio(string cardName);
    }

    // Interface for the characters that can play Rock-Paper-Scissors
    public interface IPlayableChar : IGameComponent, IPlayable
    {
        string ChooseCard();
        void RemoveStar();
        void GetStarCount();
        void AddCard();
        void RemoveCard();
        void PlayMatch(Match match);
        void AddStar();
        void ResetChoices();
    }

    // Interface for the characters that can be observed
    public interface IObservableChar : IGameComponent, ISubject
    {
    }

    // Interface for the characters that can trade and play Rock-Paper-Scissors
    public interface ITradeAndPlayableChar : IGameComponent, ITradeable, IPlayableChar
    {
        void Trade(ITradeableChar target);
    }

    // Interface for the game world
    public interface IGameWorld : IGameComponent
    {
        void Start();
    }
}