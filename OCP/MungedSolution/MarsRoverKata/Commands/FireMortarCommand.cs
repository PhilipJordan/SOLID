using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Commands
{
    public class FireMortarCommand : ICommand
    {
        public Rover Rover { get; set; }

        public FireMortarCommand(Rover rover)
        {
            Rover = rover;
        }

        public bool Execute()
        {
            return Rover.FireProjectile(true);
        }
    }
}
