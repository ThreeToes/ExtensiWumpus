using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt;
using WumpusHunt.Models;

namespace WumpusHuntExe.Menu
{
    class NewGameMenuEntry : IMenuEntry
    {
        public string Title { get { return "New Game"; } }
        public int Weight { get { return int.MinValue; } }
        public void Execute(Game game)
        {
            game.Reinitialise();
            while (true)
            {
                Console.WriteLine(game.CurrentPerception);
                Console.WriteLine(Strings.EnterAction);

                var result = game.Step();
                Console.WriteLine(result.Message);
                Console.WriteLine();
                if (result.GameOver)
                    break;
            }
            Console.WriteLine(Strings.GameOver);
            Console.WriteLine("Score: {0}", game.CurrentState.ActiveAgent.Score);
            Console.ReadLine();
        }
    }
}
