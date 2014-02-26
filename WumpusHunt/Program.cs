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
            var game = new Game(generator, actions, agent);
            game.RegisterInitialisationHook(new GiveArrowHook());
            game.Reinitialise();
            while (true)
            {
                Console.WriteLine(game.CurrentPerception);
                Console.WriteLine(Strings.EnterAction);
                
                var result = game.Step();
                Console.WriteLine(result.Message);
                Console.WriteLine();
                if (result.GameOver)
                    break;
            }
            Console.WriteLine(Strings.GameOver);
            Console.WriteLine("Score: {0}",game.CurrentState.ActiveAgent.Score);
            Console.ReadLine();
        }
    }
}
