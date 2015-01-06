using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverMunged
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator *(Point p1, int x)
        {
            return new Point(p1.X * x, p1.Y * x);
        }

        public override bool Equals(object obj)
        {
            Point other = obj as Point;
            if (other == null)
            {
                return false;
            }

            return this.X == other.X && this.Y == other.Y;
        }
    }
}
