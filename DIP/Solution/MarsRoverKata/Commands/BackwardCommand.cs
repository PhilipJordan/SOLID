namespace MarsRoverKata.Commands
{
    public class BackwardCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public BackwardCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute()
        {
            return Movable.MoveBackward();
        }
    }
}
