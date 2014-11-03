using MarsRoverKata.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Behaviors
{
    public class Tracker : IBehavior
    {
        private IMovable Target;
        private int Speed;
        public Alien Parent { get; set; }

        public Tracker(IMovable moveable)
        {
            Target = moveable;
            Speed = 3;
        }

        public void DoStuff()
        {
            for (int i = 0; i < Speed; i++)
            {
                var delta = Target.Location - Parent.Location;

                var targetDirection = directionToTarget(delta);

                var success = Parent.Facing == targetDirection ? new ForwardCommand(Parent).Execute() : new TurnRightCommand(Parent).Execute();
            }
        }

        private Direction directionToTarget(Point delta)
        { 
            var absoluteX = Math.Abs(delta.X);
            var absoluteY = Math.Abs(delta.Y);
            var greatestDelta = absoluteX > absoluteY ? delta.X : delta.Y;
            
            bool isNegative = greatestDelta < 0;
            
            return greatestDelta == delta.X ? determineEastOrWest(isNegative) : determineNorthOrSouth(isNegative);
        }

        private Direction determineEastOrWest(bool isNegative)
        {
            return isNegative ? Direction.West : Direction.East;
        }

        private Direction determineNorthOrSouth(bool isNegative)
        {
            return isNegative ? Direction.South : Direction.North;
        }
    }
}
