using System;
namespace KaijiGame
{

    public class EnemyChar
    {
        private int stars;
        private int choices;
        private int wins;
        private int losses;
        private int ties;
        Kaiji player;
        Scoreboard scoreboard;
        Match match;

        public EnemyChar(int stars, int choices, Scoreboard scoreboard, Match match)
        {
            this.stars = stars;
            this.choices = choices;
            this.match = match;
            this.scoreboard = scoreboard;
        }

        public void PlayRound(Match match)
        {
            string playerChoice = GetPlayerChoice();
            string enemyChoice = GetEnemyChoice();
            UpdateScore(playerChoice, enemyChoice);
            PrintResult(playerChoice, enemyChoice);

        }

        public string GetPlayerChoice(Scoreboard scoreboard)
        {
            // Get the most used card by the player from the scoreboard
            string mostUsedCard = scoreboard.GetMostUsedCard();

            // Determine the card that beats the most used card
            string enemyChoice = (mostUsedCard + 1) % 3;

            return enemyChoice;
        }

        public string GetEnemyChoice(string playerChoice)
        {
            if (playerChoice == "rock")
            {
                return "paper";
            }
            else if (playerChoice == "paper")
            {
                return "scissors";
            }
            else // playerChoice == "scissors"
            {
                return "rock";
            }
        }


        private void UpdateScore(int playerChoice, int enemyChoice)
        {
            if (playerChoice == enemyChoice)
            {
                ties++;
            }
            else if ((playerChoice == 0 && enemyChoice == 2) ||
                     (playerChoice == 1 && enemyChoice == 0) ||
                     (playerChoice == 2 && enemyChoice == 1))
            {
                wins++;
            }
            else
            {
                losses++;
            }
        }

        private void PrintResult(string playerChoice, string enemyChoice)
        {
            // Code to print result of match
        }

        public int GetStars()
        {
            return stars;
        }

        public void SetStars(int stars)
        {
            this.stars = stars;
        }

        public int GetChoices()
        {
            return choices;
        }
       

        public void SetChoices(int choices)
        {
            this.choices = choices;
        }

        public int GetWins()
        {
            return wins;
        }

        public int GetLosses()
        {
            return losses;
        }

        public int GetTies()
        {
            return ties;
        }
    }
}