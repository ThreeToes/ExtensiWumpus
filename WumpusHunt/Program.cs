using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Utils;

namespace WumpusHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            IAgent agent = new SimpleAgent();
            IMapGenerator generator = new SimpleGenerator();
            int arrowsLeft = 3;
            IMapCell current = generator.GenerateMap();
            while (true)
            {
                Console.Write(current.BuildPerception());
                Console.WriteLine(string.Format("You are facing {0}", agent.CurrentDirection));
                Console.WriteLine(Strings.EnterAction);
                string action = string.Empty;
                while(string.IsNullOrEmpty(action))
                    action= Console.ReadLine();
                
                if(action.ToUpper() == "LEFT")
                    agent.TurnLeft();
                else if(action.ToUpper() == "RIGHT")
                    agent.TurnRight();
                else if(action.ToUpper() == "MOVE")
                {
                    var moveTo = agent.GetForwardCell(current);
                    var result = moveTo.MoveTo();
                    Console.WriteLine(result.Message);
                    if(result.MoveSuccessful)
                    {
                        current = moveTo;
                    }
                    if(result.Killed || result.GameOver)
                    {
                        break;
                    }
                }else if(action.ToUpper() == "FIRE")
                {
                    if(arrowsLeft > 0)
                    {
                        var direction = agent.CurrentDirection;
                        var hit = false;
                        var cellsLeft = 3;
                        var check = current;
                        while (cellsLeft > 0)
                        {
                            cellsLeft--;
                            check = check.GetCellInDirection(direction);
                            hit = hit || check.HitWumpusWithArrow();
                        }
                        arrowsLeft--;
                        if(hit)
                        {
                            Console.WriteLine("You hear a scream as the wumpus dies");
                            break;
                        }
                    }
                }
                else
                {
                    current.DoSpecial(action, agent);
                }
            }
            Console.WriteLine(Strings.GameOver);
            Console.ReadLine();
        }
    }
}
