using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    class WallMapCell : IMapCell
    {
        public IMapCell North { get; set; }
        public IMapCell East { get; set; }
        public IMapCell South { get; set; }
        public IMapCell West { get; set; }
        
        public string Probe()
        {
            return string.Empty;
        }

        public ActionResult MoveTo()
        {
            return new ActionResult()
                       {
                           Killed = false,
                           Special = false,
                           MoveSuccessful = false,
                           Message = Strings.HitWall,
                           GameOver = false,
                           ScoreValue = 0
                       };
        }

        public ActionResult DoSpecial(string action, IAgent agent)
        {
            return new ActionResult()
                       {
                           GameOver = false,
                           Killed = false,
                           Message = string.Empty,
                           MoveSuccessful = false,
                           ScoreValue = 0,
                           Special = false
                       };
        }

        public bool HitWumpusWithArrow()
        {
            throw new NotImplementedException();
        }
    }
}
