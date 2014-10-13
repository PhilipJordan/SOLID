namespace MarsRoverKata.Commands
{
    public class TurnRightCommand : ICommand
    {
        private IMoveable Moveable { get; set; }

        public TurnRightCommand(IMoveable moveable)
        {
            Moveable = moveable;
        }

        public bool Execute()
        {
            return Moveable.TurnRight();
        }
    }
}
