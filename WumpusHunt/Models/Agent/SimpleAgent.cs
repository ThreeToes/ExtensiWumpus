/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using WumpusHunt.Models.Items;

namespace WumpusHunt.Models.Agent
{
    public class SimpleAgent : IAgent
    {
        private readonly List<IItem> _inventory;
        private int _score;
        public SimpleAgent()
        {
            _score = 0;
            _inventory = new List<IItem>();
        }

        public int Score { get { return _score + Inventory.Sum(x => x.Score); } }
        public Direction CurrentDirection { get; set; }
        public void GiveItem(IItem item)
        {
            _inventory.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            _inventory.Remove(item);
        }

        public IEnumerable<IItem> Inventory
        {
            get { return _inventory; }
        }

        public string GetAction()
        {
            var action = string.Empty;
            while (string.IsNullOrEmpty(action))
            {
                action = Console.ReadLine();
            }
            return action;
        }

        public void AddScore(int toAdd)
        {
            _score += toAdd;
        }

        public void ResetScore()
        {
            _score = 0;
        }
    }
}
