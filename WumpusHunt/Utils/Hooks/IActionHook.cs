using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHunt.Utils.Hooks
{
    public interface IActionHook
    {
        void ActionFired(GameState state, ActionResult result);
    }
}
