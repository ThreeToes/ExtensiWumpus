using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHuntExe.Menu
{
    class QuitEntry : IMenuEntry
    {
        public string Title { get { return "Quit"; } }
        public int Weight { get { return int.MaxValue; } }
        public void Execute(Game game)
        {
            System.Environment.Exit(0);
        }
    }
}
