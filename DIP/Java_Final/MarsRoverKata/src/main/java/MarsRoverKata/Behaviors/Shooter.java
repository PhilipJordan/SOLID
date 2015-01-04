package MarsRoverKata.Behaviors;

import MarsRoverKata.Alien;
import MarsRoverKata.Direction;

import java.util.Random;

public class Shooter implements IBehavior {
    private Alien parent;

    public Alien getParent() { return parent; }

    public void setParent(Alien parent) { this.parent = parent; }
    private int Speed;
    private final Random RNG;

    public Shooter()
    {
        Speed = 3;
        RNG = new Random();
    }

    public void executeBehavior()
    {
        getParent().setFacing(pickDirection());

        for (int i = 0; i < Speed; i++)
        {
            //var delta = Target.Location - Parent.Location;

            //var targetDirection = directionToTarget(delta);

            getParent().moveForward(); // new ForwardCommand(Parent).Execute() : new TurnRightCommand(Parent).Execute();
        }

        getParent().setFacing(pickDirection());

        getParent().fireMissile();
    }

    private Direction pickDirection()
    {
        switch (RNG.nextInt(4))
        {
            case 0:
                return Direction.North;
            case 1:
                return Direction.East;
            case 2:
                return Direction.South;
            case 3:
                return Direction.West;
        }

        return Direction.North;
    }
}
