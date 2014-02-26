using System.Collections.Generic;
using WumpusHunt.Models.Items;

namespace WumpusHunt.Models.Agent
{
    public interface IAgent
    {
        Direction CurrentDirection { get; set; }
        void GiveItem(IItem item);
        void RemoveItem(IItem item);
        IEnumerable<IItem> Inventory { get; }
    }
}
