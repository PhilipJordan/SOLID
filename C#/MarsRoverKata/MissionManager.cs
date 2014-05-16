using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverKata.Commands;

namespace MarsRoverKata
{
    public class MissionManager
    {
        private Rover rover;
        private Commander commander;
        
        public MissionManager(Rover rover)
        {
            this.rover = rover;
            commander = new Commander();
        }

        public string AcceptCommands(String commandString)
        {
            commander.Commands = new List<ICommand>();

            var commands = commandString.ToLower().ToCharArray();
            bool success = true;
            foreach (Char command in commands)
            {
                if (command.Equals('f'))
                    commander.Accept(new ForwardCommand(rover));
                else if (command.Equals('b'))
                    commander.Accept(new BackwardCommand(rover));
                else if (command.Equals('r'))
                    commander.Accept(new TurnRightCommand(rover));
                else if (command.Equals('l'))
                    commander.Accept(new TurnLeftCommand(rover));
                else
                    success = false;
            }

            return success ? String.Empty : "Some invalid commands were found!!!";
        }

        public string ExecuteMission()
        {
            bool success = commander.ExecuteCommands();

            return success ? String.Empty : "An error occured while executing commands";
        }
    }
}
