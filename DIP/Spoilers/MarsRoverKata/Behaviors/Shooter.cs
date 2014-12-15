using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Behaviors
{
    public class Shooter : IBehavior
    {
        public Alien Parent { get; set; }
        private int Speed;
        private readonly Random RNG;

        public Shooter()
        {
            Speed = 3;
            RNG = new Random();
        }

        public void ExecuteBehavior()
        {
            Parent.Facing = pickDirection();

            for (int i = 0; i < Speed; i++)
            {
                //var delta = Target.Location - Parent.Location;

                //var targetDirection = directionToTarget(delta);

                Parent.MoveForward(); // new ForwardCommand(Parent).Execute() : new TurnRightCommand(Parent).Execute();
            }

            Parent.Facing = pickDirection();

            Parent.FireMissle();
        }

        private Direction pickDirection()
        {
            switch (RNG.Next(1, 5))
            {
                case 1:
                    return Direction.North;
                case 2:
                    return Direction.East;
                case 3:
                    return Direction.South;
                case 4:
                    return Direction.West;
            }

            return Direction.North;
        }

    }
}
