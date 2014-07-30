using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Mortar : Projectile
    {
        public Mortar(Mars mars)
            : base(mars)
        {
        }

        protected override int MaxDistance
        {
            get
            {
                return 20;
            }
        }

        public override void Launch(Direction facing, Point location)
        {
            base.Launch(facing, location);
        }

        protected override bool IsCollisionDetected(Point desired)
        {
            return false;
        }
    }
}
