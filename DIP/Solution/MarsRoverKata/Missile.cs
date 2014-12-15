namespace MarsRoverKata
{
    public class Missile : Projectile
    {
        public const int Range = 5;

        public Missile(Mars mars)
            : base(mars)
        {
        }

        protected override int MaxRange
        {
            get { return Range; }
        }

        protected override bool IsCollisionDetected(Point desired)
        {
            Point newDestination = desired;
            newDestination = CalculatePositionY(desired, newDestination);
            newDestination = CalculatePositionX(desired, newDestination);
            var obstacle = FindObstacle(newDestination);

            return obstacle != null && obstacle.IsDestructable;
        }
    }
}
