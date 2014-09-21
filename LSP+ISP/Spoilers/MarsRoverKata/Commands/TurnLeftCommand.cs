namespace MarsRoverKata.Commands
{
    public class TurnLeftCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public TurnLeftCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute()
        {
            return Movable.TurnLeft();
        }
    }
}
