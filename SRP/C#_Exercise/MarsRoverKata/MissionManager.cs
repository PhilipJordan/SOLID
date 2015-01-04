using System;
using System.Collections.Generic;
using MarsRoverKata.Commands;

namespace MarsRoverKata
{
    public class MissionManager
    {
        public Rover Rover { get; private set; }
        public Size Bounds { get { return Rover.Bounds; } }
        public IReadOnlyList<Obstacle> Obstacles { get { return Rover.Obstacles; } }
        private readonly Commander _commander;
        
        public MissionManager(Rover rover)
        {
            Rover = rover;
            _commander = new Commander();
        }

        public string AcceptCommands(String commandString)
        {
            _commander.Commands = new List<ICommand>();

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
                _commander.Accept(new ForwardCommand(Rover));
            else if (command.Equals('b'))
                _commander.Accept(new BackwardCommand(Rover));
            else if (command.Equals('r'))
                _commander.Accept(new TurnRightCommand(Rover));
            else if (command.Equals('l'))
                _commander.Accept(new TurnLeftCommand(Rover));
            else
                success = false;
            return success;
        }

        public string ExecuteMission()
        {
            bool success = _commander.ExecuteCommands();

            return success ? String.Empty : "An error occured while executing commands";
        }

        public void AddObstacle(int x, int y)
        {
            Point location = new Point(x, y);
            var obstacle = new Obstacle(location);
            Rover.AddObstacle(obstacle);
        }
    }
}
