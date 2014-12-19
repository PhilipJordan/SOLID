using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverKata.Behaviors;
using MarsRoverKata.Commands;

namespace MarsRoverKata
{
    public class MissionManager
    {
        public Rover Rover { get; private set; }
        public Mars Planet { get; private set; }
        private readonly Commander _commander;
        
        public MissionManager(Rover rover)
        {
            Rover = rover;
            Planet = rover.Mars;
            _commander = new Commander();
            _commander.CommandExecuted += UpdateAliens;
        }

        private void UpdateAliens(object sender, EventArgs e)
        {
            Planet.UpdateAliens();
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
            else if (command.Equals('m'))
                _commander.Accept(new FireMissileCommand(Rover));
            else if (command.Equals('g'))
                _commander.Accept(new FireMortarCommand(Rover));
            else
                success = false;
            return success;
        }

        public string ExecuteMission()
        {
            bool success = _commander.ExecuteCommands();

            return success ? String.Empty : "An error occured while executing commands";
        }

        public void AddObstacle(int x, int y, string type, string behavior)
        {
            Point location = new Point(x, y);
            var obstacle = CreateObstacle(location, type, behavior);
            Planet.AddObstacle(obstacle);
        }

        private IObstacle CreateObstacle(Point location, string type, string behavior)
        {
            if (type.Equals("Alien", StringComparison.OrdinalIgnoreCase))
            {
                if (behavior.Equals("tracker", StringComparison.OrdinalIgnoreCase))
                {
                    return new Alien(Planet, location, new Tracker(Rover));
                }
                if (behavior.Equals("wallbuilder", StringComparison.OrdinalIgnoreCase))
                {
                    return new Alien(Planet, location, new WallBuilder(Planet));
                }
                if (behavior.Equals("shooter", StringComparison.OrdinalIgnoreCase))
                {
                    return new Alien(Planet, location, new DoNothing());
                }

                return new Alien(Planet, location, new DoNothing());
            }
            return new Obstacle(location);
        }
    }
}
