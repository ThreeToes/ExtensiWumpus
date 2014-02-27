/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models.Map.Factories
{
    public interface ICellFactory
    {
        /// <summary>
        /// The weighting for the cell type. Default is 1
        /// </summary>
        int Weighting { get; set; }
        /// <summary>
        /// If this facotry is enabled
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// Get a map cell from this factory
        /// </summary>
        /// <returns>A map cell</returns>
        IMapCell GetMapCell();
    }
}
