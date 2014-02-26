using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models.Agent;
using WumpusHunt.Models.Map;

namespace WumpusHunt.Models
{
    public class GameState
    {
        public IMapCell CurrentCell { get; set; }
        public IAgent ActiveAgent { get; set; }
    }
}
