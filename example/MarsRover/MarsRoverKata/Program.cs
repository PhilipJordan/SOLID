using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var rover = CreateRover();
            var mission = CreateMission(rover);
            var input = string.Empty;
            while (!input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                ProceedWithMission(rover, mission, input);
                input = Console.ReadLine();
            }
            TerminateMission();
        }

        private static void TerminateMission()
        {
            Console.WriteLine("Mission complete! Congrats!");
            Console.ReadLine();
        }

        private static void ProceedWithMission(Rover rover, MissionManager mission, string input)
        {
                if (input.Equals("h", StringComparison.CurrentCultureIgnoreCase))
                {
                    PrintRoverInstructions();
                }
                else
                {
                ProcessCommands(mission, input);
                    OutputMissionStatus(rover);
                }
        }

        private static MissionManager CreateMission(Rover rover)
        {
            var mission = new MissionManager(rover);
            PrintRoverInstructions();
            Console.WriteLine("Mars Rover Mission Control!");
            return mission;
        }

        private static Rover CreateRover()
        {
            var mars = CreateMars();
            return new Rover(mars);
        }

        private static Mars CreateMars()
        {
            var mars = new Mars();
            CaptureObstacles(mars);
            return mars;
        }
                
        private static void CaptureObstacles(Mars mars)
        {
            PrintObstacleInstructions();
            string input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                Obstacle obstacle = CreateObstacle(input);
                mars.Accept(obstacle);
                input = Console.ReadLine();
            }
            Console.WriteLine();
        }

        private static void PrintObstacleInstructions()
        {
            Console.WriteLine("Create Mars!");
            Console.WriteLine("Enter obstacles to the Mars landscape in X,Y format.");
            Console.WriteLine("Press [Enter] with no values when done.");
        }

        private static Obstacle CreateObstacle(string input)
            {
                var coordinates = input.Split(',');
                Point location = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            return new Obstacle(location);
            }

        private static void ProcessCommands(MissionManager mission, string input)
        {
            AcceptCommands(mission, input);
            IssueCommands(mission);
        }

        private static void AcceptCommands(MissionManager mission, string input)
        {
            string commandsAcceptance = mission.AcceptCommands(input);
            if (commandsAcceptance != String.Empty)
            {
                Console.WriteLine(commandsAcceptance);
            }
        }

        private static void IssueCommands(MissionManager mission)
        {
            string execution = mission.ExecuteMission();
            if (execution != String.Empty)
            {
                Console.WriteLine(execution);
            }
        }

        private static void OutputMissionStatus(Rover rover)
        {
            var roverLocation = rover.Location;
            Console.WriteLine("The rover is now at X: " + roverLocation.X + " Y: " + roverLocation.Y);
            Console.WriteLine("The rover is facing " + rover.Facing.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter more commands to continue moving: ");
        }

        private static void PrintRoverInstructions()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("f - Move Forward");
            Console.WriteLine("b - Move Backward");
            Console.WriteLine("r - Turn Right");
            Console.WriteLine("l - Turn Left");
            Console.WriteLine("q - End Mission (Single character command)");
            Console.WriteLine("h - Display Help (Single character command)");
            Console.WriteLine("You may issue multiple rover commands on one line.");
            Console.WriteLine();
        }
    }
}
