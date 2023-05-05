using System;
using KaijiGame;
using static System.Formats.Asn1.AsnWriter;

public class CommandJanken : Command
{

    private Room room;
    private EnemyChar enemy;
    private Kaiji player;

    public CommandJanken(Room room, EnemyChar enemy, Kaiji player)
    {
        this.room = room;
        this.player = player;
        this.enemy = enemy;
    }

    public void Execute(string input, Kaiji player)
    {
        if (input.ToLower() == "play")
        {
            room.SetState(new Match(EnemyChar));
        }
        else
        {
            Console.WriteLine("Invalid command. Type 'trade' to open the store.");
        }
    }
}


