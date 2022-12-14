using Day09RopeBridge.Domain;
using System.Collections.Generic;
using Util;

namespace Day09RopeBridge.Services
{
    public class RopePositionMapperService
    {
        private readonly IRope _rope;
        private Dictionary<Coordinate2D, int> _tailPositionCounter;

        public RopePositionMapperService(IRope rope)
        {
            _rope = rope;
            _tailPositionCounter = new Dictionary<Coordinate2D, int>();

            Coordinate2D tailPosition = new Coordinate2D { X = rope.TailPosition.X, Y = rope.TailPosition.Y };
            _tailPositionCounter.Add(tailPosition, 1);
        }

        public void MoveRight()
        {
            _rope.MoveRight();
            IncrementTailPositionCounter();
        }

        public void MoveLeft()
        {
            _rope.MoveLeft();
            IncrementTailPositionCounter();
        }

        public void MoveUp()
        {
            _rope.MoveUp();
            IncrementTailPositionCounter();
        }

        public void MoveDown()
        {
            _rope.MoveDown();
            IncrementTailPositionCounter();
        }

        public int GetAmountOfPositionsVisited()
        {
            return _tailPositionCounter.Values.Count;
        }

        private void IncrementTailPositionCounter()
        {
            Coordinate2D tailPosition = new Coordinate2D { X = _rope.TailPosition.X, Y = _rope.TailPosition.Y };
            _tailPositionCounter.TryGetValue(tailPosition, out int count);
            _tailPositionCounter[tailPosition] = count + 1;
        }
    }
}
