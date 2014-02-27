using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHuntExe.Menu
{
    public interface IMenuEntry
    {
        /// <summary>
        /// What will be displayed at the menu screen
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Weighting of the menu
        /// </summary>
        int Weight { get; }
        /// <summary>
        /// Execute this action
        /// </summary>
        /// <param name="game">Game object</param>
        void Execute(Game game);
    }
}
