using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models.Agent;

namespace WumpusHunt.Models.Map
{
    class BottomlessPitMapCell : IMapCell
    {
        public IMapCell North { get; set; }
        public IMapCell East { get; set; }
        public IMapCell South { get; set; }
        public IMapCell West { get; set; }
        public string Probe()
        {
            return Strings.HearBreeze;
        }

        public ActionResult MoveTo()
        {
            return new ActionResult()
                       {
                           GameOver = true,
                           Message = Strings.MoveToBottomlessPit,
                           MoveSuccessful = true,
                           ScoreValue = 0,
                           Special = false
                       };
        }

        public ActionResult DoSpecial(GameState state)
        {
            throw new NotImplementedException();
        }

        public ActionResult DoSpecial(string action, IAgent agent)
        {
            throw new NotImplementedException();
        }

        public bool HitWumpusWithArrow()
        {
            return false;
        }
        
        public string ProbeCurrent()
        {
            return string.Empty;
        }
    }
}
