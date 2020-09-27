using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryC
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position MoveNorth => new Position(X, Y - 1);
        public Position MoveEast => new Position(X + 1, Y);
        public Position MoveSouth => new Position(X, Y + 1);
        public Position MoveWest => new Position(X - 1, Y);


        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}{Y}";
        }

        public void Update(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Position p = (Position)obj;
                return (X == p.X) && (Y == p.Y);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Position GetClosestX(params Position[] positions )
        {
            var positionsWithMinDistance = positions.Select(position =>  (position , distance: Math.Abs(X - position.X)));
            var pos = positionsWithMinDistance.Where(pd => pd.distance == positionsWithMinDistance.Min(innerPd => innerPd.distance)).FirstOrDefault().position;
            return pos;
        }

        public Position GetClosestY(params Position[] positions)
        {
            var positionsWithMinDistance = positions.Select(position => (position, distance: Math.Abs(Y - position.Y)));
            var pos = positionsWithMinDistance.Where(pd => pd.distance == positionsWithMinDistance.Min(innerPd => innerPd.distance)).FirstOrDefault().position;
            return pos;
        }

        public IEnumerable<Position> GetPositionsBetween(Position otherPosition)
        {
            IEnumerable<Position> result = null;
            if (X == otherPosition.X)
            {
                var points = GetMinY(this, otherPosition);
                result = MakePositionsBetweenY(points.min, points.max);
            }

            if (Y == otherPosition.Y)
            {
                var points = GetMinX(this, otherPosition);
                result = MakePositionsBetweenX(points.min, points.max);
            }
            return result;
        }


        private (Position min, Position max) GetMinY(Position position, Position otherPosition)
        {
            return position.Y <= otherPosition.Y ? (position, otherPosition) : (otherPosition, position);
        }

        private (Position min, Position max) GetMinX(Position position, Position otherPosition)
        {
            return position.X <= otherPosition.X ? (position, otherPosition) : (otherPosition, position);
        }


        private IEnumerable<Position> MakePositionsBetweenY(Position min, Position max)
        {
            var list = new List<Position>();
            var current = min;
            while(current.Y < max.Y)
            {
                list.Add(current.MoveSouth);
                current = current.MoveSouth;
            }
            return list;
        }

        private IEnumerable<Position> MakePositionsBetweenX(Position min, Position max)
        {
            var list = new List<Position>();
            var current = min;
            while (current.X < max.X)
            {
                list.Add(current.MoveEast);
                current = current.MoveEast;
            }
            return list;
        }

        
    }
}
