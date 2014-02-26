using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models.Map;

namespace WumpusHunt.Utils.Hooks
{
    public interface IMapGeneratedHook
    {
        void MapGenerated(IMapCell map);
    }
}
