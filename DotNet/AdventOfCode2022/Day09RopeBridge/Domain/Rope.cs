using System;
using Util;

namespace Day09RopeBridge.Domain
{
    public class Rope
    {
        public Coordinate2D HeadPosition { get; private set; }
        public Coordinate2D TailPosition { get; private set; }

        public Rope()
        {
            HeadPosition = new Coordinate2D();
            TailPosition = new Coordinate2D();
        }

        public void MoveRight()
        {
            HeadPosition.X++;
            if (!IsHeadAndTailTouching())
            {
                TailPosition.Y = HeadPosition.Y;
                TailPosition.X++;
            }
        }

        public void MoveLeft()
        {
            HeadPosition.X--;
            if (!IsHeadAndTailTouching())
            {
                TailPosition.Y = HeadPosition.Y;
                TailPosition.X--;
            }
        }

        public void MoveUp()
        {
            HeadPosition.Y++;
            if (!IsHeadAndTailTouching())
            {
                TailPosition.X = HeadPosition.X;
                TailPosition.Y++;
            }
        }

        public void MoveDown()
        {
            HeadPosition.Y--;
            if (!IsHeadAndTailTouching())
            {
                TailPosition.X = HeadPosition.X;
                TailPosition.Y--;
            }
        }

        private bool IsHeadAndTailTouching()
        {
            return Math.Abs(HeadPosition.X - TailPosition.X) <= 1 && Math.Abs(HeadPosition.Y - TailPosition.Y) <= 1;
        }
    }
}
