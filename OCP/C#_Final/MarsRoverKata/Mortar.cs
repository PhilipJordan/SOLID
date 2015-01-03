using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Mortar : Projectile
    {
        public const int Range = 10;

        public Mortar(Mars mars)
            : base(mars)
        {
        }

        protected override int MaxRange
        {
            get { return Mortar.Range; }
        }

        protected override bool IsCollisionDetected(Point desired)
        {
            return false;
        }
    }
}
