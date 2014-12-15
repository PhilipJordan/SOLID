﻿using MarsRoverKata.Behaviors;

namespace MarsRoverKata
{
    public class Alien : CombatMoveable, IObstacle
    {
        public IBehavior MyBehavior { get; set; }

        public Alien(Mars mars, Point location)
            : this(mars, location, new DoNothing())
        {}

        public Alien(Mars mars, Point location, IBehavior behavior)
            : base(mars, location)
        {
            behavior.Parent = this;
            MyBehavior = behavior;
        }

        public virtual void DoStuff()
        {
            MyBehavior.ExecuteBehavior();
        }

        public virtual bool IsDestructable
        {
            get { return true; }
        }
    }
}
