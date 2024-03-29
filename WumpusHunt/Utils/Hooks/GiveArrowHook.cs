﻿/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Items;

namespace WumpusHunt.Utils.Hooks
{
    public class GiveArrowHook : IInitialiseHook
    {
        private const int arrows = 3;
        public void GameInitialised(GameState state)
        {
            for (int i = 0; i < arrows; i++)
            {
                state.ActiveAgent.GiveItem(new ArrowItem());
            }
        }
    }
}
