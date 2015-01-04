package MarsRoverKata;

import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.Iterables;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Rover {
    private Point location;
    private Direction facing;

    private Size bounds; // get
    private Point centerOfThePlanet; // get

    public Size getBounds() {
        return bounds;
    }

    private final List<Obstacle> obstacles;

    public List<Obstacle> getObstacles() {
        return obstacles;
    }

    public Rover() throws CrashException {
        this(new Size(25, 25));
    }

    public Rover(Size bounds) throws CrashException {
        this.bounds = bounds;
        centerOfThePlanet = new Point(this.bounds.getWidth() / 2, this.bounds.getHeight() / 2);
        obstacles = new ArrayList<Obstacle>();
        setFacing(Direction.North);
        landOnMars(centerOfThePlanet);
    }

    public Point getLocation() { return location; }

    public void setLocation(Point location) {
        this.location = location;
    }

    public Direction getFacing() { return facing; }

    public void setFacing(Direction facing) {
        this.facing = facing;
    }

    private static final Map<Direction, Point> positionalAdjustments = new HashMap<Direction, Point>() {{
        put(Direction.North, new Point(0, 1));
        put(Direction.South, new Point(0, -1));
        put(Direction.East, new Point(1, 0));
        put(Direction.West, new Point(-1, 0));
    }};


    private void landOnMars(Point landingPoint) throws CrashException {
        if (!isValidPosition(landingPoint)) {
            throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");
        }
        setLocation(landingPoint);
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
        Point newLocation = calculateFinalPosition(getLocation(), desiredPosition);
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

    public void addObstacle(Obstacle obstacle) {
        obstacles.add(obstacle);
    }

    public Point calculateFinalPosition(Point from, Point desired) {
        Point newDestination = desired;
        newDestination = calculatePositionY(desired, newDestination);
        newDestination = calculatePositionX(desired, newDestination);

        if (!isValidPosition(newDestination)) {
            return from;
        }

        return newDestination;
    }

    private Point calculatePositionX(Point desired, Point newDestination) {
        if (desired.getX() > bounds.getWidth()) {
            newDestination = new Point(0, desired.getY());
        }
        if (desired.getX() < 0) {
            newDestination = new Point(bounds.getWidth(), desired.getY());
        }
        return newDestination;
    }

    private Point calculatePositionY(Point desired, Point newDestination) {
        if (desired.getY() > bounds.getHeight()) {
            newDestination = new Point(desired.getX(), 0);
        }
        if (desired.getY() < 0) {
            newDestination = new Point(desired.getX(), bounds.getHeight());
        }
        return newDestination;
    }

    public boolean isValidPosition(final Point point) {
        boolean anyInstance = Iterables.any(obstacles, new Predicate<Obstacle>() {
            @Override
            public boolean apply(Obstacle input) {
                return input.getLocation().equals(point);
            }
        });
        return !anyInstance;
    }
}

