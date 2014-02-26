using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHunt.Actions
{
    public interface IAction
    {
        string Name { get; }
        ActionResult Execute(GameState state);
    }
}
