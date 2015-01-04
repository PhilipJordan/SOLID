package MarsRoverKata;

public interface IMovable {
    Point getLocation();

    Direction getFacing();

    boolean moveBackward();

    boolean moveForward();

    boolean turnRight();

    boolean turnLeft();
}
