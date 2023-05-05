using System.Collections;
using System.Collections.Generic;
using System;

namespace KaijiGame
{

    class Program
    {
        static void Main(string[] args)
        {
            BoatWorld game = new Game();
            BoatWorld.start();  // starts the game
            BoatWorld.Play();  // play the game
            BoatWorld.End();  // ends game

            EnemyChar.Randomize(); //randomize enemies draw
        }
    }
}