using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WumpusHunt.Models;

namespace WumpusHunt.Utils
{
    static class MapCellUtils
    {
        public static IMapCell GetForwardCell(this IAgent agent, IMapCell current)
        {
            return current.GetCellInDirection(agent.CurrentDirection);
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
            sb.AppendLine(currentCell.Probe());
            var probe = currentCell.North.Probe();
            if (!string.IsNullOrEmpty(probe))
                sb.AppendLine(probe);
            probe = currentCell.East.Probe();
            if (!string.IsNullOrEmpty(probe))
                sb.AppendLine(probe);
            probe = currentCell.South.Probe();
            if (!string.IsNullOrEmpty(probe))
                sb.AppendLine(probe);
            probe = currentCell.West.Probe();
            if (!string.IsNullOrEmpty(probe))
                sb.AppendLine(probe);
            return sb.ToString();
        }
    }
}
