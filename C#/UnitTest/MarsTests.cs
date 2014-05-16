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
    class MarsTests{}

    public class WhileWorkingWithAnObsticle : GivenObsticle
    {
        [Test]
        public void WhenCalculatingObstructedFinalPosition_ThenLocationWillNotChange()
        {
            var currentPosition = new Point(9, 10);
            var desiredPosition = new Point(10, 10);
            var finalPosition = mars.CalculateFinalPosition(currentPosition, desiredPosition);
            finalPosition.Should().Be(currentPosition);
        }

        [Test]
        public void WhenCalculatingFinalPosition_ThenLocationWillEqualExpectedPostion()
        {
            var currentPosition = new Point(0, 0);
            var desiredPosition = new Point(50, 50);
            var finalPosition = mars.CalculateFinalPosition(currentPosition, desiredPosition);
            finalPosition.Should().Be(desiredPosition);
        }

        [Test]
        public void WhenCheckingIsValidPositon_ThenValidPositionsShouldBeTrue()
        {
            bool isValid = mars.IsValidPosition(new Point(0, 0));

            isValid.Should().BeTrue();
        }

        [Test]
        public void WhenCheckingIsValidPositon_ThenInvalidPositionsShouldBeFalse()
        {
            bool isValid = mars.IsValidPosition(obsticleLocation);

            isValid.Should().BeFalse();
        }



    }

    public class WhenConstructingARover : GivenRover
    {
        [Test]
        public void ThenLocationShouldBeZero()
        {
            rover.Location.ShouldBeEquivalentTo<Point>(new Point(0, 0));
        }

        [Test]
        public void ThenItShouldBeFacingNorth()
        {
            rover.Facing.Should().Be(Direction.North);
        }
    }

    public class WhenMovingBeyondBoundsOfTheWorld : GivenRover
    {
        [Test]
        public void ThenWrapFromNorthernToSouthernEdge()
        {
            rover.Location = new Point(0, 100);
            rover.Facing = Direction.North;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(0, 0));
        }

        [Test]
        public void ThenWrapFromSouthernToNorthernEdge()
        {
            rover.Location = new Point(0, 0);
            rover.Facing = Direction.South;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(0, 100));
        }

        [Test]
        public void ThenWrapFromWesternToEasternEdge()
        {
            rover.Location = new Point(0, 0);
            rover.Facing = Direction.West;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(100, 0));
        }

        [Test]
        public void ThenWrapFromEasternToWesternEdge()
        {
            rover.Location = new Point(100, 0);
            rover.Facing = Direction.East;
            rover.MoveForward();

            rover.Location.Should().Be(new Point(0, 0));
        }
    }

    public class GivenRover : GivenObsticle
    {
        protected Rover rover;

        protected override void arrangement()
        {
            base.arrangement();

            rover = new Rover(mars);
        }
    }

    public class GivenObsticle : GivenMars
    {
        protected Obsticle obsticle;
        protected Point obsticleLocation;

        protected override void arrangement()
        {
            base.arrangement();

            obsticleLocation = new Point(10, 10);
            obsticle = new Obsticle(new Point(10, 10));
            mars.Accept(obsticle);
        }

        [Test]
        public void ThenItWillAcceptObsticles()
        {
            mars.Obsticles.Should().Contain(obsticle);
        }

    }

    public class GivenMars : TestBase
    {
        protected Mars mars;

        protected override void arrangement()
        {
            base.arrangement();
            mars = new Mars();
        }

        [Test]
        public void ThenSurfaceBoundsShouldBeDefined()
        {
            mars.Bounds.Height.Should().Be(100);
            mars.Bounds.Width.Should().Be(100);
        }
    }
}
