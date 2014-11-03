using MarsRoverKata.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata.Behaviors
{
    public class RandomActions : IBehavior
    {
        private readonly Random _random;
        //private Alien _alien;
        public Alien Parent { get; set; }

        public RandomActions(Alien alien)
        {
            _random = new Random();
            //_alien = alien;
        }

        public void DoStuff()
        {
            switch (_random.Next(1, 4))
            {
                case 1:
                    new ForwardCommand(Parent).Execute();
                    break;
                case 2:
                    new BackwardCommand(Parent).Execute();
                    break;
                case 3:
                    new TurnLeftCommand(Parent).Execute();
                    DoStuff();
                    break;
                case 4:
                    new TurnRightCommand(Parent).Execute();
                    DoStuff();
                    break;
            }
        }
    }
}
