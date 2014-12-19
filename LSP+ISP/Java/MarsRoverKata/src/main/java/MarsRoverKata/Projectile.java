package MarsRoverKata;

import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.Iterables;

import java.util.HashMap;
import java.util.Map;

public abstract class Projectile {

    private static Map<Direction, Point> positionalAdjustments = new HashMap<Direction, Point>() {{
        put(Direction.North, new Point(0, 1));
        put(Direction.South, new Point(0, -1));
        put(Direction.East, new Point(1, 0));
        put(Direction.West, new Point(-1, 0));
    }};

    protected Mars mars;
    protected int maxRange;

    protected Projectile(Mars mars) {
        this.mars = mars;
    }

    protected abstract int getMaxRange();

    public void launch(Direction facing, Point location) {
        boolean collidedWithTarget = false;
        int moveIndex = 0;
        Point target = location;
        while (!collidedWithTarget && moveIndex < getMaxRange()) {
            Point desiredPosition = createDesiredPosition(1, facing, target);
            target = calculateProjectileFinalPosition(target, desiredPosition);
            collidedWithTarget = isCollisionDetected(target);
            moveIndex++;
        }
        hitTarget(target);
    }

    private static Point createDesiredPosition(int adjustmentFactor, Direction facing, Point location) {
        Point adjustment = Point.multiply(positionalAdjustments.get(facing), (adjustmentFactor));
        return Point.add(location, adjustment);
    }

    private Point calculateProjectileFinalPosition(Point from, Point desired) {
        Point newDestination = desired;
        newDestination = calculatePositionY(desired, newDestination);
        newDestination = calculatePositionX(desired, newDestination);

        return newDestination;
    }

    protected abstract boolean isCollisionDetected(Point desired);

    protected Point calculatePositionX(Point desired, Point newDestination) {
        if (desired.getX() > mars.getBounds().getWidth()) {
            newDestination = new Point(0, desired.getY());
        }
        if (desired.getX() < 0) {
            newDestination = new Point(mars.getBounds().getWidth(), desired.getY());
        }
        return newDestination;
    }

    protected Point calculatePositionY(Point desired, Point newDestination) {
        if (desired.getY() > mars.getBounds().getHeight()) {
            newDestination = new Point(desired.getX(), 0);
        }
        if (desired.getY() < 0) {
            newDestination = new Point(desired.getX(), mars.getBounds().getHeight());
        }
        return newDestination;
    }

    protected IObstacle findObstacle(final Point point) {
        return Iterables.getOnlyElement(Collections2.filter(mars.getObstacles(), new Predicate<IObstacle>() {
            @Override
            public boolean apply(IObstacle input) {
                return input.getLocation().equals(point);
            }
        }));
    }

    private void hitTarget(Point point) {
        IObstacle obstacle = findObstacle(point);

        if (obstacle != null && obstacle.isDestructable()) {
            dstroyObstacle(obstacle);
        } else if (obstacle == null) {
            createObstacle(point);
        }
    }

    protected void dstroyObstacle(IObstacle obstacle) {
        mars.removeObstacle(obstacle);
    }

    protected void createObstacle(Point point) {
        IObstacle obstacle = new Crater(point);
        mars.addObstacle(obstacle);
    }
}

