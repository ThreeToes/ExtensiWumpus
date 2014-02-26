using WumpusHunt.Models.Agent;

namespace WumpusHunt.Models.Map
{
    public interface IMapCell
    {
        IMapCell North { get; set; }
        IMapCell East { get; set; }
        IMapCell South { get; set; }
        IMapCell West { get; set; }
        /// <summary>
        /// Probe the square
        /// </summary>
        /// <returns>A message hinting what's there</returns>
        string Probe();
        /// <summary>
        /// Move to a square
        /// </summary>
        /// <returns>An action result</returns>
        ActionResult MoveTo();

        /// <summary>
        /// Do a special action
        /// </summary>
        /// <param name="state"> </param>
        /// <returns>An action result</returns>
        ActionResult DoSpecial(GameState state);
        /// <summary>
        /// Determine if firing an arrow at this square will hit it
        /// </summary>
        /// <returns>Whether the wumpus has been hit</returns>
        bool HitWumpusWithArrow();
        /// <summary>
        /// Probe as current cell
        /// </summary>
        /// <returns>Probe message</returns>
        string ProbeCurrent();
    }
}
