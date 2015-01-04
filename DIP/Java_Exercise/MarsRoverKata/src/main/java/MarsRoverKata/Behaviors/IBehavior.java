package MarsRoverKata.Behaviors;

import MarsRoverKata.Alien;

public interface IBehavior {
    Alien getParent();

    void setParent(Alien parent);

    void executeBehavior();
}
