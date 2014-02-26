using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models.Map.Factories
{
    public class PitCellFactory : ICellFactory
    {
        public PitCellFactory()
        {
            Enabled = true;
            Weighting = 1;
        }

        public int Weighting { get; set; }
        public bool Enabled { get; set; }
        public IMapCell GetMapCell()
        {
            return new BottomlessPitMapCell();
        }
    }
}
