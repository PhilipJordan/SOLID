package MarsRoverKata;

import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.Iterables;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Rover extends CombatMovable {
    public Rover(Mars mars) throws CrashException {
        this(mars, mars.getCenterOfThePlanet());
    }

    public Rover(final Mars mars, final Point landingPoint) throws CrashException {
        super(mars, landingPoint);
        setProjectiles(new ArrayList<Projectile>() {
            {
                add(new Missile(mars));
                add(new Missile(mars));
                add(new Missile(mars));
                add(new Mortar(mars));
                add(new Mortar(mars));
                add(new Mortar(mars));
            }
        });
        landOnMars(landingPoint);
    }

    private void landOnMars(Point landingPoint) throws CrashException {
        if (!getMars().isValidPosition(landingPoint)) {
            throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");
        }
        setFacing(Direction.North);
    }
}

