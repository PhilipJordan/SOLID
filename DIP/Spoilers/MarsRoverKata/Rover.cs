using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Rover : Movable
    {
        private List<Projectile> Projectiles { get; set; }

        public Rover(Mars mars)
            : this(mars, mars.CenterOfThePlanet)
        { }

        public Rover(Mars mars, Point landingPoint)
            : base(mars, landingPoint)
        {
            Projectiles = new List<Projectile>
            {
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Mortar(Mars),
                new Mortar(Mars),
                new Mortar(Mars)
            };
            LandOnMars(landingPoint);
        }

        private void LandOnMars(Point landingPoint)
        {
            if (!Mars.IsValidPosition(landingPoint))
                throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");
            //Location = landingPoint;
            Facing = Direction.North;
        }

        public bool FireProjectile(Type t)
        {
            var projectileToFire = Projectiles.FirstOrDefault(p => p.GetType() == t);
            if (projectileToFire == null)
            {
                return false;
            }
            projectileToFire.Launch(Facing, Location);
            Projectiles.Remove(projectileToFire);
            return true;
        }
    }
}
