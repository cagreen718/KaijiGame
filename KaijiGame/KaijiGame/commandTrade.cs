using System;
using System.Numerics;
using System.Windows.Input;
using static System.Formats.Asn1.AsnWriter;

namespace KaijiGame
{

    public class commandTrade : Command
    {
        private Room room;
        private TradeChar tradeChar;
        private Kaiji player;

        public commandTrade(Room room, TradeChar tradeChar, Kaiji player)
        {
            this.room = room;
            this.player = player;
            this.tradeChar = tradeChar;
        }

        public void Execute(string input, Kaiji player)
        {
            if (input.ToLower() == "trade")
            {
                room.SetState(new Store(tradeChar));
            }
            else
            {
                Console.WriteLine("Invalid command. Type 'trade' to open the store.");
            }
        }
    }
}