using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Actions;
using WumpusHunt.Models.Agent;
using WumpusHunt.Utils;

namespace WumpusHunt.Models
{
    public class Game
    {
        private GameState _state;
        private IMapGenerator _generator;
        private IEnumerable<IAction> _coreActions;
        private List<IAction> _addedActions; 
        public GameState CurrentState { get { return _state; } }

        public Game(IMapGenerator generator, IEnumerable<IAction> coreActions, IAgent agent)
        {
            _addedActions = new List<IAction>();
            _coreActions = coreActions;
            _generator = generator;
            Reset(agent);
        }

        public void Reinitialise()
        {
            Reset(_state.ActiveAgent);
        }

        private void Reset(IAgent agent)
        {
            foreach (var item in agent.Inventory)
            {
                agent.RemoveItem(item);
            }
            _state = new GameState();
            _state.ActiveAgent = agent;
            _state.CurrentCell = _generator.GenerateMap();
        }

        public ActionResult Step()
        {
            var action = _state.ActiveAgent.GetAction();
            return RunAction(action);
        }

        public void AddAction(IAction action)
        {
            _addedActions.Add(action);
        }

        private ActionResult RunAction(string action)
        {
            var a = _coreActions.FirstOrDefault(x => x.Name.ToUpper() == action.ToUpper());
            if(a == null)
            {
                a = _addedActions.FirstOrDefault(x => x.Name.ToUpper() == action.ToUpper());
                if(a == null)
                {
                    return new ActionResult()
                               {
                                   GameOver = false,
                                   Message = Strings.NoSuchAction
                               };
                }
            }
            return a.Execute(_state);
        }
    }
}
