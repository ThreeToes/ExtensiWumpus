using WumpusHunt.Models.Agent;

namespace WumpusHunt.Models.Map
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

        public string ProbeCurrent()
        {
            return string.Empty;
        }
    }
}
