﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models.Agent;
using WumpusHunt.Utils;

namespace WumpusHunt.Models.Map
{
    class BatMapCell : IMapCell
    {
        public IMapCell North { get; set; }
        public IMapCell East { get; set; }
        public IMapCell South { get; set; }
        public IMapCell West { get; set; }
        public string Probe()
        {
            return Strings.BatRustling;
        }

        public ActionResult MoveTo()
        {
            return new ActionResult()
                       {
                           GameOver = false,
                           Message = Strings.BatJacked,
                           MoveSuccessful = true,
                           Special = true,
                           ScoreValue = 0
                       };
        }

        public ActionResult DoSpecial(GameState state)
        {
            var current = state.CurrentCell;
            var allCells = current.GetAllCells().OrderBy(x => Guid.NewGuid());
            state.CurrentCell = allCells.First(x => !x.MoveTo().GameOver);
            return new ActionResult()
                       {
                           GameOver = false,
                           Special = false
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
