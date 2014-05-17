using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Mars 
    {
        public Size Bounds { get; private set; }

        private Point Position { get; set; }
        private List<IObsticle> _Obsticles { get; set; }
        public IReadOnlyList<IObsticle> Obsticles
        {
            get { return _Obsticles; }
        }

        public Mars()
        {
            Bounds = new Size(100, 100);
            _Obsticles = new List<IObsticle>();
        }

        public void Accept(IObsticle obsticle)
        {
            _Obsticles.Add(obsticle);
        }

        public Point CalculateFinalPosition(Point from, Point desired)
        {
            Point newDestination = desired;
            if (desired.Y > Bounds.Height)
            {
                newDestination = new Point(desired.X, 0);
            }
            if (desired.Y < 0)
            {
                newDestination = new Point(desired.X, Bounds.Height);
            }
            if (desired.X > Bounds.Width)
            {
                newDestination = new Point(0, desired.Y);
            }
            if (desired.X < 0)
            {
                newDestination = new Point(Bounds.Width, desired.Y);
            }

            bool anyInstance = _Obsticles.Any(x => x.Location.Equals(newDestination));
            if (anyInstance)
            {
                return from;
            }

            return newDestination;
        }

        public bool IsValidPosition(Point point)
        {
            bool anyInstance = _Obsticles.Any(x => x.Location.Equals(point));

            return !anyInstance;
        }
    }
}
