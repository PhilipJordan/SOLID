namespace MarsRoverKata.Commands
{
    public class TurnRightCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public TurnRightCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute()
        {
            return Movable.TurnRight();
        }
    }
}
