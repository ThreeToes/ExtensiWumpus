using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    class EmptyMapCell : IMapCell
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
                           Message = string.Empty,
                           MoveSuccessful = true,
                           GameOver = false
                       };
        }

        public ActionResult DoSpecial(string action, IAgent agent)
        {
            return new ActionResult()
                       {
                           Killed = false,
                           Special = false,
                           Message = Strings.NothingHappened,
                           MoveSuccessful = true,
                           GameOver = false
                       };
        }

        public bool HitWumpusWithArrow()
        {
            return false;
        }
    }
}
