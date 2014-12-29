using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Rover
    {
        public Point Location { get; set; }
        public Direction Facing { get; set; }

        private static readonly Dictionary<Direction, Point> PositionalAdjustments = new Dictionary<Direction, Point>() 
        { 
            { Direction.North, new Point(0, 1) },
            { Direction.South, new Point(0, -1) },
            { Direction.East, new Point(1, 0) },
            { Direction.West, new Point(-1, 0) }
        };

        public Size Bounds { get; private set; }
        public Point CenterOfThePlanet { get; private set; }

        private readonly List<Obstacle> _obstacles;
        public IReadOnlyList<Obstacle> Obstacles
        {
            get { return _obstacles; }
        }

        public Rover()
            : this(new Size(25, 25))
        { }

        public Rover(Size bounds)
        {
            CenterOfThePlanet = new Point(Bounds.Width / 2, Bounds.Height / 2);
            LandOnMars(CenterOfThePlanet);
            Bounds = bounds;
            _obstacles = new List<Obstacle>();
        }

        private void LandOnMars(Point landingPoint)
        {
            if (!IsValidPosition(landingPoint))
                throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");
            Location = landingPoint;
            Facing = Direction.North;
        }

        public bool MoveBackward()
        {
            return Move(-1);
        }

        public bool MoveForward()
        {
            return Move(1);
        }

        private bool Move(int adjustmentFactor)
        {
            var desiredPosition = CreateDesiredPosition(adjustmentFactor);
            var newLocation = CalculateFinalPosition(Location, desiredPosition);

            var success = Location != newLocation;

            Location = newLocation;

            return success;
        }

        private Point CreateDesiredPosition(int adjustmentFactor)
        {
            var adjustment = PositionalAdjustments[Facing] * adjustmentFactor;
            return Location + adjustment;
        }

        public bool TurnRight()
        {
            if (Facing == Direction.North)
                Facing = Direction.East;
            else if (Facing == Direction.South)
                Facing = Direction.West;
            else if (Facing == Direction.East)
                Facing = Direction.South;
            else if (Facing == Direction.West)
                Facing = Direction.North;

            return true;
        }

        public bool TurnLeft()
        {
            if (Facing == Direction.North)
                Facing = Direction.West;
            else if (Facing == Direction.South)
                Facing = Direction.East;
            else if (Facing == Direction.East)
                Facing = Direction.North;
            else if (Facing == Direction.West)
                Facing = Direction.South;
            
            return true;
        }

        public void AddObstacle(int x, int y)
        {
            Point location = new Point(x, y);
            var obstacle = new Obstacle(location);
            _obstacles.Add(obstacle);
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
            bool anyInstance = _obstacles.Any(x => x.Location.Equals(point));

            return !anyInstance;
        }
    }
}
