using System;

namespace Util
{
    public class Coordinate2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate2D()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Create and initialize a coordinate by parsing a string value containing 2 numbers separated by a comma
        /// </summary>
        /// <param name="value">Coordinate with format of "0,0"</param>
        public Coordinate2D(string value)
        {
            string[] splitValues = value.Split(',');
            X = Convert.ToInt32(splitValues[0]);
            Y = Convert.ToInt32(splitValues[1]);
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate2D d &&
                   X == d.X &&
                   Y == d.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }


    }
}