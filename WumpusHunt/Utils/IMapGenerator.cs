using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Map;

namespace WumpusHunt.Utils
{
    interface IMapGenerator
    {
        IMapCell GenerateMap();
        IMapCell GenerateMapFromFile(string path);
    }
}
