namespace MarsRoverKata.Commands
{
    public class BackwardCommand : ICommand
    {
        private IMoveable Moveable { get; set; }

        public BackwardCommand(IMoveable moveable)
        {
            Moveable = moveable;
        }

        public bool Execute()
        {
            return Moveable.MoveBackward();
        }
    }
}
