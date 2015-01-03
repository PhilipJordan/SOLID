package MarsRoverKata;

public class Crater extends Obstacle {
    public Crater(Point location) {
        super(location);

    }

    @Override
    public boolean isDestructable() {
        return false;
    }
}
