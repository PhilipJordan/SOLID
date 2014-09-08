namespace MarsRoverKata
{
    public class Mortar : Projectile
    {
        public const int Range = 10;

        public Mortar(Mars mars)
            : base(mars)
        {
        }

        protected override int MaxRange
        {
            get { return Range; }
        }

        protected override bool IsCollisionDetected(Point desired)
        {
            return false;
        }
    }
}
