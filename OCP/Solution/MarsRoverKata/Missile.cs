using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Missile : Projectile
    {
        public Missile(Mars mars)
            : base(mars)
        {
        }

        protected override int MaxRange
        {
            get { return 10; }
        }

        protected override bool IsCollisionDetected(Point desired)
        {
            Point newDestination = desired;
            newDestination = CalculatePositionY(desired, newDestination);
            newDestination = CalculatePositionX(desired, newDestination);
            var obstacle = FindObstacle(newDestination);

            if (obstacle != null && (obstacle.GetType() != typeof(Crater)))
            {
                return true;
            }

            return false;
        }
    }
}
