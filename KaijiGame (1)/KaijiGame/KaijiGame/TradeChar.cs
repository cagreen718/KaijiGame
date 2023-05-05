using System;
namespace KaijiGame
{

    public class TradeChar
    {
        private readonly List<CardColor> _cards;
        private readonly string _name;
        private readonly Dictionary<CardColor, int> _tradeRatios;

        public TradeChar(string name, List<CardColor> cards, Dictionary<CardColor, int> tradeRatios)
        {
            _name = name;
            _cards = cards;
            _tradeRatios = tradeRatios;
        }

        public int GetCardCount(CardColor color)
        {
            int count = 0;
            foreach (CardColor card in _cards)
            {
                if (card == color)
                {
                    count++;
                }
            }
            return count;
        }

        public bool RemoveCard(CardColor color)
        {
            foreach (CardColor card in _cards)
            {
                if (card == color)
                {
                    _cards.Remove(card);
                    return true;
                }
            }
            return false;
        }

        public string GetName()
        {
            return _name;
        }

        public Dictionary<CardColor, int> GetTradeFor(CardColor color)
        {
            var tradeFor = new Dictionary<CardColor, int>();
            foreach (var tradeRatio in _tradeRatios)
            {
                if (tradeRatio.Key != color)
                {
                    int cardsNeeded = tradeRatio.Value / _tradeRatios[color];
                    tradeFor[tradeRatio.Key] = cardsNeeded;
                }
            }
            return tradeFor;
        }

        public void AddCard(CardColor card)
        {
            _cards.Add(card);
        }

        public Dictionary<CardColor, int> GetTradeRatio()
        {
            return _tradeRatios;
        }
    }
}