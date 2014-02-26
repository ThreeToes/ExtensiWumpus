using WumpusHunt.Models.Agent;

namespace WumpusHunt.Models.Map
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
                           MoveSuccessful = true,
                           Message = Strings.WumpusDeath,
                           Special = false,
                           GameOver = true
                       };
        }

        public ActionResult DoSpecial(GameState state)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult DoSpecial(string action, IAgent agent)
        {
            return new ActionResult()
                       {
                           Message = string.Empty,
                           MoveSuccessful = true,
                           Special = false,
                           GameOver = true
                       };
        }

        public bool HitWumpusWithArrow()
        {
            return true;
        }

        public string ProbeCurrent()
        {
            return "The wumpus is staring at you angrily";
        }
    }
}
