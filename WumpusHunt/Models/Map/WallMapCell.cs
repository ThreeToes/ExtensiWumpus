/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using WumpusHunt.Models.Agent;

namespace WumpusHunt.Models.Map
{
    class WallMapCell : IMapCell
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
                           MoveSuccessful = false,
                           Message = Strings.HitWall,
                           GameOver = false,
                           ScoreValue = 0
                       };
        }

        public ActionResult DoSpecial(GameState state)
        {
            throw new NotImplementedException();
        }

        public ActionResult DoSpecial(string action, IAgent agent)
        {
            return new ActionResult()
                       {
                           GameOver = false,
                           Message = string.Empty,
                           MoveSuccessful = false,
                           ScoreValue = 0,
                           Special = false
                       };
        }

        public bool HitWumpusWithArrow()
        {
            throw new NotImplementedException();
        }

        public string ProbeCurrent()
        {
            return string.Empty;
        }
    }
}
