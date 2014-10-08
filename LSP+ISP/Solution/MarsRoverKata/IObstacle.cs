using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public interface IObstacle
    {
        Point Location { get; }
        bool IsDestructable { get; }
    }
}
