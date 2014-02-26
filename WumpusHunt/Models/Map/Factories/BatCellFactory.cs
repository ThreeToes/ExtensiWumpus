using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models.Map.Factories
{
    class BatCellFactory : ICellFactory
    {
        public BatCellFactory()
        {
            Weighting = 1;
            Enabled = true;
        }
        public int Weighting { get; set; }
        public bool Enabled { get; set; }
        public IMapCell GetMapCell()
        {
            return new BatMapCell();
        }
    }
}
