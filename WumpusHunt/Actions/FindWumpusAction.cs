using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Map;
using WumpusHunt.Utils;

namespace WumpusHunt.Actions
{
    class FindWumpusAction : IAction
    {
        public string Name { get { return "findwumpus"; } }
        public ActionResult Execute(GameState state)
        {
            var currentCell = state.CurrentCell;
            return currentCell.FindWumpus();
        }
    }
}
