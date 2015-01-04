package MarsRoverKata;

import MarsRoverKata.Behaviors.DoNothing;
import MarsRoverKata.Behaviors.IBehavior;

public class Alien extends CombatMovable implements IObstacle {
    private IBehavior myBehavior;

    public Alien(Mars mars, Point location)
    {
        this(mars, location, new DoNothing());
    }

    public Alien(Mars mars, Point location, IBehavior myBehavior) {
        super(mars, location);
        myBehavior.setParent(this);
        setMyBehavior(myBehavior);
    }

    public IBehavior getMyBehavior() { return myBehavior; }

    public void setMyBehavior(IBehavior myBehavior) { this.myBehavior = myBehavior; }

    public void doStuff()
    {
        getMyBehavior().executeBehavior();
    }

    public boolean isDestructable() {
        return true;
    }
}
