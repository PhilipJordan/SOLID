using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class SelfDestructor : Missile
    {
        public SelfDestructor(Mars mars) :
            base(mars)
        {
        }

        public override void Launch(Direction facing, Point location)
        {
            bool detonated = false;
            Point target = location;
            target = CreateDesiredPosition(0, facing, target);
            detonated = TryDetonate(target);
            //if (!detonated)
            //{
            //    CreateObstacle(target);
            //}
        }
    }
}
