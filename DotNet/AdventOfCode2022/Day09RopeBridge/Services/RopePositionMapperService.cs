using Day09RopeBridge.Domain;
using System.Collections.Generic;
using Util;

namespace Day09RopeBridge.Services
{
    public class RopePositionMapperService
    {
        private Rope rope;
        private Dictionary<Coordinate2D, int> tailPositionCounter;

        public RopePositionMapperService()
        {
            rope = new Rope();
            tailPositionCounter = new Dictionary<Coordinate2D, int>();

            Coordinate2D tailPosition = new Coordinate2D { X = rope.TailPosition.X, Y = rope.TailPosition.Y };
            tailPositionCounter.Add(tailPosition, 1);
        }

        public void MoveRight()
        {
            rope.MoveRight();
            IncrementTailPositionCounter();
        }

        public void MoveLeft()
        {
            rope.MoveLeft();
            IncrementTailPositionCounter();
        }

        public void MoveUp()
        {
            rope.MoveUp();
            IncrementTailPositionCounter();
        }

        public void MoveDown()
        {
            rope.MoveDown();
            IncrementTailPositionCounter();
        }

        public int GetAmountOfPositionsVisited()
        {
            return tailPositionCounter.Values.Count;
        }

        private void IncrementTailPositionCounter()
        {
            Coordinate2D tailPosition = new Coordinate2D { X = rope.TailPosition.X, Y = rope.TailPosition.Y };
            tailPositionCounter.TryGetValue(tailPosition, out int count);
            tailPositionCounter[tailPosition] = count + 1;
        }
    }
}
