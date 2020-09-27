using System.Collections.Generic;

namespace LibraryC
{
    public class Godzilla
    {
        public Position Position { get; }
        private List<Position> AlreadyVisited = new List<Position>();
        private readonly Map _map;

        public Godzilla(Position position, Map map)
        {
            Position = position;
            AlreadyVisited.Add(position);
            _map = map;
        }

        public void TryMove()
        {
            var moves = _map.GetPossibleMoves(Position);
            foreach (var move in moves)
            {
                if (_map.IsResedentialArea(move))
                {
                    Position.Update(move);
                    _map.DestroyAreaIfResedential(move);
                    AlreadyVisited.Add(move);
                    return;
                }
            }

            foreach (var move in moves)
            {
                if (!AlreadyVisited.Contains(move))
                {
                    Position.Update(move);
                    AlreadyVisited.Add(move);
                    return;
                }
            }
        }
    }
}
