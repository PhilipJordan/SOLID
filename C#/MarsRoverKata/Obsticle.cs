using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public interface IObsticle
    {
        Point Location { get; set; }
        Size Size { get; set; }
    }

    public class Obsticle : IObsticle
    {
        public Point Location { get; set; }
        public Size Size { get; set; }

        public Obsticle(Point location)
        {
            Size = new Size(1, 1);
            Location = location;
        }
    }
}
