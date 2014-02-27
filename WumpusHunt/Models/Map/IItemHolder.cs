/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models.Items;

namespace WumpusHunt.Models.Map
{
    public interface IItemHolder : IMapCell
    {
        IEnumerable<IItem> Items { get; }
        void AddItem(IItem item);
        void RemoveItem(IItem item);
    }
}
