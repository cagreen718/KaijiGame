using System;
using System.Collections.Generic;


namespace KaijiGame
{

    public class Kaiji : IPlayableChar
    {
        int stars;
        string choices;
        List<CardColor> cards;
        Match match;
        Scoreboard scoreboard;

        public Kaiji(int stars, Match match, List<CardColor> cards, string choices, Scoreboard scoreboard)
        {
            this.stars = stars;
            this.choices = choices;
            this.cards = new List<CardColor>();
            this.match = new Match();
            this.scoreboard = new Scoreboard();
        }

        public void AddStar()
        {
            this.stars++;
        }

        public void RemoveStar()
        {
            this.stars--;
        }

        public int GetStarCount()
        {
            return this.stars;
        }

        public void AddCard(CardColor cards)
        {
            this.cards.Add(cards);
        }

        public void RemoveCard(CardColor cards)
        {
            this.cards.Remove(cards);
        }

        public List<CardColor> Getcards()
        {
            return this.cards;
        }

        public string ChooseCard(int stars)
        {
            // Get the player's most used card from the scoreboard
            Scoreboard scoreboard = new Scoreboard();
            int UsedCard = scoreboard.GetMostUsedCard();

            // Determine the available card choices based on the number of stars
            string[] availableCards;
            if (stars >= 3)
            {
                availableCards = new string[] { "rock", "paper", "scissors", "spock", "lizard" };
            }
            else if (stars == 2)
            {
                availableCards = new string[] { "rock", "paper", "scissors", "spock" };
            }
            else if (stars == 1)
            {
                availableCards = new string[] { "rock", "paper", "scissors" };
            }
            else
            {
                availableCards = new string[] { "rock" };
            }

            // Choose a card that beats the player's most used card, if possible
            string chosenCard = "";
            foreach (string card in availableCards)
            {
                if (Match.GetWinner(mostUsedCard, card) == Match.Winner.Player2)
                {
                    chosenCard = card;
                    break;
                }
            }

            // If there is no available card that beats the player's most used card, choose a random card
            if (chosenCard == "")
            {
                Random rand = new Random();
                int index = rand.Next(availableCards.Length);
                chosenCard = availableCards[index];
            }

            return chosenCard;
        }


        public void PlayMatch(Kaiji player, EnemyChar enemy, Match match)
        {
            while (this.stars > 0 && enemy.GetStarCount() > 0)
            {
                CardColor kaijiCard = player.ChooseCard();
                CardColor enemyCard = enemy.ChooseCard();

                int result = this.match.PlayRound(kaijiCard, enemyCard);

                if (result == 1)
                {
                    enemy.RemoveStar();
                }
                else if (result == -1)
                {
                    this.RemoveStar();
                }
            }

            // Code to handle end of match
        }
    }
}