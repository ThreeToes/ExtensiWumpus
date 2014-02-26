using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHunt.Utils.Hooks
{
    public interface IInitialiseHook
    {
        void GameInitialised(GameState state);
    }
}
