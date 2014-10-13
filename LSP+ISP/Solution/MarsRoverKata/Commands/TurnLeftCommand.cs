namespace MarsRoverKata.Commands
{
    public class TurnLeftCommand : ICommand
    {
        private IMoveable Moveable { get; set; }

        public TurnLeftCommand(IMoveable moveable)
        {
            Moveable = moveable;
        }

        public bool Execute()
        {
            return Moveable.TurnLeft();
        }
    }
}
