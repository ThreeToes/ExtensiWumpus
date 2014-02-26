using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Actions;
using WumpusHunt.Models;
using WumpusHunt.Models.Agent;
using WumpusHunt.Models.Items;
using WumpusHunt.Models.Map;
using WumpusHunt.Models.Map.Factories;
using WumpusHunt.Utils;
using WumpusHunt.Utils.Hooks;

namespace WumpusHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            IAgent agent = new SimpleAgent();
            agent.GiveItem(new ArrowItem());
            agent.GiveItem(new ArrowItem());
            agent.GiveItem(new ArrowItem());
            var factories = new List<ICellFactory>();
            factories.Add(new EmptyCellFactory());
            factories.Add(new PitCellFactory());
            factories.Add(new BatCellFactory());
            var actions = new List<IAction>();
            actions.Add(new MoveAction());
            actions.Add(new FireAction());
            actions.Add(new TurnLeftAction());
            actions.Add(new TurnRightAction());
            actions.Add(new FindWumpusAction());
            actions.Add(new GrabAction());
            IMapGenerator generator = new RandomGenerator(factories);
            generator.AddMapGeneratedHook(new GoldAddHook());
            var state = new GameState(){ActiveAgent = agent};
            IMapCell current = generator.GenerateMap();
            state.CurrentCell = current;
            while (true)
            {
                Console.Write(state.CurrentCell.BuildPerception());
                Console.WriteLine(string.Format("You are facing {0}", agent.CurrentDirection));
                Console.WriteLine(Strings.EnterAction);
                string action = string.Empty;
                while(string.IsNullOrEmpty(action) || actions.All(x => x.Name.ToUpper() != action.ToUpper()))
                    action= Console.ReadLine();
                var a = actions.First(x => x.Name.ToUpper() == action.ToUpper());
                var result = a.Execute(state);
                Console.WriteLine(result.Message);
                Console.WriteLine();
                if (result.GameOver)
                    break;
                if (result.Special)
                    state.CurrentCell.DoSpecial(state);
            }
            Console.WriteLine(Strings.GameOver);
            Console.WriteLine("Score: {0}",state.ActiveAgent.Score);
            Console.ReadLine();
        }
    }
}
