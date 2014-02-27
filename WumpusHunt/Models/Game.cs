/*
 * Copyright (C) 2014, Stephen Gream.
 * This file is part of the ExtensiWumpus software.
 * For conditions of distribution and use, see the accompanying License file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Actions;
using WumpusHunt.Models.Agent;
using WumpusHunt.Utils;
using WumpusHunt.Utils.Hooks;

namespace WumpusHunt.Models
{
    public class Game
    {
        private GameState _state;
        private IMapGenerator _generator;
        private IEnumerable<IAction> _coreActions;
        private List<IAction> _addedActions;
        private Dictionary<string, List<IActionHook>> _actionHooks;
        private List<IInitialiseHook> _initialiseHooks; 
        /// <summary>
        /// Current game state
        /// </summary>
        public GameState CurrentState { get { return _state; } }
        /// <summary>
        /// Map generator
        /// </summary>
        public IMapGenerator Generator { get { return _generator; } }

        public Game(IMapGenerator generator, IEnumerable<IAction> coreActions, IAgent agent)
        {
            _initialiseHooks = new List<IInitialiseHook>();
            _addedActions = new List<IAction>();
            _actionHooks = new Dictionary<string, List<IActionHook>>();
            _coreActions = coreActions;
            _generator = generator;
            Reset(agent);
        }

        public void AddActionHook(string actionName, IActionHook hook)
        {
            if(!_actionHooks.ContainsKey(actionName))
            {
                _actionHooks[actionName] = new List<IActionHook>();
            }
            _actionHooks[actionName].Add(hook);
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
            agent.ResetScore();
            _state = new GameState();
            _state.ActiveAgent = agent;
            _state.CurrentCell = _generator.GenerateMap();
            RunInitialiseHooks();
        }

        private void RunInitialiseHooks()
        {
            foreach (var initialiseHook in _initialiseHooks)
            {
                initialiseHook.GameInitialised(_state);
            }
        }

        public void RegisterInitialisationHook(IInitialiseHook hook)
        {
            _initialiseHooks.Add(hook);
        }

        public ActionResult Step()
        {
            var action = _state.ActiveAgent.GetAction();
            var actionResult = RunAction(action);
            if(actionResult.Special)
            {
                _state.CurrentCell.DoSpecial(_state);
            }
            RunActionHooks(action, actionResult);
            return actionResult;
        }

        private void RunActionHooks(string action, ActionResult actionResult)
        {
            if (_actionHooks.ContainsKey(action))
            {
                foreach (var actionHook in _actionHooks[action])
                {
                    actionHook.ActionFired(_state, actionResult);
                }
            }
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

        public string CurrentPerception
        {
            get
            {
                var buildPerception = _state.CurrentCell.BuildPerception();
                var sb = new StringBuilder();
                sb.AppendLine(buildPerception);
                sb.AppendFormat("You are facing {0}\n", _state.ActiveAgent.CurrentDirection);
                return sb.ToString();
            }
        }
    }
}
