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
            var mars = new Mars();
            var rover = new Rover(mars);
            var mission = new MissionManager(rover);
            CaptureObsticles(mars);
            PrintRoverInstructions();
            Console.WriteLine("Mars Rover Mission Control!");

            var input = string.Empty;
            while (!input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                if (input.Equals("h", StringComparison.CurrentCultureIgnoreCase))
                {
                    PrintRoverInstructions();
                }
                else
                {
                    IssueCommands(mission, input);
                    OutputMissionStatus(rover);
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Mission complete! Congrats!");
            Console.ReadLine();
        }

        private static void CaptureObsticles(Mars mars)
        {
            Console.WriteLine("Create Mars!");
            Console.WriteLine("Enter obsticles to the Mars landscape in X,Y format.");
            Console.WriteLine("Press [Enter] with no values when done.");
            string input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var coordinates = input.Split(',');
                Point location = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
                Obsticle obsticle = new Obsticle(location);
                mars.Accept(obsticle);
                input = Console.ReadLine();
            }
            Console.WriteLine();
        }

        private static void IssueCommands(MissionManager mission, string input)
        {
            string commandsAcceptance = mission.AcceptCommands(input);
            if (commandsAcceptance != String.Empty)
            {
                Console.WriteLine(commandsAcceptance);
            }

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
