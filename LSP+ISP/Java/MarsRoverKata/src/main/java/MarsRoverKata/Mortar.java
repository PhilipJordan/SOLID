package MarsRoverKata;

public class Mortar extends Projectile {
    public static final int Range = 10;

    public Mortar(Mars mars) {
        super(mars);
    }

    @Override
    protected int getMaxRange() {
        return Range;
    }

    @Override
    protected boolean isCollisionDetected(Point desired) {
        return false;
    }
}
