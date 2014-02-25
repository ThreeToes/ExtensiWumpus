using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    class SimpleAgent : IAgent
    {
        private readonly List<IItem> _inventory;

        public SimpleAgent()
        {
            _inventory = new List<IItem>();
        }

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
    }
}
