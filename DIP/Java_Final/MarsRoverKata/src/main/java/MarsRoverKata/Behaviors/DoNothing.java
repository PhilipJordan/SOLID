package MarsRoverKata.Behaviors;

import MarsRoverKata.Alien;

public class DoNothing implements IBehavior {
    private Alien parent;

    public Alien getParent() { return parent; }

    public void setParent(Alien parent) { this.parent = parent; }

    public void executeBehavior() {

    }
}
