using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class Missile
    {
        public Missile(Mars mars)
        {
            Mars = mars;
        }

        private Mars Mars { get; set; }
        private static readonly Dictionary<Direction, Point> PositionalAdjustments = new Dictionary<Direction, Point>() 
        { 
            { Direction.North, new Point(0, 1) },
            { Direction.South, new Point(0, -1) },
            { Direction.East, new Point(1, 0) },
            { Direction.West, new Point(-1, 0) }
        };

        protected virtual int MaxDistance 
        { 
            get { return 10; } 
        }

        public virtual void Launch(Direction facing, Point location)
        {
            bool collidedWithTarget = false;
            int moveIndex = 0;
            Point target = location;
            while (!collidedWithTarget && moveIndex < MaxDistance)
            {
                target = CreateDesiredPosition(1, facing, target);
                collidedWithTarget = IsCollisionDetected(target);
                moveIndex++;
            }
            HitTarget(target);
        }

        protected Point CreateDesiredPosition(int adjustmentFactor, Direction facing, Point location)
        {
            var adjustment = PositionalAdjustments[facing] * adjustmentFactor;
            return location + adjustment;
        }

        protected virtual bool IsCollisionDetected(Point desired)
        {
            Point newDestination = desired;
            newDestination = CalculatePositionY(desired, newDestination);
            newDestination = CalculatePositionX(desired, newDestination);
            var obstacle = FindObstacle(newDestination);

            //TODO: Look at this stuff!
            if (obstacle != null && (obstacle.GetType() != typeof(Crater)))
            {
                DestroyObstacle(obstacle);
                return true;
            }

            return false;
        }

        private Point CalculatePositionX(Point desired, Point newDestination)
        {
            if (desired.X > Mars.Bounds.Width)
            {
                newDestination = new Point(0, desired.Y);
            }
            if (desired.X < 0)
            {
                newDestination = new Point(Mars.Bounds.Width, desired.Y);
            }
            return newDestination;
        }

        private Point CalculatePositionY(Point desired, Point newDestination)
        {
            if (desired.Y > Mars.Bounds.Height)
            {
                newDestination = new Point(desired.X, 0);
            }
            if (desired.Y < 0)
            {
                newDestination = new Point(desired.X, Mars.Bounds.Height);
            }
            return newDestination;
        }

        private IObstacle FindObstacle(Point point)
        {
            return Mars.Obstacles.SingleOrDefault(x => x.Location.Equals(point));
        }

        private void DestroyObstacle(IObstacle obstacle)
        {
            Mars.RemoveObstacle(obstacle);
        }

        protected void HitTarget(Point point)
        {
            var obstacle = FindObstacle(point);

            //TODO: Look at this stuff!
            if (obstacle != null && (obstacle.GetType() != typeof(Crater)))
            {
                DestroyObstacle(obstacle);
            }
            else if (obstacle == null)
            {
                obstacle = new Crater(point);
                Mars.AddObstacle(obstacle);
            }
        }
    }
}
