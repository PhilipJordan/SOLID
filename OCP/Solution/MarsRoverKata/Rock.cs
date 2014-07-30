using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Rock : Obstacle
    {
        public Rock(Point location) :
            base(location)
        {
        }

        public override bool IsDestructable
        {
            get { return true; }
        }
    }
}
