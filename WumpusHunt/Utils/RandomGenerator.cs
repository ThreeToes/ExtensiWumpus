﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WumpusHunt.Models;
using WumpusHunt.Models.Map;
using WumpusHunt.Models.Map.Factories;

namespace WumpusHunt.Utils
{
    class RandomGenerator : IMapGenerator
    {
        private readonly Random _random;
        private readonly List<ICellFactory> _factories;
        private const int DEFAULT_MAP_SIZE = 20;

        public RandomGenerator(IEnumerable<ICellFactory> cellFactories)
        {
            _random = new Random();
            _factories = new List<ICellFactory>();
            foreach (var cellFactory in cellFactories)
            {
                for(var i = 0; i < cellFactory.Weighting; i++)
                {
                    _factories.Add(cellFactory);
                }
            }
            _factories = _factories.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public IMapCell GenerateMap()
        {
            return GenerateMap(DEFAULT_MAP_SIZE);
        }

        public IMapCell GenerateMap(int mapSize)
        {
            IEnumerable<IMapCell> cells;
            var generateMap = _GenerateMap(mapSize);
            while(!Validate(generateMap))
            {
                generateMap = _GenerateMap(mapSize);
            }
            return generateMap;
        }

        private IMapCell _GenerateMap(int mapSize)
        {
            var cellList = new List<IMapCell>();
            for (var i = 0; i < mapSize; i++)
            {
                cellList.Add(GetNextCell());
            }
            cellList.Add(new WumpusMapCell());
            foreach (var mapCell in cellList)
            {
                var connected = new List<Direction>(mapCell.GetConnectedDirections());
                var toGenerate = new List<Direction>();
                while (connected.Count < 3)
                {
                    var d = RandomDirection(connected);
                    connected.Add(d);
                    toGenerate.Add(d);
                }
                foreach (var direction in toGenerate)
                {
                    IMapCell cell = mapCell;
                    var others = cellList.Where(x => x != cell).OrderBy(x => Guid.NewGuid()).ToList();
                    var alreadyConnected = mapCell.GetConnectedCells().OrderBy(x => Guid.NewGuid());
                    //Try and connect everything first
                    var next = others.FirstOrDefault(x => !cell.AreConnected(x) 
                        && !x.GetConnectedDirections().Contains(direction.OppositeDirection()));
                    if(next == null)
                        next = others
                            .FirstOrDefault(x => x.GetConnectedDirections().Count() < 3 
                                && !alreadyConnected.Contains(x)
                                && !x.GetConnectedDirections().Contains(direction.OppositeDirection()));
                    
                    if(next == null)
                    {
                        break;
                    }
                    mapCell.SetMapCell(direction, next);
                }
            }
            cellList.First().WallMap();
            var generateMap = cellList.FirstOrDefault(x => !x.MoveTo().GameOver);
            return generateMap;
        }

        private bool Validate(IMapCell generateMap)
        {
            if (generateMap == null)
                return false;
            var wumpus = generateMap.FindWumpus().MoveSuccessful;
            var symmetry = generateMap.CheckSymmetry();
            return wumpus && symmetry;
        }

        private Direction RandomDirection(IEnumerable<Direction> blackList)
        {
            var directions = new[] {Direction.North, 
                Direction.East, 
                Direction.South, 
                Direction.West}.Where(x => !blackList.Contains(x)).ToList();
            return directions[_random.Next() % directions.Count()];
        }

        private Point GetAdjacentPoint(Point p, Direction d)
        {
            if(d == Direction.North)
                return new Point(p.X, p.Y + 1);
            if(d == Direction.East)
                return new Point(p.X + 1, p.Y);
            if(d == Direction.South)
                return new Point(p.X, p.Y - 1);
            else
                return new Point(p.X - 1, p.Y);
        }

        private IMapCell GetNextCell()
        {
            var nextIndex = _random.Next() % _factories.Count;
            return _factories[nextIndex].GetMapCell();
        }

        public IMapCell GenerateMapFromFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}