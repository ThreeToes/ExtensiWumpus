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
using WumpusHunt.Models.Map;

namespace WumpusHunt.Utils.Hooks
{
    public class GoldAddHook : IMapGeneratedHook
    {
        private const int GoldAvailable = 5;

        public void MapGenerated(IMapCell map)
        {
            var allCells = map.GetAllCells().Where(x => x is IItemHolder)
                .OrderBy(x => Guid.NewGuid())
                .Cast<IItemHolder>();
            var goldLeft = GoldAvailable;
            foreach (var cell in allCells)
            {
                if(goldLeft <= 0)
                    break;
                cell.AddItem(new GoldItem());
                goldLeft--;
            }
        }
    }
}
