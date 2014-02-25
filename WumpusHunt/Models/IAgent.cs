using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    interface IAgent
    {
        Direction CurrentDirection { get; set; }
        void GiveItem(IItem item);
        void RemoveItem(IItem item);
        IEnumerable<IItem> Inventory { get; }
    }
}
