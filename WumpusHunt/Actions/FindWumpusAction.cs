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
using WumpusHunt.Models.Map;
using WumpusHunt.Utils;

namespace WumpusHunt.Actions
{
    public class FindWumpusAction : IAction
    {
        public string Name { get { return "findwumpus"; } }
        public ActionResult Execute(GameState state)
        {
            var currentCell = state.CurrentCell;
            return currentCell.FindWumpus();
        }
    }
}
