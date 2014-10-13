namespace MarsRoverKata.Commands
{
    public class ForwardCommand : ICommand
    {
        private IMoveable Moveable { get; set; }

        public ForwardCommand(IMoveable moveable)
        {
            Moveable = moveable;
        }

        public bool Execute()
        {
            return Moveable.MoveForward();
        }
    }
}
