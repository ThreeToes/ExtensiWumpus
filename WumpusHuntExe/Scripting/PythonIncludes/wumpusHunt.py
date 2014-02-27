import clr
import WumpusGame

clr.AddReference('WumpusHunt')

from WumpusHunt.Actions import IAction
from WumpusHunt.Models import ActionResult

class WumpusAction(IAction):
    def get_Name(self):
        return ''
    
    def Execute(self, state):
        pass

class WumpusActionResult(ActionResult):
    pass

def register_action(action):
    WumpusGame.AddAction(action)