using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public interface IMovable
    {
        bool MoveBackward();
        bool MoveForward();
        bool TurnRight();
        bool TurnLeft();
    }
}
