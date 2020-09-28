//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ProblemsConsoleDNF.ProgramC
//{
//    public class ProgramC
//    {
//        static void Main(string[] args)
//        {
//            var problemCInput = InputReader.ReadInputForProblemC();
//            var parsedInput = InputParser.ParseForProblemC(problemCInput);
//            var ProblemC = new ProblemC();
//            var list = ProblemC.Simulate(parsedInput).ToList();
//            list.ForEach(x => Console.WriteLine(x));

//            Console.ReadLine();
//        }
//    }

//    public class ProblemC
//    {
//        public IEnumerable<int> Simulate(IEnumerable<char[][]> testCases)
//        {
//            var simCon = testCases.Select(x => new SimulationContainer(x));
//            var list = simCon.Select(sim => sim.RunSimulation());
//            return list;
//        }
//    }

//    public class InputReader
//    {
//        public static IEnumerable<string> ReadInputForProblemA()
//        {
//            var strings = new List<string>();
//            var linesToRead = int.Parse(Console.ReadLine());
//            for (int a = 0; a < linesToRead; a++)
//            {
//                strings.Add(Console.ReadLine());
//            }
//            return strings;
//        }

//        public static IEnumerable<IEnumerable<string>> ReadInputForProblemC()
//        {
//            var strings = new List<IEnumerable<string>>();
//            var testCases = int.Parse(Console.ReadLine());
//            for (int a = 0; a < testCases; a++)
//            {
//                strings.Add(ReadOneTestCaseForProblemC());

//            }
//            return strings;
//        }

//        private static IEnumerable<string> ReadOneTestCaseForProblemC()
//        {
//            var mapHight = int.Parse(Console.ReadLine().Split(' ').Last());
//            var strings = new List<string>();
//            for (int a = 0; a < mapHight; a++)
//            {
//                strings.Add(Console.ReadLine());
//            }
//            return strings;
//        }


//    }

//    public class InputParser
//    {
//        public static IEnumerable<int[]> ParseForProblemA(IEnumerable<string> advertisementNumberLines)
//        {
//            return advertisementNumberLines.Select(advLine =>
//                advLine.Split(' ').Select(advValue => int.Parse(advValue)).ToArray());
//        }


//        public static IEnumerable<char[][]> ParseForProblemC(IEnumerable<IEnumerable<string>> testCases)
//        {
//            return testCases.Select(map => map.Select(line => line.ToCharArray()).ToArray());
//        }
//    }

//    public class Map
//    {

//        public readonly int MapWidth;
//        public readonly int MapHeigh;
//        private Dictionary<string, Tuple<Position, char>> SimpleMap { get; set; }
//        public int NumberOfDestoryedResidentialSectors { get; private set; }

//        public Map(Dictionary<string, Tuple<Position, char>> simpleMap, int mapHeight, int mapWidth)
//        {
//            SimpleMap = simpleMap;
//            MapWidth = mapWidth;
//            MapHeigh = mapHeight;
//            NumberOfDestoryedResidentialSectors = 0;
//        }

//        public void DestroyAreaIfResedential(Position position)
//        {
//            if (IsResedentialArea(position))
//            {
//                EditLocation(position, '.');
//                NumberOfDestoryedResidentialSectors++;
//            }
//        }

//        public bool IsResedentialArea(Position position)
//        {
//            var value = SimpleMap[position.ToString()].Item2.Equals('R');
//            return value;
//        }

//        private void EditLocation(Position position, char change)
//        {
//            SimpleMap[position.ToString()] = new Tuple<Position, char>(SimpleMap[position.ToString()].Item1, change);
//        }

//        public Position[] GetPossibleMoves(Position position)
//        {
//            var moves = new Position[] { position.MoveNorth, position.MoveEast, position.MoveSouth, position.MoveWest };
//            var validMoves = new List<Position>();
//            foreach (var move in moves)
//            {
//                if (MoveIsValid(move))
//                {
//                    validMoves.Add(move);
//                }
//            }
//            return validMoves.ToArray();
//        }

//        private bool MoveIsValid(Position position)
//        {
//            return position.X >= 0 && position.X < MapWidth && position.Y >= 0 && position.Y < MapHeigh;
//        }

//        public IEnumerable<Position> GetPositionsForEntityType(char entityType)
//        {
//            return SimpleMap.Where(x => x.Value.Item2 == entityType).Select(x => x.Value.Item1);
//        }

//    }

//    public class SimulationContainer
//    {

//        private Godzilla Godzilla { get; set; }
//        private List<Mech> Mechs { get; set; }
//        private Map Map { get; set; }

//        public SimulationContainer(char[][] rawMap)
//        {
//            Map = MapHelper.BuildMap(rawMap);
//            Godzilla = CreateGodzilla(Map);
//            Mechs = CreateMechs(Map, Godzilla);
//        }

//        private Godzilla CreateGodzilla(Map map)
//        {
//            var godzillPosition = map.GetPositionsForEntityType('G').First();
//            return new Godzilla(godzillPosition, map);
//        }

//        private List<Mech> CreateMechs(Map map, Godzilla godzilla)
//        {
//            var mechPositions = map.GetPositionsForEntityType('M');
//            var mechs = mechPositions.Select(position => new Mech(position, godzilla, map)).ToList();
//            return mechs;
//        }

//        public int RunSimulation()
//        {
//            do
//            {
//                Godzilla.TryMove();

//            } while (!Mechs.Any(x => x.TryKillGodzilla()));

//            return Map.NumberOfDestoryedResidentialSectors;
//        }
//    }

//    public class Position
//    {
//        public int X { get; private set; }
//        public int Y { get; private set; }

//        public Position MoveNorth => new Position(X, Y - 1);
//        public Position MoveEast => new Position(X + 1, Y);
//        public Position MoveSouth => new Position(X, Y + 1);
//        public Position MoveWest => new Position(X - 1, Y);


//        public Position(int x, int y)
//        {
//            X = x;
//            Y = y;
//        }

//        public override string ToString()
//        {
//            return $"{X}{Y}";
//        }

//        public void Update(Position position)
//        {
//            X = position.X;
//            Y = position.Y;
//        }

//        public override bool Equals(object obj)
//        {
//            if ((obj == null) || !GetType().Equals(obj.GetType()))
//            {
//                return false;
//            }
//            else
//            {
//                Position p = (Position)obj;
//                return (X == p.X) && (Y == p.Y);
//            }
//        }

//        public Position GetClosestX(params Position[] positions)
//        {
//            var positionsWithMinDistance = positions.Select(position => new Tuple<Position, int>(position, Math.Abs(X - position.X)));
//            var pos = positionsWithMinDistance.Where(pd => pd.Item2 == positionsWithMinDistance.Min(innerPd => innerPd.Item2)).FirstOrDefault().Item1;
//            return pos;
//        }

//        public Position GetClosestY(params Position[] positions)
//        {
//            var positionsWithMinDistance = positions.Select(position => new Tuple<Position, int>(position, Math.Abs(Y - position.Y)));
//            var pos = positionsWithMinDistance.Where(pd => pd.Item2 == positionsWithMinDistance.Min(innerPd => innerPd.Item2)).FirstOrDefault().Item1;
//            return pos;
//        }

//        public IEnumerable<Position> GetPositionsBetween(Position otherPosition)
//        {
//            IEnumerable<Position> result = null;
//            if (X == otherPosition.X)
//            {
//                var points = GetMinY(this, otherPosition);
//                result = MakePositionsBetweenY(points.Item1, points.Item2);
//            }

//            if (Y == otherPosition.Y)
//            {
//                var points = GetMinX(this, otherPosition);
//                result = MakePositionsBetweenX(points.Item1, points.Item2);
//            }
//            return result;
//        }


//        private new Tuple<Position, Position> GetMinY(Position position, Position otherPosition)
//        {
//            return position.Y <= otherPosition.Y ? new Tuple<Position, Position>(position, otherPosition) : new Tuple<Position, Position>(otherPosition, position);
//        }

//        private Tuple<Position, Position> GetMinX(Position position, Position otherPosition)
//        {
//            return position.X <= otherPosition.X ? new Tuple<Position, Position>(position, otherPosition) : new Tuple<Position, Position>(otherPosition, position);
//        }


//        private IEnumerable<Position> MakePositionsBetweenY(Position min, Position max)
//        {
//            var list = new List<Position>();
//            var current = min;
//            while (current.Y < max.Y)
//            {
//                list.Add(current.MoveSouth);
//                current = current.MoveSouth;
//            }
//            return list;
//        }

//        private IEnumerable<Position> MakePositionsBetweenX(Position min, Position max)
//        {
//            var list = new List<Position>();
//            var current = min;
//            while (current.X < max.X)
//            {
//                list.Add(current.MoveEast);
//                current = current.MoveEast;
//            }
//            return list;
//        }
//    }
//    public class Mech
//    {
//        private Position _position;
//        private Godzilla _godzilla;
//        private Map _map;

//        public Mech(Position position, Godzilla godzilla, Map map)
//        {
//            _position = position;
//            _godzilla = godzilla;
//            _map = map;
//        }

//        public bool TryKillGodzilla()
//        {
//            if (CanKill())
//                return true;

//            TryMove();

//            if (CanKill())
//                return true;
//            return false;
//        }

//        private bool CanKill()
//        {
//            var result = _position.GetPositionsBetween(_godzilla.Position);
//            if (result != null)
//            {
//                return result.All(x => !_map.IsResedentialArea(x));
//            }
//            return false;
//        }

//        private void TryMove()
//        {
//            var moves = _map.GetPossibleMoves(_position);
//            var prioritizedMoves = prioritizeMoves(moves);
//            foreach (var move in prioritizedMoves)
//            {
//                if (!_map.IsResedentialArea(move))
//                {
//                    _position = move;
//                    break;
//                }
//            }
//        }

//        private IEnumerable<Position> prioritizeMoves(Position[] possibleMoves)
//        {
//            var xDiff = Math.Abs(_godzilla.Position.X - _position.X);
//            var yDiff = Math.Abs(_godzilla.Position.Y - _position.Y);
//            var prioritizedMoves = new List<Position>();

//            if (xDiff < yDiff)
//            {
//                prioritizedMoves.Add(_godzilla.Position.GetClosestX(possibleMoves));
//                prioritizedMoves.Add(_godzilla.Position.GetClosestY(possibleMoves));
//            }
//            else
//            {
//                prioritizedMoves.Add(_godzilla.Position.GetClosestY(possibleMoves));
//                prioritizedMoves.Add(_godzilla.Position.GetClosestX(possibleMoves));
//            }
//            return prioritizedMoves;
//        }

//    }
//    public class MapHelper
//    {

//        public static Map BuildMap(char[][] rawMap)
//        {
//            var simpleMap = new Dictionary<string, Tuple<Position, char>>();
//            for (int outer = 0; outer < rawMap.Length; outer++)
//            {
//                for (int inner = 0; inner < rawMap[0].Length; inner++)
//                {
//                    var position = new Position(inner, outer);
//                    simpleMap.Add(position.ToString(), new Tuple<Position, char>(position, rawMap[outer][inner]));
//                }

//            }

//            var map = new Map(simpleMap, rawMap.Length, rawMap[0].Length);
//            return map;
//        }
//    }


//    public class Godzilla
//    {
//        public Position Position { get; }
//        private List<Position> AlreadyVisited = new List<Position>();
//        private readonly Map _map;

//        public Godzilla(Position position, Map map)
//        {
//            Position = position;
//            AlreadyVisited.Add(position);
//            _map = map;
//        }

//        public void TryMove()
//        {
//            var moves = _map.GetPossibleMoves(Position);
//            foreach (var move in moves)
//            {
//                if (_map.IsResedentialArea(move))
//                {
//                    Position.Update(move);
//                    _map.DestroyAreaIfResedential(move);
//                    AlreadyVisited.Add(move);
//                    return;
//                }
//            }

//            foreach (var move in moves)
//            {
//                if (!AlreadyVisited.Contains(move))
//                {
//                    Position.Update(move);
//                    AlreadyVisited.Add(move);
//                    return;
//                }
//            }
//        }
//    }
//}
