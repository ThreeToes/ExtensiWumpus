/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Linq;
using WumpusHunt.Models;
using WumpusHunt.Models.Items;
using WumpusHunt.Models.Map;
using WumpusHunt.Utils;

namespace WumpusHunt.Actions
{
    public class FireAction : IAction
    {
        public static int ArrowRange = 3;
        public static int ScoreValue = 1000;

        public string Name
        {
            get { return "fire"; }
        }

        public ActionResult Execute(GameState state)
        {
            var agent = state.ActiveAgent;
            var arrow = agent.Inventory.FirstOrDefault(x => x is ArrowItem);
            if(arrow == null)
            {
                return new ActionResult()
                           {
                               GameOver = false,
                               Message = Strings.NoArrows,
                               MoveSuccessful = false,
                               ScoreValue = 0,
                               Special = false
                           };
            }
            agent.RemoveItem(arrow);
            var direction = agent.CurrentDirection;
            bool hit = false;
            int cellsLeft = ArrowRange;
            var check = state.CurrentCell;
            while (cellsLeft > 0 && !hit)
            {
                cellsLeft--;
                check = check.GetCellInDirection(direction);
                if(check is WallMapCell)
                {
                    break;
                }
                hit = check.HitWumpusWithArrow();
            }
            if (hit)
            {
                return new ActionResult()
                           {
                               GameOver = true,
                               Message = Strings.KillWumpus,
                               MoveSuccessful = true,
                               ScoreValue = ScoreValue,
                               Special = false
                           };
            }

            return new ActionResult()
            {
                GameOver = false,
                Message = Strings.ArrowMiss,
                MoveSuccessful = false,
                ScoreValue = 0,
                Special = false
            };
        }

    }
}