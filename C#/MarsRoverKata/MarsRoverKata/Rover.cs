using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverKata.Commands;

namespace MarsRoverKata
{
    //public enum Direction
    //{
    //    North, 
    //    East,
    //    South,
    //    West
    //}

    //public class CrashException : Exception
    //{
    //    public CrashException(String message) : base(message)
    //    { }
    //}

    public class Rover
    {
        public Point Location { get; set; }
        public Direction Facing { get; set; }

        private Mars Mars { get; set; }
        private Dictionary<Direction, Point> PositionalAdjustments;

        public Rover(Mars mars)
            :this(mars, new Point(0,0))
        { }

        public Rover(Mars mars, Point landingPoint)
        {
            Mars = mars;
            Location = landingPoint;

            if (!Mars.IsValidPosition(Location))
                throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");

            Facing = Direction.North;
            PositionalAdjustments = new Dictionary<Direction, Point>() 
            { 
                { Direction.North, new Point(0, 1) },
                { Direction.South, new Point(0, -1) },
                { Direction.East, new Point(1, 0) },
                { Direction.West, new Point(-1, 0) }
            };
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
            var adjustment = PositionalAdjustments[Facing] * adjustmentFactor;
            var desiredPosition = Location + adjustment;
            var newLocation = Mars.CalculateFinalPosition(Location, desiredPosition);

            var success = Location == newLocation ? false : true;

            Location = newLocation;

            return success;
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
