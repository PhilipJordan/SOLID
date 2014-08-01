using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Missile : Projectile
    {
        public const int Range = 5;

        public Missile(Mars mars)
            : base(mars)
        {
        }

        protected override int MaxRange
        {
            get { return Missile.Range; }
        }

        protected override bool IsCollisionDetected(Point desired)
        {
            Point newDestination = desired;
            newDestination = CalculatePositionY(desired, newDestination);
            newDestination = CalculatePositionX(desired, newDestination);
            var obstacle = FindObstacle(newDestination);

            if (obstacle != null && obstacle.IsDestructable)
            {
                return true;
            }

            return false;
        }
    }
}
