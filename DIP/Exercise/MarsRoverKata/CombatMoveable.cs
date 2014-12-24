using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class CombatMoveable : Movable
    {
        protected List<Projectile> Projectiles { get; set; }

        public CombatMoveable(Mars mars, Point landingPoint)
            : base(mars, landingPoint)
        {
            LoadDefaultAssortmentOfWeapons();
        }

        public bool FireMissle()
        {
            return FireProjectile(typeof(Missile));
        }

        public bool FireMortar()
        {
            return FireProjectile(typeof(Mortar));
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

        private void LoadDefaultAssortmentOfWeapons()
        {
            Projectiles = new List<Projectile>
            {
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars),
                new Missile(Mars)
            };
        }

    }
}
