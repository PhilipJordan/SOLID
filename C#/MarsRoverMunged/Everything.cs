using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverMunged
{
    public class Everything
    {
        public enum Direction
        {
            North,
            East,
            South,
            West
        }
        private Dictionary<Direction, Point> PositionalAdjustments;
        private Size MarsBounds;
        private List<Point> MarsObsticles;

        public Everything()
        {
            PositionalAdjustments = new Dictionary<Direction, Point>() 
            { 
                { Direction.North, new Point(0, 1) },
                { Direction.South, new Point(0, -1) },
                { Direction.East, new Point(1, 0) },
                { Direction.West, new Point(-1, 0) }
            };

            MarsBounds = new Size(100, 100);
            MarsObsticles = new List<Point>();
        }

        public void Run()
        {
            var roverFacing = Direction.North;
            Point roverLocation = new Point(0, 0);

            CaptureObsticles();
            if(MarsObsticles.Any(x => x.Equals(roverLocation)))
                throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");

            Console.WriteLine("Commands:");
            Console.WriteLine("f - Move Forward");
            Console.WriteLine("b - Move Backward");
            Console.WriteLine("r - Turn Right");
            Console.WriteLine("l - Turn Left");
            Console.WriteLine("q - End Mission (Single character command)");
            Console.WriteLine("h - Display Help (Single character command)");
            Console.WriteLine("You may issue multiple rover commands on one line.");
            Console.WriteLine();
            Console.WriteLine("Mars Rover Mission Control!");

            var input = string.Empty;
            while (!input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                if (input.Equals("h", StringComparison.CurrentCultureIgnoreCase))
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
                else
                {
                    bool wasValid = true;
                    foreach (var command in input.ToLower())
                    {
                        if (wasValid)
                        {
                            switch (command)
                            {
                                case 'f':
                                    {
                                        var adjustment = PositionalAdjustments[roverFacing];
                                        var desiredPosition = roverLocation + adjustment;
                                        var newLocation = CalculateFinalPosition(roverLocation, desiredPosition);

                                        if (newLocation == roverLocation)
                                            wasValid = false;

                                        roverLocation = newLocation;

                                        break;
                                    }
                                case 'b':
                                    {
                                        var adjustment = PositionalAdjustments[roverFacing] * -1;
                                        var desiredPosition = roverLocation + adjustment;
                                        var newLocation = CalculateFinalPosition(roverLocation, desiredPosition);

                                        if (newLocation == roverLocation)
                                            wasValid = false;

                                        roverLocation = newLocation;
                                        break;
                                    }
                                case 'r':
                                    if (roverFacing == Direction.North)
                                        roverFacing = Direction.East;
                                    else if (roverFacing == Direction.South)
                                        roverFacing = Direction.West;
                                    else if (roverFacing == Direction.East)
                                        roverFacing = Direction.South;
                                    else if (roverFacing == Direction.West)
                                        roverFacing = Direction.North;

                                    break;
                                case 'l':
                                    if (roverFacing == Direction.North)
                                        roverFacing = Direction.West;
                                    else if (roverFacing == Direction.South)
                                        roverFacing = Direction.East;
                                    else if (roverFacing == Direction.East)
                                        roverFacing = Direction.North;
                                    else if (roverFacing == Direction.West)
                                        roverFacing = Direction.South;
                                    break;
                            }
                        }
                    }
                    Console.WriteLine("The rover is now at X: " + roverLocation.X + " Y: " + roverLocation.Y);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter more commands to continue moving: ");
                }
                input = Console.ReadLine();
            }
        }

        private void CaptureObsticles()
        {
            Console.WriteLine("Create Mars!");
            Console.WriteLine("Enter obsticles to the Mars landscape in X,Y format.");
            Console.WriteLine("Press [Enter] with no values when done.");
            string input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var coordinates = input.Split(',');
                Point location = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
                MarsObsticles.Add(location);
                input = Console.ReadLine();
            }
            Console.WriteLine();
        }

        private Point CalculateFinalPosition(Point roverLocation, Point desiredPosition)
        {
            Point newDestination = desiredPosition;
            if (desiredPosition.Y > MarsBounds.Height)
            {
                newDestination = new Point(desiredPosition.X, 0);
            }
            if (desiredPosition.Y < 0)
            {
                newDestination = new Point(desiredPosition.X, MarsBounds.Height);
            }
            if (desiredPosition.X > MarsBounds.Width)
            {
                newDestination = new Point(0, desiredPosition.Y);
            }
            if (desiredPosition.X < 0)
            {
                newDestination = new Point(MarsBounds.Width, desiredPosition.Y);
            }

            bool anyInstance = MarsObsticles.Any(x => x.Equals(newDestination));
            if (anyInstance)
            {
                return roverLocation;
            }

            return newDestination;
        }

    }
}
