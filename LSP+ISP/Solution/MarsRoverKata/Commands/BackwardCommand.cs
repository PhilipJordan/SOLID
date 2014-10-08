namespace MarsRoverKata.Commands
{
    public class BackwardCommand : ICommand
    {
        private Rover Rover { get; set; }

        public BackwardCommand(Rover rover)
        {
            Rover = rover;
        }

        public bool Execute()
        {
            return Rover.MoveBackward();
        }
    }
}
