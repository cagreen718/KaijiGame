using System;
using System.Collections.Generic;
using System.Linq;
namespace KaijiGame
{

    public class Scoreboard
    {
        private int highScore;
        private TimeSpan timeToBeat;
        private Dictionary<string, int> cardUsage;
        public int[] CardCount { get; set; }

        public Scoreboard()
        {
            highScore = 0;
            timeToBeat = TimeSpan.MaxValue;
            cardUsage = new Dictionary<string, int>();
            CardCount = new int[3];
        }

        public int HighScore
        {
            get { return highScore; }
        }

        public TimeSpan TimeToBeat
        {
            get { return timeToBeat; }
        }


        public void Update(int score, TimeSpan time, string mostUsedCard)
        {
            if (score > highScore)
            {
                highScore = score;
            }

            if (time < timeToBeat)
            {
                timeToBeat = time;
            }

            if (cardUsage.ContainsKey(mostUsedCard))
            {
                cardUsage[mostUsedCard]++;
            }
            else
            {
                cardUsage.Add(mostUsedCard, 1);
            }
        }
        public int GetMostUsedCard()
        {
            int mostUsedCard = -1;
            int maxCount = 0;

            for (int i = 0; i < CardCount.Length; i++)
            {
                if (CardCount[i] > maxCount)
                {
                    mostUsedCard = i;
                    maxCount = CardCount[i];
                }
            }

            return mostUsedCard;
        }
            public void Display()
        {
            Console.WriteLine("High Score: {0}", highScore);
            Console.WriteLine("Time to Beat: {0}", timeToBeat);
            Console.WriteLine("Most Used Card: {0}", cardUsage.OrderByDescending(x => x.Value).First().Key);
        }
    }
}