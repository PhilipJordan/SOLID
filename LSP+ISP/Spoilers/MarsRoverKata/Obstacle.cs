namespace MarsRoverKata
{
    public class Obstacle
    {
        public Point Location { get; private set; }

        public Obstacle(Point location)
        {
            Location = location;
        }

        public virtual bool IsDestructable { get { return true; } }
    }
}
