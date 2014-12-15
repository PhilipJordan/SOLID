
namespace MarsRoverKata
{
    public interface IMovable
    {
        Point Location { get; }
        Direction Facing { get; }
        bool MoveBackward();
        bool MoveForward();
        bool TurnRight();
        bool TurnLeft();
    }
}
