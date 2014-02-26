using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHuntExe.Menu
{
    public interface IMenuEntry
    {
        string Title { get; }
        int Weight { get; }
        void Execute(Game game);
    }
}
