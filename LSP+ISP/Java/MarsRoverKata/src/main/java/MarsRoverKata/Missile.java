package MarsRoverKata;

public class Missile extends Projectile {
    public static final int range = 5;

    public Missile(Mars mars) {
        super(mars);

    }

    @Override
    protected int getMaxRange() {
        return range;
    }

    @Override
    protected boolean isCollisionDetected(Point desired) {
        Point newDestination = desired;
        newDestination = calculatePositionY(desired, newDestination);
        newDestination = calculatePositionX(desired, newDestination);
        IObstacle obstacle = findObstacle(newDestination);

        return obstacle != null && obstacle.isDestructable();
    }
}
