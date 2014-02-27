/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models.Items
{
    public class GoldItem : IItem
    {
        public int Score { get { return 10; } }
        public string Name { get { return "Gold"; } }
        public string Probe()
        {
            return Strings.GoldGlimmer;
        }
    }
}
