package MarsRoverKata;

import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.Iterables;

import java.util.ArrayList;
import java.util.List;

public class Mars {
    private AlienBehavior alienBehavior; // get/set
    private Size bounds; // get
    private Point centerOfThePlanet; // get

    private final List<IObstacle> obstacles;

    public List<IObstacle> getObstacles() {
        return obstacles;
    }

    public Mars() {
        this(new Size(25, 25));
    }

    public Mars(Size bounds) {
        this.bounds = bounds;
        alienBehavior = new AlienBehavior();
        centerOfThePlanet = new Point(this.bounds.getWidth() / 2, this.bounds.getHeight() / 2);
        obstacles = new ArrayList<IObstacle>();
    }

    public AlienBehavior getAlienBehavior() {
        return alienBehavior;
    }

    public void setAlienBehavior(AlienBehavior alienBehavior) {
        this.alienBehavior = alienBehavior;
    }

    public Size getBounds() {
        return bounds;
    }

    public Point getCenterOfThePlanet() {
        return centerOfThePlanet;
    }

    public void updateAliens() {
        for (IObstacle alien : Collections2.filter(getObstacles(), new Predicate<IObstacle>() {
            @Override
            public boolean apply(IObstacle input) {
                return input instanceof Alien;
            }
        })) {
            alienBehavior.moveAlien((Alien) alien);
        }
    }

    public void addObstacle(IObstacle obstacle) {
        obstacles.add(obstacle);
    }

    public void removeObstacle(IObstacle obstacle) {
        obstacles.remove(obstacle);
    }

    public Point calculateFinalPosition(Point from, Point desired) {
        Point newDestination = desired;
        newDestination = calculatePositionY(desired, newDestination);
        newDestination = calculatePositionX(desired, newDestination);

        if (!isValidPosition(newDestination)) {
            return from;
        }

        return newDestination;
    }

    private Point calculatePositionX(Point desired, Point newDestination) {
        if (desired.getX() > bounds.getWidth()) {
            newDestination = new Point(0, desired.getY());
        }
        if (desired.getX() < 0) {
            newDestination = new Point(bounds.getWidth(), desired.getY());
        }
        return newDestination;
    }

    private Point calculatePositionY(Point desired, Point newDestination) {
        if (desired.getY() > bounds.getHeight()) {
            newDestination = new Point(desired.getX(), 0);
        }
        if (desired.getY() < 0) {
            newDestination = new Point(desired.getX(), bounds.getHeight());
        }
        return newDestination;
    }

    public boolean isValidPosition(final Point point) {
        boolean anyInstance = Iterables.any(obstacles, new Predicate<IObstacle>() {
            @Override
            public boolean apply(IObstacle input) {
                return input.getLocation().equals(point);
            }
        });
        return !anyInstance;
    }
}

