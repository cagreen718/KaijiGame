using System;
using System.Collections.Generic;


namespace KaijiGame
{

    

    public class Command
    {
        public void ExecuteMove(Kaiji player, int direction)
        {
            if (player.CurrentRoom.HasDoor(direction))
            {
                if (player.CurrentRoom.GetDoor(direction).IsLocked())
                {
                    Console.WriteLine("The door is locked! You need a star to unlock it.");
                }
                else
                {
                    player.Move(direction);
                }
            }
            else
            {
                Console.WriteLine("There is no door in that direction!");
            }
        }

        public void ExecuteTrade(Kaiji player, Item itemToTrade)
        {
            if (player.CurrentRoom.HasTrader())
            {
                TradeChar trader = player.CurrentRoom.GetTrader();

                if (trader.HasItem(itemToTrade))
                {
                    if (player.HasItem(trader.GetItemValue(itemToTrade)))
                    {
                        player.RemoveItem(trader.GetItemValue(itemToTrade));
                        player.AddItem(itemToTrade);
                        trader.RemoveItem(itemToTrade);
                        trader.AddItem(trader.GetItemValue(itemToTrade));
                        Console.WriteLine("You traded {0} for {1}.", trader.GetItemValue(itemToTrade).Name, itemToTrade.Name);
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold to buy that item.");
                    }
                }
                else
                {
                    Console.WriteLine("The trader doesn't have that item.");
                }
            }
            else
            {
                Console.WriteLine("There is no trader in this room.");
            }
        }

        public void ExecutePlay(Kaiji player, EnemyChar enemy)
        {
            Match game = new Match(player, enemy);
            Match.Play();
        }
    }
}