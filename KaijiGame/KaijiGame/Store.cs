using System;
using KaijiGame;

namespace KaijiGame
{
    public class Store
    {
        private Room currentRoom;
        private Kaiji player;
        private TradeChar trader;

        public Store(Room currentRoom, Kaiji player)
        {
            this.currentRoom = currentRoom;
            this.player = player;
        }

        public void BuyCards(CardColor cardColor, int count)
        {
            int tradeRatio = currentRoom.TradeComponent.GetTradeRatio(cardColor);
            string tradeFor = currentRoom.TradeComponent.GetTradeFor(cardColor);

            int totalTradeCount = count * tradeRatio;

            if (player.CardComponent.GetCardCount(tradeFor) < totalTradeCount)
            {
                Console.WriteLine($"Not enough {tradeFor} cards to complete the trade.");
                return;
            }

            player.CardComponent.RemoveCard(cardColor, count);
            player.CardComponent.AddCard(tradeFor, totalTradeCount);
        }
    }
}
