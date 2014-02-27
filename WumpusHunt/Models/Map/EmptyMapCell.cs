/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System.Collections.Generic;
using System.Text;
using WumpusHunt.Models.Agent;
using WumpusHunt.Models.Items;

namespace WumpusHunt.Models.Map
{
    class EmptyMapCell : IItemHolder
    {
        private List<IItem> _items;
        public IMapCell North { get; set; }
        public IMapCell East { get; set; }
        public IMapCell South { get; set; }
        public IMapCell West { get; set; }

        public EmptyMapCell()
        {
            _items = new List<IItem>();
        }

        public string Probe()
        {
            return string.Empty;
        }

        public ActionResult MoveTo()
        {
            return new ActionResult()
                       {
                           Special = false,
                           Message = string.Empty,
                           MoveSuccessful = true,
                           GameOver = false
                       };
        }

        public ActionResult DoSpecial(GameState state)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult DoSpecial(string action, IAgent agent)
        {
            return new ActionResult()
                       {
                           Special = false,
                           Message = Strings.NothingHappened,
                           MoveSuccessful = true,
                           GameOver = false
                       };
        }

        public bool HitWumpusWithArrow()
        {
            return false;
        }

        public string ProbeCurrent()
        {
            var sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.AppendLine(item.Probe());
            }
            return sb.ToString();
        }

        public IEnumerable<IItem> Items { get { return _items; } }
        public void AddItem(IItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            _items.Remove(item);
        }
    }
}
