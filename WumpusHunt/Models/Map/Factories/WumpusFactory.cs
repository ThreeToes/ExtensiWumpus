using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models.Map.Factories
{
    class WumpusFactory : ICellFactory
    {
        public WumpusFactory()
        {
            Weighting = 0;
            Enabled = false;
        }

        public int Weighting { get; set; }
        public bool Enabled { get; set; }
        public IMapCell GetMapCell()
        {
            return new WumpusMapCell();
        }
    }
}
