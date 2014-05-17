using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Core;
using NUnit;
using MarsRoverKata;
using MarsRoverKata.Commands;
using FluentAssertions;

namespace UnitTest
{
    class MarsRoverTests{}

    
    public class WhileTestingBasicCommands : GivenCommander 
    {
        [Test]
        public void WhenTurningLeftAndFacingSouth_ThenRoverShouldBeFacingEast()
        {
            //arrangement
            var command = new TurnLeftCommand(rover);
            commander.Accept(command);

            rover.Facing = Direction.South;

            //action
            commander.ExecuteCommands();

            //assertion
            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.East);
        }
    }

    #region WhileTestingBasicCommands

    public class WhenTurningLeft : AndFacingSouth
    {
        protected override void arrangement()
        {
            base.arrangement();

            var command = new TurnLeftCommand(rover);
            commander.Accept(command);
        }

        protected override void action()
        {
            base.action();
            commander.ExecuteCommands();
        }

        [Test]
        public void ThenRoverShouldBeFacingEast()
        {
            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.East);
        }
    }

    public class WhenTurningRight : AndFacingSouth
    {
        protected override void arrangement()
        {
            base.arrangement();

            var command = new TurnRightCommand(rover);
            commander.Accept(command);
        }

        protected override void action()
        {
            base.action();
            commander.ExecuteCommands();
        }

        [Test]
        public void ThenRoverShouldBeFacingWest()
        {
            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.West);
        }
    }

    public class WhenExecutingTurnLeftCommand : AndFacingNorth
    {
        protected override void arrangement()
        {
            base.arrangement();

            var command = new TurnLeftCommand(rover);
            commander.Accept(command);
        }

        protected override void action()
        {
            base.action();
            commander.ExecuteCommands();
        }

        [Test]
        public void ThenRoverShouldBeFacingWest()
        {
            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.West);
        }
    }

    public class WhenExecutingTurnRightCommand : AndFacingNorth
    {
        protected override void arrangement()
        {
            base.arrangement();

            var command = new TurnRightCommand(rover);
            commander.Accept(command);
        }

        protected override void action()
        {
            base.action();
            commander.ExecuteCommands();
        }

        [Test]
        public void ThenRoverShouldBeFacingEast()
        {
            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.East);
        }
    }

    public class WhenExecutingBackCommand : AndFacingNorth
    {
        protected override void arrangement()
        {
            base.arrangement();
            rover.Location = new Point(50, 50);

            var command = new BackwardCommand(rover);
            commander.Accept(command);
        }

        protected override void action()
        {
            base.action();
            commander.ExecuteCommands();
        }

        [Test]
        public void ThenRoverShouldMoveToTheSouth()
        {
            rover.Location.ShouldBeEquivalentTo<Point>(new Point(50, 49));
        }
    }

    public class WhenExecutingForwardCommand : AndFacingNorth
    {
        protected override void arrangement()
        {
            base.arrangement();

            var command = new ForwardCommand(rover);
            commander.Accept(command);
        }

        protected override void action()
        {
            base.action();
            commander.ExecuteCommands();
        }

        [Test]
        public void ThenRoverShouldMoveToTheNorth()
        {
            rover.Location.Should().Be(new Point(0, 1));
        }
    }

    #endregion

    public class WhenGivingCommand : GivenCommander
    {
        private ICommand command;

        protected override void arrangement()
        {
            base.arrangement(); 
            
            command = new ForwardCommand(rover);
        }

        protected override void action()
        {
            base.action();

            commander.Accept(command);
        }

        [Test]
        public void ThenItWillAcceptCommands()
        {
            commander.Commands.Should().Contain(command);
        }
    }

    public class WhenGivingListOfCommands : GivenCommander
    {
        private List<ICommand> commands;

        protected override void arrangement()
        {
            base.arrangement();

            commands = new List<ICommand>() { 
                new ForwardCommand(rover),
                new BackwardCommand(rover),
                new TurnRightCommand(rover),
                new TurnLeftCommand(rover),
            };
        }

        protected override void action()
        {
            base.action();

            commander.Accept(commands);
        }

        [Test]
        public void ThenItWillAcceptCommands()
        {
            commander.Commands.Should().Contain(commands);
        }
    }

    public class WhileTestingCommandFailures : AndListOfCommands
    {
        protected override void arrangement()
        {
            base.arrangement();
            commander.Accept(listOfCommands);
        }

        [Test]
        public void WhenThereAreNoObsticles()
        {
            commander.ExecuteCommands();

            rover.Location.Should().Be(new Point(1, 100));
        }

        [Test]
        public void WhenObsticleIsInForwardPath()
        {
            mars.Accept(new Obsticle(new Point(0, 1)));
            commander.ExecuteCommands();

            rover.Location.Should().Be(new Point(0, 0));
        }

        [Test]
        public void WhenObsticleIsInBackwardPath()
        {
            mars.Accept(new Obsticle(new Point(0, 100)));
            commander.ExecuteCommands();

            rover.Location.Should().Be(new Point(0, 0));
        }

        private void ThenSomething()
        {
            
        }
        
    }

    public class AndListOfCommands : GivenCommander
    {
        protected List<ICommand> listOfCommands;

        protected override void arrangement()
        {
            base.arrangement();

            listOfCommands = new List<ICommand>() 
                            {
                                    new ForwardCommand(rover),
                                    new ForwardCommand(rover),
                                    new ForwardCommand(rover),
                                    new BackwardCommand(rover),
                                    new BackwardCommand(rover),
                                    new BackwardCommand(rover),
                                    new BackwardCommand(rover),
                                    new TurnRightCommand(rover),
                                    new ForwardCommand(rover)
                            };
        }
    }
    
    public class AndFacingNorth : GivenCommander
    { 
        //do nothing. Default is North
    }

    public class AndFacingSouth : GivenCommander
    {
        protected override void arrangement()
        {
            base.arrangement();
            rover.Facing = Direction.South;
        }
    }

    public class GivenCommander : GivenRover
    {
        protected Commander commander;

        protected override void arrangement()
        {
            base.arrangement(); 
            commander = new Commander();
        }
    }

    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void Setup()
        {
            arrangement();
            action();
        }

        [TearDown]
        public virtual void TearDown()
        {
            cleanup();
        }

        protected virtual void cleanup(){}

        protected virtual void arrangement() { }

        protected virtual void action() { }
    }
}
