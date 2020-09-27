using System.Collections.Generic;
using System.Linq;

namespace LibraryC
{
    public class Map
    { 
        public readonly int MapWidth;
        public readonly int MapHeigh;
        private Dictionary<string, (Position position, char resType)> SimpleMap { get; set; }
        public int NumberOfDestoryedResidentialSectors { get; private set; }

        public Map(Dictionary<string, (Position, char)> simpleMap, int mapHeight, int mapWidth)
        {
            SimpleMap = simpleMap;
            MapWidth = mapWidth;
            MapHeigh = mapHeight;
            NumberOfDestoryedResidentialSectors = 0;
        }

        public void DestroyAreaIfResedential(Position position)
        {
            if(IsResedentialArea(position))
            {
                EditLocation(position, '.');
                NumberOfDestoryedResidentialSectors++;
            }
        }

        public bool IsResedentialArea(Position position)
        {     
            var value = SimpleMap[position.ToString()].resType.Equals('R');
            return value;
        }

        private void EditLocation(Position position, char change)
        {
            SimpleMap[position.ToString()] = (SimpleMap[position.ToString()].position, change);
        }

        public Position[] GetPossibleMoves(Position position)
        {
            var moves = new Position[] { position.MoveNorth, position.MoveEast, position.MoveSouth, position.MoveWest };
            var validMoves = new List<Position>();
            foreach(var move in moves)
            {
                if(MoveIsValid(move))
                {
                    validMoves.Add(move);
                }
            }
            return validMoves.ToArray();
        }

        private bool MoveIsValid(Position position)
        {
            return position.X >= 0 && position.X < MapWidth && position.Y >= 0 && position.Y < MapHeigh;
        }

        public IEnumerable<Position> GetPositionsForEntityType(char entityType)
        {
            return SimpleMap.Where(x => x.Value.resType == entityType).Select(x => x.Value.position);
        }

    }
}
