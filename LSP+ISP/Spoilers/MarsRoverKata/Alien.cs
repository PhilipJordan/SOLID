using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Alien : Obstacle, IMovable
    {
        public Direction Facing { get; set; }

        public Mars Mars { get; private set; }
        private static readonly Dictionary<Direction, Point> PositionalAdjustments = new Dictionary<Direction, Point>
        { 
            { Direction.North, new Point(0, 1) },
            { Direction.South, new Point(0, -1) },
            { Direction.East, new Point(1, 0) },
            { Direction.West, new Point(-1, 0) }
        };

        public Alien(Mars mars, Point location)
            : base(location)
        {
            Mars = mars;
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
            var newLocation = Mars.CalculateFinalPosition(Location, desiredPosition);

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
    }
}
