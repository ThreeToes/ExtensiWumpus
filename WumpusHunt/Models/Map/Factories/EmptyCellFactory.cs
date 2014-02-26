using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models.Map.Factories
{
    public class EmptyCellFactory : ICellFactory
    {
        public EmptyCellFactory()
        {
            Weighting = 3;
            Enabled = true;
        }

        public int Weighting { get; set; }
        public bool Enabled { get; set; }
        public IMapCell GetMapCell()
        {
            return new EmptyMapCell();
        }
    }
}
