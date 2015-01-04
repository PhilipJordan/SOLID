package MarsRoverKata.Behaviors;

import MarsRoverKata.Alien;
import MarsRoverKata.Direction;
import MarsRoverKata.Mars;
import MarsRoverKata.Point;

import java.util.Random;

public class WallBuilder implements IBehavior {
    private int Speed;
    private Mars planet;

    private final Random RNG;
    private Alien parent;

    public Alien getParent() { return parent; }

    public void setParent(Alien parent) { this.parent = parent; }

    public WallBuilder(Mars planet)
    {
        this.planet = planet;
        Speed = 3;
        RNG = new Random();
    }

    public void executeBehavior()
    {
        getParent().setFacing(pickDirection());

        for (int i = 0; i < Speed; i++)
        {
            Point previousLocation = getParent().getLocation();
            boolean moveSuccess = getParent().moveForward(); //new ForwardCommand(Parent).Execute();

            if(previousLocation != getParent().getLocation())
                planet.addObstacle(previousLocation); //new Obstacle(previousLocation));
        }
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
