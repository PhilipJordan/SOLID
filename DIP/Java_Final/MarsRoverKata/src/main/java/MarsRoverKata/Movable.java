package MarsRoverKata;

import java.util.HashMap;
import java.util.Map;

public class Movable implements IMovable {
    private Point location;
    private Direction facing;
    private Mars mars;

    public Point getLocation() { return location; }

    public void setLocation(Point location) {
        this.location = location;
    }

    public Direction getFacing() { return facing; }

    public void setFacing(Direction facing) {
        this.facing = facing;
    }

    public Mars getMars() { return mars; }

    private static final Map<Direction, Point> positionalAdjustments = new HashMap<Direction, Point>() {{
        put(Direction.North, new Point(0, 1));
        put(Direction.South, new Point(0, -1));
        put(Direction.East, new Point(1, 0));
        put(Direction.West, new Point(-1, 0));
    }};

    protected Movable(Mars mars, Point location) {
        this.mars = mars;
        setLocation(location);
        setFacing(Direction.North);
    }

    public boolean moveBackward() {
        return move(-1);
    }

    public boolean moveForward()
    {
        return move(1);
    }

    private boolean move(int adjustmentFactor) {
        Point desiredPosition = createDesiredPosition(adjustmentFactor);
        Point newLocation = getMars().calculateFinalPosition(getLocation(), desiredPosition);
        boolean success = getLocation() != newLocation;
        setLocation(newLocation);
        return success;
    }

    private Point createDesiredPosition(int adjustmentFactor) {
        Point adjustment = Point.multiply(positionalAdjustments.get(getFacing()), adjustmentFactor);
        return Point.add(getLocation(), adjustment);
    }

    public boolean turnRight()
    {
        if (getFacing() == Direction.North)
            setFacing(Direction.East);
        else if (getFacing() == Direction.South)
            setFacing(Direction.West);
        else if (getFacing() == Direction.East)
            setFacing(Direction.South);
        else if (getFacing() == Direction.West)
            setFacing(Direction.North);

        return true;
    }

    public boolean turnLeft()
    {
        if (getFacing() == Direction.North)
            setFacing(Direction.West);
        else if (getFacing() == Direction.South)
            setFacing(Direction.East);
        else if (getFacing() == Direction.East)
            setFacing(Direction.North);
        else if (getFacing() == Direction.West)
            setFacing(Direction.South);

        return true;
    }
}
