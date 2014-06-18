using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public Rover Rover { get; set; }

        public TurnLeftCommand(Rover rover)
        {
            Rover = rover;
        }

        public bool Execute()
        {
            return Rover.TurnLeft();
        }
    }
}
