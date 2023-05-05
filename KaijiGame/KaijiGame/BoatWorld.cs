public class BoatWorld
{
    private Room currentRoom;
    private Kaiji player;
    private NotificationHub hub;

    public BoatWorld()
    {
        hub = new NotificationHub();
        currentRoom = new RoomOne(hub);
        player = new player(0, 0, hub);
    }

    public void Start()
    {
        hub.Notify("You are on a boat. There are three rooms.");

        while (true)
        {
            // Display current room and prompt for input
            hub.Notify(currentRoom.ToString());
            hub.Notify("Enter 'move', 'trade', or 'play'");

            // Get user input and handle it based on current room
            string input = Console.ReadLine();
            if (input.Equals("move"))
            {
                // Move to the next room and update currentRoom and player
                currentRoom = currentRoom.NextRoom(hub);
                player = new Kaiji(0, 0, hub);
            }
            else if (input.Equals("trade"))
            {
                // Trade with the trade char in the current room
                TradeChar tradeChar = currentRoom.GetTradeChar();
                if (tradeChar != null)
                {
                    player.Trade(tradeChar);
                }
                else
                {
                    hub.Notify("There is no one to trade with in this room.");
                }
            }
            else if (input.Equals("play"))
            {
                // Play a match with the enemy char in the current room
                EnemyChar enemyChar = currentRoom.GetEnemyChar();
                if (enemyChar != null)
                {
                    player.PlayMatch(enemyChar);
                }
                else
                {
                    hub.Notify("There is no one to play a match with in this room.");
                }
            }
            else
            {
                // Invalid input
                hub.NotifyError("Invalid input.");
            }

            // Check if player has enough stars to move to the next room
            if (currentRoom is RoomThree && player.GetStarCount() >= 1)
            {
                hub.Notify("You have collected enough stars to move to the next room!");
                break;
            }
        }
    }
}