using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Rover : CombatMoveable
    {
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
            Facing = Direction.North;
        }
    }
}
