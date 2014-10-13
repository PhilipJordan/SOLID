using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public interface IMoveable
    {
        Point Location { get; set; }
        Direction Facing { get; set; }

        Mars Mars { get; }

       bool MoveBackward();
       bool MoveForward();
       bool TurnRight();
       bool TurnLeft();
        
    }
}
