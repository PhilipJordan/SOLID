using MarsRoverKata.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Behaviors
{
    public class WallBuilder : IBehavior
    {
        private int Speed;
        private Mars Planet; 
        private readonly Random RNG;
        public Alien Parent { get; set; }

        public WallBuilder(Mars planet)
        {
            Planet = planet;
            Speed = 3;
            RNG = new Random();
        }

        public void ExecuteBehavior()
        {
            Parent.Facing = pickDirection();
            
            for (int i = 0; i < Speed; i++)
            {
                var previousLocation = Parent.Location;
                var moveSuccess = Parent.MoveForward(); //new ForwardCommand(Parent).Execute();

                if(previousLocation != Parent.Location)
                    Planet.AddObstacle(previousLocation); //new Obstacle(previousLocation));
            }
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
