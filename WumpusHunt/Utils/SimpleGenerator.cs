using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Map;

namespace WumpusHunt.Utils
{
    class SimpleGenerator : IMapGenerator
    {
        public IMapCell GenerateMap()
        {
            var left = new EmptyMapCell();
            var right = new WumpusMapCell();
            left.East = right;
            left.WallMap();
            return left;
        }

        public IMapCell GenerateMapFromFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
