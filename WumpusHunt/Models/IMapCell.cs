using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    interface IMapCell
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
        /// <param name="action">Action name</param>
        /// <param name="agent">Agent to carry out action</param>
        /// <returns>An action result</returns>
        ActionResult DoSpecial(string action, IAgent agent);
        /// <summary>
        /// Determine if firing an arrow at this square will hit it
        /// </summary>
        /// <returns>Whether the wumpus has been hit</returns>
        bool HitWumpusWithArrow();
    }
}
