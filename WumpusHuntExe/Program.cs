using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt;
using WumpusHunt.Actions;
using WumpusHunt.Models;
using WumpusHunt.Models.Agent;
using WumpusHunt.Models.Map.Factories;
using WumpusHunt.Utils;
using WumpusHunt.Utils.Hooks;
using WumpusHuntExe.Menu;

namespace WumpusHuntExe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = GetGame();
            var menus = new List<IMenuEntry>()
                            {
                                new NewGameMenuEntry(),
                                new QuitEntry()
                            };
            while(true)
            {
                var weightedMenus = menus.OrderBy(x => x.Weight).ToList();
                var menuEntryNum = 1;
                foreach (var menuEntry in menus)
                {
                    Console.WriteLine("{0}) {1}", menuEntryNum, menuEntry.Title);
                    menuEntryNum++;
                }
                var choice = Console.ReadLine();
                int num;
                if(int.TryParse(choice, out num))
                {
                    var finalChoice = num - 1;
                    if(num <= 0 || num > weightedMenus.Count)
                    {
                        continue;
                    }
                    weightedMenus[finalChoice].Execute(game);
                }
            }
        }



        private static Game GetGame()
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
            return game;
        }
    }
}
