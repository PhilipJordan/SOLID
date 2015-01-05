package MarsRoverKata;

import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.Iterables;

import java.util.ArrayList;
import java.util.List;

public class CombatMovable extends Movable {
    private List<Projectile> projectiles;

    protected List<Projectile> getProjectiles() { return projectiles; }

    protected void setProjectiles(List<Projectile> projectiles) { this.projectiles = projectiles; }

    public CombatMovable(Mars mars, Point landingPoint) {
        super(mars, landingPoint);
        loadDefaultAssortmentOfWeapons();
    }

    public boolean fireMissile() {
        return fireProjectile(Missile.class);
    }

    public boolean fireMortar() {
        return fireProjectile(Mortar.class);
    }

    public boolean fireProjectile(final Class<? extends Projectile> type) {
        Projectile projectileToFire = Iterables.get(Collections2.filter(projectiles, new Predicate<Projectile>() {
            @Override
            public boolean apply(Projectile input) {
                return (input.getClass().isAssignableFrom(type));
            }
        }), 1, null);
        if (projectileToFire == null) {
            return false;
        }
        projectileToFire.launch(getFacing(), getLocation());
        projectiles.remove(projectileToFire);
        return true;
    }

    private void loadDefaultAssortmentOfWeapons() {
        setProjectiles(new ArrayList<Projectile>() {
            {
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
                new Missile(getMars());
            }
        });
    }

}
