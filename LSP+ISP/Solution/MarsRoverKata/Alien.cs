
namespace MarsRoverKata
{
    public class Alien : Moveable, IObstacle
    {
        Mars _mars;
        Point location;

        public Alien(Mars mars, Point location)
        {
            _mars = mars;
            this.location = location;
        }

        public Point Location
        {
            get { return location; }
        }

        public bool IsDestructable
        {
            get { return true; }
        }
    }
}
