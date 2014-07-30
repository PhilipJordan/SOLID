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
        public Rover Rover;
        public Mars Planet; 
        private Commander commander;
        
        public MissionManager(Rover rover)
        {
            Rover = rover;
            Planet = rover.Mars;
            commander = new Commander();
        }

        public string AcceptCommands(String commandString)
        {
            commander.Commands = new List<ICommand>();

            var commands = commandString.ToLower().ToCharArray();
            bool success = true;
            foreach (Char command in commands)
            {
                success = AcceptCommand(success, command);
            }

            return success ? String.Empty : "Some invalid commands were found!!!";
        }

        private bool AcceptCommand(bool success, Char command)
        {
            if (command.Equals('f'))
                commander.Accept(new ForwardCommand(Rover));
            else if (command.Equals('b'))
                commander.Accept(new BackwardCommand(Rover));
            else if (command.Equals('r'))
                commander.Accept(new TurnRightCommand(Rover));
            else if (command.Equals('l'))
                commander.Accept(new TurnLeftCommand(Rover));
            else if (command.Equals('m'))
                commander.Accept(new FireMissileCommand(Rover));
            else if (command.Equals('g'))
                commander.Accept(new FireMortarCommand(Rover));
            else
                success = false;
            return success;
        }

        public string ExecuteMission()
        {
            bool success = commander.ExecuteCommands();

            return success ? String.Empty : "An error occured while executing commands";
        }
    }
}
