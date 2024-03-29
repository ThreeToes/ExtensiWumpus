/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System.Collections.Generic;
using WumpusHunt.Models.Items;

namespace WumpusHunt.Models.Agent
{
    public interface IAgent
    {
        int Score { get; }
        Direction CurrentDirection { get; set; }
        void GiveItem(IItem item);
        void RemoveItem(IItem item);
        IEnumerable<IItem> Inventory { get; }
        string GetAction();
        void AddScore(int toAdd);
        void ResetScore();
    }
}
