using KaijiGame;
using System;

public class Match
{
    int numRounds = 1;
    int playerWins = 0;
    int enemyWins = 0;
    EnemyChar enemy;
    Kaiji player;

    public Match(Kaiji player, EnemyChar enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }

    public void PlayRound()
    {
        // Get player and enemy choices
        int playerChoice = player.ChooseCard();
        int enemyChoice = enemy.ChooseCard();

        // Determine round outcome
        if (playerChoice == enemyChoice)
        {
            Console.WriteLine("Tie round!");
        }
        else if ((playerChoice == "rock" && enemyChoice == "scissors") ||
                 (playerChoice == "scissors" && enemyChoice == "paper") ||
                 (playerChoice == "paper" && enemyChoice == "rock"))
        {
            Console.WriteLine("Player wins round!");
            playerWins++;
        }
        else
        {
            Console.WriteLine("Enemy wins round!");
            enemyWins++;
        }

        // Check if match is over
        if (playerWins >= numRounds || enemyWins >= numRounds)
        {
            EndMatch();
        }
    }

    private void EndMatch()
    {
        Console.WriteLine("Match over!");

        // Determine match outcome
        if (playerWins > enemyWins)
        {
            Console.WriteLine("Player wins match!");
            player.AddStar();
        }
        else if (enemyWins > playerWins)
        {
            Console.WriteLine("Enemy wins match!");
            enemy.AddStar();
        }
        else
        {
            Console.WriteLine("Match is a tie!");
        }

        // Increase difficulty for next match
        numRounds++;
        player.ResetChoices();
        enemy.ResetChoices();
    }
}
