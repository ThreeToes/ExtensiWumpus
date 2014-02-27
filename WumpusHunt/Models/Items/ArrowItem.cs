/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
namespace WumpusHunt.Models.Items
{
    class ArrowItem : IItem
    {
        public int Score { get { return 0; } }
        public string Name { get { return "Arrow"; } }
        public string Probe()
        {
            return Strings.ArrowOnGround;
        }
    }
}
