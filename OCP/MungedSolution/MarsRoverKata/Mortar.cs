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

        protected override int MaxRange
        {
            get { return 20; }
        }

        protected override bool IsCollisionDetected(Point desired)
        {
            return false;
        }
    }
}
