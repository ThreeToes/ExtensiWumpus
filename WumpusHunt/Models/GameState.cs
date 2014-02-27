/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models.Agent;
using WumpusHunt.Models.Map;

namespace WumpusHunt.Models
{
    public class GameState
    {
        public IMapCell CurrentCell { get; set; }
        public IAgent ActiveAgent { get; set; }
    }
}
