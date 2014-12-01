using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Behaviors
{
    public interface IBehavior
    {
        Alien Parent { get; set; }
        void DoStuff();
    }
}
