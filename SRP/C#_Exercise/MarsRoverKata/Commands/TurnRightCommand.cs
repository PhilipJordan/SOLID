namespace MarsRoverKata.Commands
{
    public class TurnRightCommand : ICommand
    {
        private Rover Rover { get; set; }

        public TurnRightCommand(Rover rover)
        {
            Rover = rover;
        }

        public bool Execute()
        {
            return Rover.TurnRight();
        }
    }
}
