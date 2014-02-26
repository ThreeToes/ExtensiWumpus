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
            var actions = new List<IAction>();
            actions.Add(new MoveAction());
            actions.Add(new FireAction());
            actions.Add(new TurnLeftAction());
            actions.Add(new TurnRightAction());
            actions.Add(new FindWumpusAction());
            IMapGenerator generator = new RandomGenerator(factories);
            var state = new GameState(){ActiveAgent = agent};
            IMapCell current = generator.GenerateMap();
            state.CurrentCell = current;
            while (true)
            {
                Console.Write(current.BuildPerception());
                Console.WriteLine(string.Format("You are facing {0}", agent.CurrentDirection));
                Console.WriteLine(Strings.EnterAction);
                string action = string.Empty;
                while(string.IsNullOrEmpty(action) || actions.All(x => x.Name.ToUpper() != action.ToUpper()))
                    action= Console.ReadLine();
                var a = actions.First(x => x.Name.ToUpper() == action.ToUpper());
                var result = a.Execute(state);
                Console.WriteLine(result.Message);
                if (result.GameOver)
                    break;
            }
            Console.WriteLine(Strings.GameOver);
            Console.ReadLine();
        }
    }
}
