using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Agent;
using WumpusHunt.Models.Map;

namespace WumpusHunt.Utils
{
    static class MapCellUtils
    {
        public static IMapCell GetForwardCell(this IAgent agent, IMapCell current)
        {
            return current.GetCellInDirection(agent.CurrentDirection);
        }

        public static void SetMapCell(this IMapCell current, Direction dir, IMapCell next)
        {
            if (dir == Direction.West)
            {
                current.West = next;
                next.East = current;
            }
            else if (dir == Direction.East)
            {   current.East = next;
                next.West = current;
            }
            else if (dir == Direction.North)
            {
                current.North = next;
                next.South = current;
            }
            else
            {
                current.South = next;
                next.North = current;
            }
        }

        public static Direction OppositeDirection(this Direction direction)
        {
            if(direction == Direction.North) {
                return Direction.South;
            }
            if(direction == Direction.South) {
                return Direction.North;
            }
            if(direction == Direction.West)
            {
                return Direction.East;
            }
            return Direction.West;
        }

        public static IEnumerable<Direction> GetConnectedDirections(this IMapCell mapCell)
        {
            var connected = new List<Direction>();
            if (mapCell.North != null && !(mapCell.North is WallMapCell))
            {
                connected.Add(Direction.North);
            }
            if (mapCell.East != null && !(mapCell.East is WallMapCell))
            {
                connected.Add(Direction.East);
            }
            if (mapCell.South != null && !(mapCell.South is WallMapCell))
            {
                connected.Add(Direction.South);
            }
            if (mapCell.West != null && !(mapCell.West is WallMapCell))
            {
                connected.Add(Direction.West);
            }
            return connected.OrderBy(x => Guid.NewGuid());
        }

        public static IMapCell GetCellInDirection(this IMapCell cell, Direction direction)
        {
            if (direction == Direction.North)
                return cell.North;
            if (direction == Direction.East)
                return cell.East;
            if (direction == Direction.South)
                return cell.South;
            return cell.West;
        }

        public static void TurnLeft(this IAgent agent)
        {
            if (agent.CurrentDirection == Direction.North)
                agent.CurrentDirection = Direction.West;
            else if (agent.CurrentDirection == Direction.West)
                agent.CurrentDirection = Direction.South;
            else if (agent.CurrentDirection == Direction.South)
                agent.CurrentDirection = Direction.East;
            else if (agent.CurrentDirection == Direction.East)
                agent.CurrentDirection = Direction.North;
        }
        public static void TurnRight(this IAgent agent)
        {
            if (agent.CurrentDirection == Direction.North)
                agent.CurrentDirection = Direction.East;
            else if (agent.CurrentDirection == Direction.West)
                agent.CurrentDirection = Direction.North;
            else if (agent.CurrentDirection == Direction.South)
                agent.CurrentDirection = Direction.West;
            else if (agent.CurrentDirection == Direction.East)
                agent.CurrentDirection = Direction.South;
        }
        /// <summary>
        /// Put walls around the map
        /// </summary>
        /// <param name="map"></param>
        public static void WallMap(this IMapCell map)
        {
            var stack = new Stack<IMapCell>();
            stack.Push(map);
            var processed = new HashSet<IMapCell>();
            while(stack.Count > 0)
            {

                var cell = stack.Pop();
                if(processed.Contains(cell))
                    continue;

                if(cell.North != null)
                {
                    stack.Push(cell.North);
                }
                else
                {
                    cell.North = new WallMapCell();
                }
                if(cell.East != null)
                {
                    stack.Push(cell.East);
                }
                else
                {
                    cell.East = new WallMapCell();
                }
                if(cell.South != null)
                {
                    stack.Push(cell.South);
                }else
                {
                    cell.South = new WallMapCell();
                }
                if(cell.West != null)
                {
                    stack.Push(cell.West);
                }
                else
                {
                    cell.West = new WallMapCell();
                }

                processed.Add(cell);
            }
        }

        public static string BuildPerception(this IMapCell currentCell)
        {
            var sb = new StringBuilder();
            var probeCurrent = currentCell.ProbeCurrent();
            if(!string.IsNullOrEmpty(probeCurrent))
                sb.AppendLine(probeCurrent);
            var connected = currentCell.GetConnectedDirections();
            foreach (var direction in connected)
            {
                var next = currentCell.GetCellInDirection(direction);
                var m = next.Probe();
                if (!string.IsNullOrEmpty(m))
                    sb.AppendLine(m);
            }
            return sb.ToString();
        }

        private static bool CheckSymmetrySingle(IMapCell cell)
        {
            bool ok = true;
            var connectedDirs = cell.GetConnectedDirections();
            foreach (var dir in connectedDirs)
            {
                var oppDir = dir.OppositeDirection();
                ok = ok && cell.GetCellInDirection(dir).GetCellInDirection(oppDir) == cell;
            }
            return ok;
        }

        public static bool CheckSymmetry(this IMapCell map)
        {
            var toCheck = new Queue<IMapCell>();
            var check = new HashSet<IMapCell>();
            toCheck.Enqueue(map);
            while(toCheck.Count > 0)
            {
                var checking = toCheck.Dequeue();
                if (!CheckSymmetrySingle(checking))
                    return false;
                var connected = checking.GetConnectedDirections();
                foreach (var direction in connected)
                {
                    var next = checking.GetCellInDirection(direction);
                    if(!check.Contains(next))
                        toCheck.Enqueue(next);
                }
                check.Add(checking);
            }
            return true;
        }

        public static IEnumerable<IMapCell> GetConnectedCells(this IMapCell cell)
        {
            return cell.GetConnectedDirections().Select(cell.GetCellInDirection);
        }

        public static ActionResult FindWumpus(this IMapCell currentCell)
        {
            var fringe = new Stack<Tuple<IMapCell, Queue<Direction>>>();
            var check = new List<IMapCell>();
            fringe.Push(new Tuple<IMapCell, Queue<Direction>>(currentCell, new Queue<Direction>()));
            while (fringe.Count > 0)
            {
                var current = fringe.Pop();
                if (check.Contains(current.Item1))
                {
                    continue;
                }
                if (current.Item1 is WumpusMapCell)
                {
                    var result = new StringBuilder();
                    var q = current.Item2;
                    result.AppendLine("Wumpus found");
                    while (q.Count > 0)
                    {
                        result.AppendLine(String.Format("{0}", q.Dequeue()));
                    }
                    return new ActionResult()
                               {
                                   GameOver = false,
                                   Special = false,
                                   Message = result.ToString(),
                                   MoveSuccessful = true,
                                   ScoreValue = 0
                               };
                }
                check.Add(current.Item1);
                if(current.Item1 is WallMapCell || current.Item1.MoveTo().GameOver)
                {
                    continue;
                }
                foreach (var direction in current.Item1.GetConnectedDirections())
                {
                    var queue = new Queue<Direction>(current.Item2);
                    queue.Enqueue(direction);
                    var cellInDirection = current.Item1.GetCellInDirection(direction);
                    fringe.Push(new Tuple<IMapCell, Queue<Direction>>(cellInDirection, queue));
                }
            }
            return new ActionResult()
                       {
                           GameOver = false,
                           Message = "Could not find Wumpus",
                           MoveSuccessful = false,
                           ScoreValue = 0,
                           Special = false
                       };
        }

        public static bool AreConnected(this IMapCell cell, IMapCell other)
        {
            var fringe = new Queue<IMapCell>();
            fringe.Enqueue(cell);
            var tabu = new List<IMapCell>();
            while(fringe.Count > 0)
            {
                var check = fringe.Dequeue();
                if (check == other)
                    return true;
                tabu.Add(check);
                foreach (var connectedCell in check.GetConnectedCells())
                {
                    if(!tabu.Contains(connectedCell))
                        fringe.Enqueue(connectedCell);
                }
            }
            return false;
        }
    }
}
