using System;


namespace KaijiGame
{ //flywieght for cards
    public enum CardColorName
    {
        Red,
        Blue,
        Green,
        Yellow
    }
    public class CardColor 
    {
        private CardColorName colorName;
        private int cardCount;

        public CardColor(CardColorName name, int count)
        {
            colorName = name;
            cardCount = count;
        }

        public int GetCardCount()
        {
            return cardCount;
        }

        public void RemoveCard()
        {
            if (cardCount > 0)
            {
                cardCount--;
            }
        }

        public string GetName()
        {
            return colorName.ToString();
        }

        public CardColor GetCardColorByName(string name)
        {
            try
            {
                CardColorName color = (CardColorName)Enum.Parse(typeof(CardColorName), name, true);
                return new CardColor(color, 0);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public double GetTradeRatio(CardColor otherColor)
        {
            if (cardCount == 0 || otherColor.cardCount == 0)
            {
                return 0;
            }
            double ratio = (double)cardCount / otherColor.cardCount;
            return Math.Round(ratio, 2);
        }

        public CardColor GetTradeFor(CardColor otherColor)
        {
            if (cardCount == 0 || otherColor.cardCount == 0)
            {
                return null;
            }
            double ratio = GetTradeRatio(otherColor);
            if (ratio >= 1)
            {
                return new CardColor(colorName, (int)Math.Floor(ratio));
            }
            else
            {
                return new CardColor(colorName, 1);
            }
        }

        public void AddCard()
        {
            cardCount++;
        }

        public CardColorName GetColor()
        {
            return colorName;
        }
    }
}