using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Obstacle
    {
        public Point Location { get; set; }

        public Obstacle(Point location)
        {
            Location = location;
        }

        public bool IsDestructable { get { return true; } }
    }
}
