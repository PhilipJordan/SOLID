namespace MarsRoverKata
{
    public class Crater : Obstacle
    {
        public Crater(Point location) :
            base(location)
        {
        }

        public override bool IsDestructable
        {
            get { return false; }
        }
    }
}
