package MarsRoverKata;

import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.Iterables;

import java.util.HashMap;
import java.util.Map;

public class Projectile {

    private static Map<Direction, Point> positionalAdjustments = new HashMap<Direction, Point>() {{
        put(Direction.North, new Point(0, 1));
        put(Direction.South, new Point(0, -1));
        put(Direction.East, new Point(1, 0));
        put(Direction.West, new Point(-1, 0));
    }};

    private Mars mars;
    private int maxRange;
    public boolean IsMortar;

    protected Projectile(Mars mars, boolean isMortar) {
        this.mars = mars;
        this.IsMortar = isMortar;
    }

    private int getMaxRange()
    {
        if(this.IsMortar)
            return 10;
        else
            return 5;
    }

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

    protected boolean isCollisionDetected(Point desired){
        if(!this.IsMortar) {
            Point newDestination = desired;
            newDestination = calculatePositionY(desired, newDestination);
            newDestination = calculatePositionX(desired, newDestination);
            Obstacle obstacle = findObstacle(newDestination);

            return obstacle != null && obstacle.isDestructable();
        }
        return false;
    }

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

    protected Obstacle findObstacle(final Point point) {
        return Iterables.getOnlyElement(Collections2.filter(mars.getObstacles(), new Predicate<Obstacle>() {
            @Override
            public boolean apply(Obstacle input) {
                return input.getLocation().equals(point);
            }
        }),null);
    }

    private void hitTarget(Point point) {
        Obstacle obstacle = findObstacle(point);

        if (obstacle != null && obstacle.isDestructable()) {
            destroyObstacle(obstacle);
        } else if (obstacle == null) {
            createObstacle(point);
        }
    }

    private void destroyObstacle(Obstacle obstacle) {
        mars.removeObstacle(obstacle);
    }

    private void createObstacle(Point point) {
        Obstacle obstacle = new Obstacle(point, false);
        mars.addObstacle(obstacle);
    }
}

