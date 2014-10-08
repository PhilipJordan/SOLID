
namespace MarsRoverKata
{
    public class Alien : Movable, IObstacle
    {
        public Alien(Mars mars, Point location)
            : base(mars)
        {
            Location = location;
        }

        public virtual bool IsDestructable
        {
            get { return true; }
        }
    }
}
