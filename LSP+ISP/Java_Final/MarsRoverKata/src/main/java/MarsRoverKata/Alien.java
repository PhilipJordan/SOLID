package MarsRoverKata;

public class Alien extends Movable implements IObstacle {
    public Alien(Mars mars, Point location) {
        super(mars);
        setLocation(location);
    }

    public boolean isDestructable() {
        return true;
    }
}
