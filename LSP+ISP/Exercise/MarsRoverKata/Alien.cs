
namespace MarsRoverKata
{
    public class Alien : IObstacle
    {
        public Alien(Mars mars, Point location)
        {
        }

        public Point Location
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsDestructable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
