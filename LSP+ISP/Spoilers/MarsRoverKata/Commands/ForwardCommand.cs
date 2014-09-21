namespace MarsRoverKata.Commands
{
    public class ForwardCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public ForwardCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute()
        {
            return Movable.MoveForward();
        }
    }
}
