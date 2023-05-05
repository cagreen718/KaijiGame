using System.Numerics;
using System.Windows.Input;

namespace KaijiGame
{
   

    public class CommandMove : Command
    {
        private readonly IObserver _observer;

        public CommandMove(IObserver observer)
        {
            _observer = observer;
        }

        public void Execute(string[] args)
        {
            if (args.Length != 1 || args[0] != "move")
            {
                _observer.Notify("Invalid input. Please enter 'move'.");
                return;
            }

            // Code to handle moving to the next room
        }
    }
}