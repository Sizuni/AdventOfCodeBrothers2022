using System;
using System.Collections.Generic;
using Util;

namespace Day09RopeBridge.Domain
{
    public class LongRope : IRope
    {
        public Coordinate2D HeadPosition { get; private set; }
        public Coordinate2D TailPosition { get; private set; }
        public int AmountOfKnots { get; private set; }
        public List<Coordinate2D> KnotPositions { get; private set; }

        public LongRope(int amountOfKnots)
        {
            HeadPosition = new Coordinate2D();
            TailPosition = new Coordinate2D();
            AmountOfKnots = amountOfKnots;
            KnotPositions = new List<Coordinate2D>(amountOfKnots);
            
            KnotPositions.Add(HeadPosition);
            for (int i = 0; i < amountOfKnots - 2; i++)
            {
                KnotPositions.Add(new Coordinate2D());
            }
            KnotPositions.Add(TailPosition);
        }

        public void MoveRight()
        {
            HeadPosition.X++;
            SimulateRopeToStableState();
        }

        public void MoveLeft()
        {
            HeadPosition.X--;
            SimulateRopeToStableState();
        }
        public void MoveUp()
        {
            HeadPosition.Y++;
            SimulateRopeToStableState();
        }
        public void MoveDown()
        {
            HeadPosition.Y--;
            SimulateRopeToStableState();
        }

        private void SimulateRopeToStableState()
        {
            for (int i = 0; i < AmountOfKnots - 1; i++)
            {
                Coordinate2D knot1 = KnotPositions[i];
                Coordinate2D knot2 = KnotPositions[i + 1];
                if (Math.Abs(knot1.X - knot2.X) >= 2 && Math.Abs(knot1.Y - knot2.Y) >= 2)
                {
                    // Diagonal move
                    knot2.X = (knot1.X + knot2.X) / 2;
                    knot2.Y = (knot1.Y + knot2.Y) / 2;
                }
                else if (Math.Abs(knot1.X - knot2.X) >= 2)
                {
                    // Horizontal move
                    knot2.Y = knot1.Y;
                    knot2.X = (knot1.X + knot2.X) / 2;
                }
                else if (Math.Abs(knot1.Y - knot2.Y) >= 2)
                {
                    // Vertical move
                    knot2.X = knot1.X;
                    knot2.Y = (knot1.Y + knot2.Y) / 2;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
