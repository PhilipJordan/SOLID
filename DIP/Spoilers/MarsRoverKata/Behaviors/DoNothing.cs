using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Behaviors
{
    public class DoNothing : IBehavior
    {
        public Alien Parent { get; set; }
        public void ExecuteBehavior()
        {
            
        }
    }
}
