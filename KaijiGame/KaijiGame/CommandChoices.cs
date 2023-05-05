using System;
using System.Collections.Generic;
namespace KaijiGame
{
    public class CommandChoices
    {
        private Dictionary<string, string> choices;

        public CommandChoices()
        {
            choices = new Dictionary<string, string>();
            choices.Add("move", "Moves the player to a different room.");
            choices.Add("trade", "Opens the trading menu with a trader in the room.");
            choices.Add("play", "Starts a game with an enemy in the room.");
            choices.Add("quit", "Quits the game.");
        }

        public string GetDescription(string command)
        {
            if (choices.ContainsKey(command))
            {
                return choices[command];
            }
            else
            {
                return "Unknown command.";
            }
        }
    }
}