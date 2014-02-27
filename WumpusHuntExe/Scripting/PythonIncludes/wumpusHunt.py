"""
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
"""
import clr
import WumpusGame

clr.AddReference('WumpusHunt')

from WumpusHunt.Actions import IAction
from WumpusHunt.Models import ActionResult
from WumpusHunt.Models.Map.Factories import ICellFactory
from WumpusHunt.Models.Map import IMapCell
from WumpusHunt.Utils.Hooks import *

class WumpusAction(IAction):
    def get_Name(self):
        return ''
    
    def Execute(self, state):
        pass

class WumpusActionResult(ActionResult):
    pass

class WumpusTileGenerator(ICellFactory):

    def __init__(self):
        self.weight = 1
        self.enable = True

    def set_Weighting(self, weight):
        self.weight = weight

    def get_Weighting(self):
        return self.weight

    def set_Enabled(self, enabled):
        self.enable = enabled

    def get_Enabled(self):
        return self.enable

    def GetMapCell(self):
        pass

class WumpusMapCell(IMapCell):
    def __init__(self):
        self.north = None
        self.south = None
        self.east = None
        self.west = None

    def set_North(self, north):
        self.north = north

    def get_North(self):
        return self.north

    def set_West(self, north):
        self.west = north

    def get_West(self):
        return self.west

    def get_South(self):
        return self.south

    def set_South(self, north):
        self.south = north

    def get_East(self):
        return self.east

    def set_East(self, north):
        self.east = north

    def Probe(self):
        return ''

    def ProbeCurrent(self):
        return ''

    def MoveTo(self):
        return WumpusActionResult()

    def DoSpecial(self):
        return WumpusActionResult()

    def HitWumpusWithArrow():
        return False

class WumpusActionHook(IActionHook):
    def ActionFired(self, state, result):
        pass

class WumpusInitialiseHook(IInitialiseHook):
    def GameInitialised(self, state):
        pass

def register_action(action):
    WumpusGame.AddAction(action)

def register_tile_generator(generator):
    WumpusGame.Generator.AddFactory(generator)

def register_action_hook(action_name, hook):
    WumpusGame.AddActionHook(action_name, hook)