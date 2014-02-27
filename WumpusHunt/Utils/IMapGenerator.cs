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
    public interface IMapGenerator
    {
        /// <summary>
        /// Add a factory to the generator
        /// </summary>
        /// <param name="factory">Factory to add</param>
        void AddFactory(ICellFactory factory);
        /// <summary>
        /// Generate a map
        /// </summary>
        /// <returns>A map</returns>
        IMapCell GenerateMap();
        /// <summary>
        /// Read in a file and generate a map
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>A map</returns>
        IMapCell GenerateMapFromFile(string path);
        /// <summary>
        /// Add a hook
        /// </summary>
        /// <param name="hook">Hook to add</param>
        void AddMapGeneratedHook(IMapGeneratedHook hook);
    }
}
