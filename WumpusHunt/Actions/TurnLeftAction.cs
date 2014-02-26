using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Utils;

namespace WumpusHunt.Actions
{
    public class TurnLeftAction : IAction
    {
        public string Name { get { return "left"; } }
        public ActionResult Execute(GameState state)
        {
            state.ActiveAgent.TurnLeft();
            return new ActionResult()
                       {
                           GameOver = false,
                           Message = string.Empty,
                           MoveSuccessful = true,
                           ScoreValue = 0,
                           Special = false
                       };
        }
    }
}
