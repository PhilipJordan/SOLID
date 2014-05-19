using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public interface IObstacle
    {
        Point Location { get; set; }
    }

    public class Obstacle : IObstacle
    {
        public Point Location { get; set; }

        public Obstacle(Point location)
        {
            Location = location;
        }
    }
}
