package MarsRoverKata.Behaviors;

import MarsRoverKata.Alien;
import MarsRoverKata.Direction;
import MarsRoverKata.IMovable;
import MarsRoverKata.Point;

public class Tracker implements IBehavior {
    private IMovable target;

    public IMovable getTarget() { return target; }

    private int Speed;
    private Alien parent;

    public Alien getParent() { return parent; }

    public void setParent(Alien parent) { this.parent = parent; }

    public Tracker(IMovable thingToTrack)
    {
        this.target = thingToTrack;
        Speed = 3;
    }

    public void executeBehavior()
    {
        for (int i = 0; i < Speed; i++)
        {
            Point delta = Point.subtract(getTarget().getLocation(), getParent().getLocation());

            Direction targetDirection = directionToTarget(delta);

            boolean success = getParent().getFacing() == targetDirection ? getParent().moveForward() : getParent().turnRight(); // new ForwardCommand(Parent).Execute() : new TurnRightCommand(Parent).Execute();
        }
    }

    private Direction directionToTarget(Point delta)
    {
        int absoluteX = Math.abs(delta.getX());
        int absoluteY = Math.abs(delta.getY());
        int greatestDelta = absoluteX > absoluteY ? delta.getX() : delta.getY();

        boolean isNegative = greatestDelta < 0;

        return greatestDelta == delta.getX() ? determineEastOrWest(isNegative) : determineNorthOrSouth(isNegative);
    }

    private Direction determineEastOrWest(boolean isNegative)
    {
        return isNegative ? Direction.West : Direction.East;
    }

    private Direction determineNorthOrSouth(boolean isNegative)
    {
        return isNegative ? Direction.South : Direction.North;
    }
}
