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
        public Point CenterOfThePlanet { get; set; }

        private Point Position { get; set; }
        private List<IObstacle> _Obstacles { get; set; }
        public IReadOnlyList<IObstacle> Obstacles
        {
            get { return _Obstacles; }
        }

        public Mars()
        {
            Bounds = new Size(50, 50); //(100,100);
            CenterOfThePlanet = new Point(Bounds.Width / 2, Bounds.Height / 2);
            _Obstacles = new List<IObstacle>();
        }

        public void AddObstacle(IObstacle obstacle)
        {
            _Obstacles.Add(obstacle);
        }

        public void RemoveObstacle(IObstacle obstacle)
        {
            _Obstacles.Remove(obstacle);
        }

        public Point CalculateFinalPosition(Point from, Point desired)
        {
            Point newDestination = desired;
            newDestination = CalculatePositionY(desired, newDestination);
            newDestination = CalculatePositionX(desired, newDestination);

            if (!IsValidPosition(newDestination))
            {
                return from;
            }

            return newDestination;
        }

        private Point CalculatePositionX(Point desired, Point newDestination)
        {
            if (desired.X > Bounds.Width)
            {
                newDestination = new Point(0, desired.Y);
            }
            if (desired.X < 0)
            {
                newDestination = new Point(Bounds.Width, desired.Y);
            }
            return newDestination;
        }

        private Point CalculatePositionY(Point desired, Point newDestination)
        {
            if (desired.Y > Bounds.Height)
            {
                newDestination = new Point(desired.X, 0);
            }
            if (desired.Y < 0)
            {
                newDestination = new Point(desired.X, Bounds.Height);
            }
            return newDestination;
        }

        public bool IsValidPosition(Point point)
        {
            bool anyInstance = _Obstacles.Any(x => x.Location.Equals(point));

            return !anyInstance;
        }
    }
}
