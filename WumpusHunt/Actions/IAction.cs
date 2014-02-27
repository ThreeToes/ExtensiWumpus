﻿/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHunt.Actions
{
    public interface IAction
    {
        string Name { get; }
        ActionResult Execute(GameState state);
    }
}
