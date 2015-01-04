package MarsRoverKata;

public class Obstacle {
    private Point location;

    protected void setLocation(Point location) {
        this.location = location;
    }

    public Point getLocation() {
        return location;
    }

    public Obstacle(Point location) {
        this.location = location;
    }

    public boolean isDestructable() {
        return true;
    }
}
