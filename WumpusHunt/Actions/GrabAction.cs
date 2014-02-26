using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Items;
using WumpusHunt.Models.Map;

namespace WumpusHunt.Actions
{
    class GrabAction : IAction
    {
        public string Name { get { return "grab"; } }
        public ActionResult Execute(GameState state)
        {
            var holder = state.CurrentCell as IItemHolder;
            if(holder == null)
            {
                return new ActionResult()
                           {
                               GameOver = false,
                               Message = "Nothing to pick up",
                               MoveSuccessful = false,
                               ScoreValue = 0,
                               Special = false
                           };
            }
            var sb = new StringBuilder();
            sb.AppendLine("You picked up:");
            var items = new List<IItem>(holder.Items);
            foreach (var item in items)
            {
                state.ActiveAgent.GiveItem(item);
                sb.AppendLine(item.Name);
                holder.RemoveItem(item);
            }
            return new ActionResult()
                       {
                           GameOver = false,
                           Message = sb.ToString(),
                           MoveSuccessful = true,
                           ScoreValue = 0,
                           Special = false
                       };
        }
    }
}
