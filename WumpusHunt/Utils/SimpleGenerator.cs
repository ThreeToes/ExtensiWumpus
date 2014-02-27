/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Map;
using WumpusHunt.Models.Map.Factories;
using WumpusHunt.Utils.Hooks;

namespace WumpusHunt.Utils
{
    class SimpleGenerator : IMapGenerator
    {
        public void AddFactory(ICellFactory factory)
        {
            throw new NotImplementedException();
        }

        public IMapCell GenerateMap()
        {
            var left = new EmptyMapCell();
            var right = new WumpusMapCell();
            left.East = right;
            left.WallMap();
            return left;
        }

        public IMapCell GenerateMapFromFile(string path)
        {
            throw new NotImplementedException();
        }

        public void AddMapGeneratedHook(IMapGeneratedHook hook)
        {
            throw new NotImplementedException();
        }
    }
}
