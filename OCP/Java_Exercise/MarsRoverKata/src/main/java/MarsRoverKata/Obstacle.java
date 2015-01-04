package MarsRoverKata;

public class Obstacle {
    private Point location;
    private boolean isDestructable;

    protected void setLocation(Point location) {
        this.location = location;
    }

    public Point getLocation() {
        return location;
    }

    public Obstacle(Point location, boolean isDestructable) {
        this.location = location;
        this.isDestructable = isDestructable;
    }

    public boolean isDestructable() {
        return this.isDestructable;
    }
}
