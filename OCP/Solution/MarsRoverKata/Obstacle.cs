namespace MarsRoverKata
{
    public class Obstacle
    {
        public Point Location { get; protected set; }

        public Obstacle(Point location, bool isDestructable)
        {
            Location = location;
            IsDestructable = isDestructable;
        }

        public bool IsDestructable { get; private set; }
    }
}
