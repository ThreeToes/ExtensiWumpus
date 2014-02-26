using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    public class ActionResult
    {
        public bool MoveSuccessful { get; set; }
        public bool Special { get; set; }
        public string Message { get; set; }
        public bool GameOver { get; set; }
        public int ScoreValue { get; set; }
    }
}
