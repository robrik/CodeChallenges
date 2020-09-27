using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryC
{
    public class Mech
    {
        private Position _position;
        private Godzilla _godzilla;
        private readonly Map _map;
   
        public Mech(Position position, Godzilla godzilla, Map map)
        {
            _position = position;
            _godzilla = godzilla;
            _map = map;
        }

        public bool TryKillGodzilla()
        {
            if (CanKill())
                return true;

            TryMove();

            if (CanKill())
                return true;
            return false;
        }

        private bool CanKill()
        {
            var result = _position.GetPositionsBetween(_godzilla.Position);
            if (result != null)
            {
                return result.All(x => !_map.IsResedentialArea(x));
            }
            return false;
        }

        private void TryMove()
        {
            var moves = _map.GetPossibleMoves(_position);
            var prioritizedMoves = prioritizeMoves(moves);
            foreach (var move in prioritizedMoves)
            {
                if(!_map.IsResedentialArea(move))
                {
                    _position = move;
                    break;
                }
            }
        }

        private IEnumerable<Position> prioritizeMoves(Position[] possibleMoves)
        {
            var xDiff = Math.Abs(_godzilla.Position.X - _position.X);
            var yDiff = Math.Abs(_godzilla.Position.Y - _position.Y);
            var prioritizedMoves = new List<Position>();

            if (xDiff < yDiff)
            {
                prioritizedMoves.Add(_godzilla.Position.GetClosestX(possibleMoves));
                prioritizedMoves.Add(_godzilla.Position.GetClosestY(possibleMoves));
            }
            else
            {
                prioritizedMoves.Add(_godzilla.Position.GetClosestY(possibleMoves));
                prioritizedMoves.Add(_godzilla.Position.GetClosestX(possibleMoves));
            }
            return prioritizedMoves;
        }

    }
}
