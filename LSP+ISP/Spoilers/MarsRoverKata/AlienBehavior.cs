using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverKata.Commands;

namespace MarsRoverKata
{
    public class AlienBehavior
    {
        private readonly Random _random;

        public AlienBehavior()
        {
            _random = new Random();
        }

        public void MoveAlien(Alien alien)
        {
            switch (_random.Next(1, 4))
            {
                case 1:
                    new ForwardCommand(alien).Execute();
                    break;
                case 2:
                    new BackwardCommand(alien).Execute();
                    break;
                case 3:
                    new TurnLeftCommand(alien).Execute();
                    MoveAlien(alien);
                    break;
                case 4:
                    new TurnRightCommand(alien).Execute();
                    MoveAlien(alien);
                    break;
            }
        }
    }
}
