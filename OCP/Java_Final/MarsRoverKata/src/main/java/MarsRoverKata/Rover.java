package MarsRoverKata;

import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.Iterables;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Rover {
    private List<Projectile> projectiles;
    private Point location;
    private Direction facing;
    private Mars mars;

    public Rover(Mars mars) throws CrashException {
        this(mars, mars.getCenterOfThePlanet());
    }

    public Rover(final Mars mars, final Point landingPoint) throws CrashException {
        projectiles = new ArrayList<Projectile>() {
            {
                add(new Missile(mars));
                add(new Missile(mars));
                add(new Missile(mars));
                add(new Mortar(mars));
                add(new Mortar(mars));
                add(new Mortar(mars));
            }
        };
        this.mars = mars;
        setFacing(Direction.North);
        landOnMars(landingPoint);
    }

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


    private void landOnMars(Point landingPoint) throws CrashException {
        if (!getMars().isValidPosition(landingPoint)) {
            throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");
        }
        setLocation(landingPoint);
        setFacing(Direction.North);
    }

    public boolean fireProjectile(final Class<? extends Projectile> type) {
        Projectile projectileToFire = Iterables.get(Collections2.filter(projectiles, new Predicate<Projectile>() {
            @Override
            public boolean apply(Projectile input) {
                return (input.getClass().isAssignableFrom(type));
            }
        }), 1, null);
        if (projectileToFire == null) {
            return false;
        }
        projectileToFire.launch(getFacing(), getLocation());
        projectiles.remove(projectileToFire);
        return true;
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

