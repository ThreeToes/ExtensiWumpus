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
using WumpusHunt.Utils;

namespace WumpusHunt.Actions
{
    public class MoveAction : IAction
    {
        public string Name { get { return "move"; } }
        public ActionResult Execute(GameState state)
        {
            var current = state.CurrentCell;
            var moveTo = state.ActiveAgent.GetForwardCell(current);
            var result = moveTo.MoveTo();
            if (result.MoveSuccessful)
                state.CurrentCell = moveTo;
            return result;
        }
    }
}
