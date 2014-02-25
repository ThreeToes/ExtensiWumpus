﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusHunt.Models
{
    class ActionResult
    {
        public bool Killed { get; set; }
        public bool MoveSuccessful { get; set; }
        public bool Special { get; set; }
        public string Message { get; set; }
        public bool GameOver { get; set; }
        public int ScoreValue { get; set; }
    }
}