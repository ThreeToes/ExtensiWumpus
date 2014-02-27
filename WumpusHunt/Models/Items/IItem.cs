/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
namespace WumpusHunt.Models.Items
{
    public interface IItem
    {
        /// <summary>
        /// Score this item is worth at the end of the game
        /// </summary>
        int Score { get; }
        /// <summary>
        /// Name of the item
        /// </summary>
        string Name { get; }
        /// <summary>
        /// What this item will say if it's lying on the ground
        /// </summary>
        /// <returns></returns>
        string Probe();
    }
}