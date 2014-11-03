namespace MarsRoverKata.Commands
{
    public class ForwardCommand : ICommand
    {
        private Rover Rover { get; set; }

        public ForwardCommand(Rover rover)
        {
            Rover = rover;
        }

        public bool Execute()
        {
            return Rover.MoveForward();
        }
    }
}
