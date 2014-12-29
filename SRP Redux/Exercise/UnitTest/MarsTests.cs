using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit;
using MarsRoverKata;
using MarsRoverKata.Commands;
using FluentAssertions;

namespace UnitTest
{
    class MarsTests{}

    public class WhileWorkingWithRover : GivenRover
    {
        [Test]
        public void WhenRoverIsCreated_ThenLocationShouldBeTheCenterOfThePlanet()
        {
            var expectedLocation = mars.CenterOfThePlanet;
            rover.Location.ShouldBeEquivalentTo<Point>(expectedLocation);
        }

        [Test]
        public void WhenRoverIsCreated_ThenItShouldBeFacingNorth()
        {
            rover.Facing.Should().Be(Direction.North);
        }

        [Test]
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromNorthernToSouthernEdge()
        {
            rover.Location = new Point(0, 100);
            rover.Facing = Direction.North;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(0, 0));
        }

        [Test]
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromSouthernToNorthernEdge()
        {
            rover.Location = new Point(0, 0);
            rover.Facing = Direction.South;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(0, 50));
        }

        [Test]
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromWesternToEasternEdge()
        {
            rover.Location = new Point(0, 0);
            rover.Facing = Direction.West;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(50, 0));
        }

        [Test]
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromEasternToWesternEdge()
        {
            rover.Location = new Point(100, 0);
            rover.Facing = Direction.East;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(0, 0));
        }
    }

    public class WhileWorkingWithSingleTurnCommand : GivenCommander
    {
        [Test]
        public void ThenItWillAcceptSingleCommand()
        {
            AddCommandToCommander(new ForwardCommand(rover));

            commander.Commands.Should().Contain(command);
        }

        [Test]
        public void WhenRoverIsFacingNorthAndTurnsLeft_ThenRoverShouldBeFacingWest()
        {
            SetRoverFacing(Direction.North);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.West);
        }

        [Test]
        public void WhenRoverIsFacingNorthAndTurnsRight_ThenRoverShouldBeFacingEast()
        {
            SetRoverFacing(Direction.North);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.East);
        }

        [Test]
        public void WhenRoverIsFacingEastAndTurnsLeft_ThenRoverShouldBeFacingNorth()
        {
            SetRoverFacing(Direction.East);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.North);
        }

        [Test]
        public void WhenRoverIsFacingEastAndTurnsRight_ThenRoverShouldBeFacingSouth()
        {
            SetRoverFacing(Direction.East);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.South);
        }

        [Test]
        public void WhenRoverIsFacingSouthAndTurnsLeft_ThenRoverShouldBeFacingEast()
        {
            SetRoverFacing(Direction.South);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.East);
        }

        [Test]
        public void WhenRoverIsFacingSouthAndTurnsRight_ThenRoverShouldBeFacingWest()
        {
            SetRoverFacing(Direction.South);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.West);
        }

        [Test]
        public void WhenRoverIsFacingWestAndTurnsLeft_ThenRoverShouldBeFacingSouth()
        {
            SetRoverFacing(Direction.West);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.South);
        }

        [Test]
        public void WhenRoverIsFacingWestAndTurnsRight_ThenRoverShouldBeFacingNorth()
        {
            SetRoverFacing(Direction.West);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            rover.Facing.ShouldBeEquivalentTo<Direction>(Direction.North);
        }

    }

    public class WhileWorkingWithSingleMoveCommand : GivenCommander
    {
        [Test]
        public void WhenRoverIsFacingNorthAndMovesForward_ThenRoverShouldMoveNorth()
        {
            SetRoverFacing(Direction.North);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(24, 25));
        }

        [Test]
        public void WhenRoverIsFacingEastAndMovesForward_ThenRoverShouldMoveEast()
        {
            SetRoverFacing(Direction.East);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(25, 24));
        }

        [Test]
        public void WhenRoverIsFacingSouthAndMovesForward_ThenRoverShouldMoveSouth()
        {
            SetRoverFacing(Direction.South);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(24, 23));
        }

        [Test]
        public void WhenRoverIsFacingWestAndMovesForward_ThenRoverShouldMoveWest()
        {
            SetRoverFacing(Direction.West);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(23, 24));
        }

        [Test]
        public void WhenRoverIsFacingNorthAndMovesBackward_ThenRoverShouldMoveSouth()
        {
            SetRoverFacing(Direction.North);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(24, 23));
        }

        [Test]
        public void WhenRoverIsFacingEastAndMovesBackward_ThenRoverShouldMoveWest()
        {
            SetRoverFacing(Direction.East);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(23, 24));
        }

        [Test]
        public void WhenRoverIsFacingSouthAndMovesBackward_ThenRoverShouldMoveNorth()
        {
            SetRoverFacing(Direction.South);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(24, 25));
        }

        [Test]
        public void WhenRoverIsFacingWestAndMovesBackward_ThenRoverShouldMoveEast()
        {
            SetRoverFacing(Direction.West);
            SetRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            rover.Location.ShouldBeEquivalentTo<Point>(new Point(25, 24));
        }



    }

    public class WhileWorkingWithMultipleCommands : GivenCommander
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

            commander.Accept(listOfCommands);
        }

        [Test]
        public void ThenItWillContainAllCommands()
        {
            commander.Commands.Should().Contain(listOfCommands);
        }

        [Test]
        public void WhenThereAreNoObstacles()
        {
            commander.ExecuteCommands();

            rover.Location.Should().Be(new Point(26, 24));
        }

        [Test]
        public void WhenObstacleIsInForwardPath()
        {
            Obstacle obstacle = new Obstacle(new Point(25, 28));
            mars.AddObstacle(obstacle);
            commander.ExecuteCommands();

            rover.Location.Should().Be(new Point(25, 27));
        }

        [Test]
        public void WhenObstacleIsInBackwardPath()
        {
            Obstacle obstacle = new Obstacle(new Point(25, 24));
            mars.AddObstacle(obstacle);
            commander.ExecuteCommands();

            rover.Location.Should().Be(new Point(25, 25));
        }
    }
  
    public class GivenCommander : GivenRover
    {
        protected Commander commander;
        protected ICommand command;

        protected override void arrangement()
        {
            base.arrangement();
            commander = new Commander();
        }

        protected void AddCommandToCommander(ICommand aCommand)
        {
            command = aCommand;
            commander.Accept(command);
        }

        protected void ExecuteCommands()
        {
            commander.ExecuteCommands();
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

        protected virtual void cleanup() { }

        protected virtual void arrangement() { }

        protected virtual void action() { }
    }
}
