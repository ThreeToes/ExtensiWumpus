using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    class WumpusMapCell : IMapCell
    {
        public IMapCell North { get; set; }
        public IMapCell East { get; set; }
        public IMapCell South { get; set; }
        public IMapCell West { get; set; }
        public string Probe()
        {
            return Strings.Growling;
        }

        public ActionResult MoveTo()
        {
            return new ActionResult()
                       {
                           Killed = true,
                           MoveSuccessful = true,
                           Message = Strings.WumpusDeath,
                           Special = false
                       };
        }

        public ActionResult DoSpecial(string action, IAgent agent)
        {
            return new ActionResult()
                       {
                           Killed = true,
                           Message = string.Empty,
                           MoveSuccessful = true,
                           Special = false
                       };
        }

        public bool HitWumpusWithArrow()
        {
            return true;
        }
    }
}
