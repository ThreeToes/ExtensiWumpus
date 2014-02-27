/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
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
