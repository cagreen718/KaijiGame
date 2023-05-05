using System;
using System.Collections.Generic;
using System.Numerics;


namespace KaijiGame
{
    public class Parser
    {
        private Kaiji player;
        private BoatWorld boatWorld;
        private Match game;

        public Parser()
        {
            // Initialize the player, boat world, and game objects
            player = new Kaiji();
            boatWorld = new BoatWorld(player);
            game = new Match(player, boatWorld.GetEnemy());
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the game! Type 'help' for a list of available commands.");

            while (true)
            {
                // Read the user's input
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();

                // Parse the user's input into a command and its arguments
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts.Length > 0 ? parts[0] : "";
                string[] args = parts.Length > 1 ? new ArraySegment<string>(parts, 1, parts.Length - 1).ToArray() : new string[0];

                // Execute the command
                switch (command)
                {
                    case "help":
                        PrintHelp();
                        break;
                    case "move":
                        boatWorld.ExecuteCommand(new CommandMove(args));
                        break;
                    case "trade":
                        boatWorld.ExecuteCommand(new commandTrade(args));
                        break;
                    case "play":
                        game.ExecuteCommand(new CommandJanken(args));
                        break;
                    case "quit":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Type 'help' for a list of available commands.");
                        break;
                }
            }
        }

        private void PrintHelp()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("  help          - Displays this help message");
            Console.WriteLine("  move <room>   - Moves to the specified room (1, 2, or 3)");
            Console.WriteLine("  trade <card>  - Trades the specified card with the enemy");
            Console.WriteLine("  play          - Plays rock-paper-scissors against the enemy");
            Console.WriteLine("  quit          - Exits the game");
        }
    }
}