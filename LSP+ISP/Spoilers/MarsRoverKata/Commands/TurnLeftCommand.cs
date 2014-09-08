namespace MarsRoverKata.Commands
{
    public class TurnLeftCommand : ICommand
    {
        private Rover Rover { get; set; }

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
