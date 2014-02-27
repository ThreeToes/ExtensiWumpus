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
    public class TurnLeftAction : IAction
    {
        public string Name { get { return "left"; } }
        public ActionResult Execute(GameState state)
        {
            state.ActiveAgent.TurnLeft();
            return new ActionResult()
                       {
                           GameOver = false,
                           Message = string.Empty,
                           MoveSuccessful = true,
                           ScoreValue = 0,
                           Special = false
                       };
        }
    }
}
