package MarsRoverKata;

import MarsRoverKata.Commands.*;
import com.google.common.collect.Iterables;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.junit.runners.model.InitializationError;
import org.junit.runners.model.RunnerBuilder;

import java.util.ArrayList;
import java.util.List;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

@RunWith(MarsTests.class)
@Suite.SuiteClasses({MarsTests.WhileWorkingWithObstacle.class, MarsTests.WhileWorkingWithMars.class, MarsTests.WhileWorkingWithRover.class, MarsTests.WhileWorkingWithMissile.class, MarsTests.WhileWorkingWithMortar.class, MarsTests.WhileWorkingWithSingleTurnCommand.class, MarsTests.WhileWorkingWithSingleMoveCommand.class, MarsTests.WhileWorkingWithMultipleCommands.class
})
public class MarsTests extends Suite {

    public MarsTests(Class<?> klass, RunnerBuilder builder) throws InitializationError {
        super(klass, builder);
    }

    public static class WhileWorkingWithObstacle extends GivenObstacle {
        @Test
        public void WhenCalculatingObstructedFinalPosition_ThenLocationWillNotChange() {
            Point currentPosition = new Point(9, 10);
            Point desiredPosition = new Point(10, 10);
            Point finalPosition = mars.calculateFinalPosition(currentPosition, desiredPosition);
            assert (finalPosition.equals(currentPosition));
        }

        @Test
        public void WhenCalculatingFinalPosition_ThenLocationWillEqualExpectedPostion() {
            Point currentPosition = new Point(0, 0);
            Point desiredPosition = new Point(50, 50);
            Point finalPosition = mars.calculateFinalPosition(currentPosition, desiredPosition);
            assert (finalPosition.equals(desiredPosition));
        }

        @Test
        public void WhenCheckingIsValidPositon_ThenValidPositionsShouldBeTrue() {
            boolean isValid = mars.isValidPosition(new Point(0, 0));
            assertTrue(isValid);
        }

        @Test
        public void WhenCheckingIsValidPositon_ThenInvalidPositionsShouldBeFalse() {
            boolean isValid = mars.isValidPosition(obstacleLocation);
            assertTrue(!isValid);
        }

        @Test
        public void ThenItWillAcceptObstacles() {
            assertTrue(mars.getObstacles().contains(obstacle));
        }
    }

    public static class WhileWorkingWithMars extends GivenMars {
        @Test
        public void WhenMarsIsCreated_ThenSurfaceBoundsShouldBeDefined() {
            assertEquals(mars.getBounds().getHeight(), (50));
            assertEquals(mars.getBounds().getWidth(), (50));
        }
    }

    public static class WhileWorkingWithRover extends GivenRover {
        @Test
        public void WhenRoverIsCreated_ThenLocationShouldBeTheCenterOfThePlanet() {
            Point expectedLocation = mars.getCenterOfThePlanet();
            assertEquals(rover.getLocation(), expectedLocation);
        }

        @Test
        public void WhenRoverIsCreated_ThenItShouldBeFacingNorth() {
            assertEquals(rover.getFacing(), (Direction.North));
        }

        @Test
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromNorthernToSouthernEdge() {
            rover.setLocation(new Point(0, 100));
            rover.setFacing(Direction.North);
            rover.moveForward();
            assertEquals(rover.getLocation(), (new Point(0, 0)));
        }

        @Test
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromSouthernToNorthernEdge() {
            rover.setLocation(new Point(0, 0));
            rover.setFacing(Direction.South);
            rover.moveForward();
            assertEquals(rover.getLocation(), (new Point(0, 50)));
        }

        @Test
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromWesternToEasternEdge() {
            rover.setLocation(new Point(0, 0));
            rover.setFacing(Direction.West);
            rover.moveForward();
            assertEquals(rover.getLocation(), (new Point(50, 0)));
        }

        @Test
        public void WhenMovingBeyondBoundsOfTheWorld_ThenWrapFromEasternToWesternEdge() {
            rover.setLocation(new Point(100, 0));
            rover.setFacing(Direction.East);
            rover.moveForward();
            assertEquals(rover.getLocation(), (new Point(0, 0)));
        }
    }

    public static class WhileWorkingWithMissile extends GivenMissile {
        @Test
        public void WhenMissileIsLaunched_AndNoObstaclesInTheWay_ThenANewObstacleCreated() {
            Point position = new Point(25, 25);
            Point expectedObstaclePosition = new Point(25, 20);
            int expectedCount = mars.getObstacles().size() + 1;

            missile.launch(Direction.South, position);
            Obstacle actualObstacle = Iterables.getLast(mars.getObstacles(), null);

            assertEquals(mars.getObstacles().size(), expectedCount);
            assertEquals(actualObstacle.getLocation(), expectedObstaclePosition);
            assertTrue(actualObstacle instanceof Crater);
        }

        @Test
        public void WhenMissileIsLaunched_AndObstacleInTheWay_ThenTheObstacleIsDestroyed() {
            Point position = new Point(obstacle.getLocation().getX(), obstacle.getLocation().getY() + 5);
            int expectedCount = mars.getObstacles().size() - 1;
            missile.launch(Direction.South, position);
            assertEquals(mars.getObstacles().size(), expectedCount);
        }

        @Test
        public void WhenMissileIsLaunched_AndObstacleInTheWay_AndObstacleIsNotDestructable_ThenTheObstacleIsSkipped_AndANewObstacleCreated() {
            int anyNumberNotEqualToProjectileRange = 83438;
            mars.removeObstacle(obstacle);
            obstacle = new Crater(obstacle.getLocation());
            mars.addObstacle(obstacle);
            Point position = new Point(obstacle.getLocation().getX(), obstacle.getLocation().getY() + anyNumberNotEqualToProjectileRange);
            int expectedCount = mars.getObstacles().size() + 1;
            missile.launch(Direction.South, position);
            assertEquals(mars.getObstacles().size(), expectedCount);
        }

        @Test
        public void WhenMissileIsLaunchedNearTheEdge_AndNoObstaclesInTheWay_ThenANewObstacleCreated_AndItsLocationWrappedAroundTheEdge() {
            Point position = new Point(25, 0);
            Point expectedObstaclePosition = new Point(25, 46);
            int expectedCount = mars.getObstacles().size() + 1;

            missile.launch(Direction.South, position);
            Obstacle actualObstacle = Iterables.getLast(mars.getObstacles(), null);

            assertEquals(mars.getObstacles().size(), expectedCount);
            assertEquals(actualObstacle.getLocation(), expectedObstaclePosition);
            assertTrue(actualObstacle instanceof Crater);
        }
    }

    public static class WhileWorkingWithMortar extends GivenMortar {
        @Test
        public void WhenMortarIsLaunched_AndNoObstaclesInTheLandingPostion_ThenANewObstacleCreated() {
            Point position = new Point(25, 25);
            Point expectedObstaclePosition = new Point(25, 15);
            int expectedCount = mars.getObstacles().size() + 1;

            mortar.launch(Direction.South, position);
            Obstacle actualObstacle = Iterables.getLast(mars.getObstacles(), null);

            assertEquals(mars.getObstacles().size(), expectedCount);
            assertEquals(actualObstacle.getLocation(), expectedObstaclePosition);
            assertTrue(actualObstacle instanceof Crater);
        }

        @Test
        public void WhenMortarIsLaunched_AndObstacleInTravelPath_AndNoObstaclesInTheLandingPostion_ThenANewObstacleCreated_AndPreviousObstacleIsNotDestroyed() {
            Point position = new Point(obstacle.getLocation().getX(), obstacle.getLocation().getY() + (Mortar.Range / 2));
            Point expectedObstaclePosition = new Point(obstacle.getLocation().getX(), obstacle.getLocation().getY() - (Mortar.Range / 2));
            int expectedCount = mars.getObstacles().size() + 1;

            mortar.launch(Direction.South, position);
            Obstacle actualObstacle = Iterables.getLast(mars.getObstacles(), null);

            assertEquals(mars.getObstacles().size(), expectedCount);
            assertEquals(actualObstacle.getLocation(), expectedObstaclePosition);
            assertTrue(actualObstacle instanceof Crater);
        }

        @Test
        public void WhenMortarIsLaunched_AndObstacleInThePosition_ThenTheObstacleIsDestroyed() {
            Point position = new Point(obstacle.getLocation().getX(), obstacle.getLocation().getY() + Mortar.Range);
            Point expectedObstaclePosition = obstacle.getLocation();
            int expectedCount = mars.getObstacles().size() - 1;

            mortar.launch(Direction.South, position);
            Obstacle actualObstacle = Iterables.getLast(mars.getObstacles(), null);
            assertEquals(mars.getObstacles().size(), expectedCount);
        }

        @Test
        public void WhenMortarIsLaunchedNearAnEdge_ThenAnObstacleIsCreated_AndItsLocationWrappedAroundTheEdge() {
            Point position = new Point(25, 0);
            Point expectedObstaclePosition = new Point(25, 41);
            int expectedCount = mars.getObstacles().size() + 1;

            mortar.launch(Direction.South, position);

            Obstacle actualObstacle = Iterables.getLast(mars.getObstacles(), null);

            assertEquals(mars.getObstacles().size(), (expectedCount));
            assertEquals(actualObstacle.getLocation(), (expectedObstaclePosition));
            assertTrue(actualObstacle instanceof Crater);
        }
    }

    public static class WhileWorkingWithSingleTurnCommand extends GivenCommander {
        @Test
        public void ThenItWillAcceptSingleCommand() {
            AddCommandToCommander(new ForwardCommand(rover));

            assertTrue(commander.getCommands().contains(command));
        }

        @Test
        public void WhenRoverIsFacingNorthAndTurnsLeft_ThenRoverShouldBeFacingWest() {
            setRoverFacing(Direction.North);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.West);
        }

        @Test
        public void WhenRoverIsFacingNorthAndTurnsRight_ThenRoverShouldBeFacingEast() {
            setRoverFacing(Direction.North);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.East);
        }

        @Test
        public void WhenRoverIsFacingEastAndTurnsLeft_ThenRoverShouldBeFacingNorth() {
            setRoverFacing(Direction.East);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.North);
        }

        @Test
        public void WhenRoverIsFacingEastAndTurnsRight_ThenRoverShouldBeFacingSouth() {
            setRoverFacing(Direction.East);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.South);
        }

        @Test
        public void WhenRoverIsFacingSouthAndTurnsLeft_ThenRoverShouldBeFacingEast() {
            setRoverFacing(Direction.South);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.East);
        }

        @Test
        public void WhenRoverIsFacingSouthAndTurnsRight_ThenRoverShouldBeFacingWest() {
            setRoverFacing(Direction.South);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.West);
        }

        @Test
        public void WhenRoverIsFacingWestAndTurnsLeft_ThenRoverShouldBeFacingSouth() {
            setRoverFacing(Direction.West);
            AddCommandToCommander(new TurnLeftCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.South);
        }

        @Test
        public void WhenRoverIsFacingWestAndTurnsRight_ThenRoverShouldBeFacingNorth() {
            setRoverFacing(Direction.West);
            AddCommandToCommander(new TurnRightCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getFacing(), Direction.North);
        }

    }

    public static class WhileWorkingWithSingleMoveCommand extends GivenCommander {
        @Test
        public void WhenRoverIsFacingNorthAndMovesForward_ThenRoverShouldMoveNorth() {
            setRoverFacing(Direction.North);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(24, 25));
        }

        @Test
        public void WhenRoverIsFacingEastAndMovesForward_ThenRoverShouldMoveEast() {
            setRoverFacing(Direction.East);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(25, 24));
        }

        @Test
        public void WhenRoverIsFacingSouthAndMovesForward_ThenRoverShouldMoveSouth() {
            setRoverFacing(Direction.South);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(24, 23));
        }

        @Test
        public void WhenRoverIsFacingWestAndMovesForward_ThenRoverShouldMoveWest() {
            setRoverFacing(Direction.West);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new ForwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(23, 24));
        }

        @Test
        public void WhenRoverIsFacingNorthAndMovesBackward_ThenRoverShouldMoveSouth() {
            setRoverFacing(Direction.North);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(24, 23));
        }

        @Test
        public void WhenRoverIsFacingEastAndMovesBackward_ThenRoverShouldMoveWest() {
            setRoverFacing(Direction.East);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(23, 24));
        }

        @Test
        public void WhenRoverIsFacingSouthAndMovesBackward_ThenRoverShouldMoveNorth() {
            setRoverFacing(Direction.South);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(24, 25));
        }

        @Test
        public void WhenRoverIsFacingWestAndMovesBackward_ThenRoverShouldMoveEast() {
            setRoverFacing(Direction.West);
            setRoverLocation(new Point(24, 24));
            AddCommandToCommander(new BackwardCommand(rover));
            ExecuteCommands();

            assertEquals(rover.getLocation(), new Point(25, 24));
        }


    }

    public static class WhileWorkingWithMultipleCommands extends GivenCommander {
        protected List<ICommand> listOfCommands;

        @Override
        protected void arrangement() throws CrashException {
            super.arrangement();

            listOfCommands = new ArrayList<ICommand>() {{
                add(new ForwardCommand(rover));
                add(new ForwardCommand(rover));
                add(new ForwardCommand(rover));
                add(new BackwardCommand(rover));
                add(new BackwardCommand(rover));
                add(new BackwardCommand(rover));
                add(new BackwardCommand(rover));
                add(new TurnRightCommand(rover));
                add(new ForwardCommand(rover));
            }};
            commander.accept(listOfCommands);
        }

        @Test
        public void ThenItWillContainAllCommands() {
            assertTrue(commander.getCommands().containsAll(listOfCommands));
        }

        @Test
        public void WhenThereAreNoObstacles() {
            commander.executeCommands();
            assertEquals(rover.getLocation(), (new Point(26, 24)));
        }

        @Test
        public void WhenObstacleIsInForwardPath() {
            Obstacle obstacle = new Obstacle(new Point(25, 28));
            mars.addObstacle(obstacle);
            commander.executeCommands();
            assertEquals(rover.getLocation(), (new Point(25, 27)));
        }

        @Test
        public void WhenObstacleIsInBackwardPath() {
            Obstacle obstacle = new Obstacle(new Point(25, 24));
            mars.addObstacle(obstacle);
            commander.executeCommands();
            assertEquals(rover.getLocation(), (new Point(25, 25)));
        }
    }

    public static class GivenCommander extends GivenRover {
        protected Commander commander;
        protected ICommand command;

        @Override
        protected void arrangement() throws CrashException {
            super.arrangement();
            commander = new Commander();
        }

        protected void AddCommandToCommander(ICommand aCommand) {
            command = aCommand;
            commander.accept(command);
        }

        protected void ExecuteCommands() {
            commander.executeCommands();
        }
    }

    public static class GivenRover extends GivenObstacle {
        protected Rover rover;

        @Override
        protected void arrangement() throws CrashException {
            super.arrangement();
            rover = new Rover(mars);
        }

        protected void setRoverFacing(Direction aFacing) {
            rover.setFacing(aFacing);
        }

        protected void setRoverLocation(Point aLocation) {
            rover.setLocation(aLocation);
        }
    }

    public static class GivenMissile extends GivenObstacle {
        protected Missile missile;

        @Override
        protected void arrangement() throws CrashException {
            super.arrangement();
            missile = new Missile(mars);
        }
    }

    public static class GivenMortar extends GivenObstacle {
        protected Mortar mortar;

        @Override
        protected void arrangement() throws CrashException {
            super.arrangement();
            mortar = new Mortar(mars);
        }
    }

    public static class GivenObstacle extends GivenMars {
        protected Obstacle obstacle;
        protected Point obstacleLocation;

        @Override
        protected void arrangement() throws CrashException {
            super.arrangement();

            obstacleLocation = new Point(10, 10);
            obstacle = new Obstacle(new Point(10, 10));
            mars.addObstacle(obstacle);
        }
    }

    public static class GivenMars extends Testbase {
        protected Mars mars;

        @Override
        protected void arrangement() throws CrashException {
            super.arrangement();
            this.mars = new Mars(new Size(50, 50));
        }

    }

    public static class Testbase {
        protected void arrangement() throws CrashException {
        }

        protected void action() {
        }

        protected void cleanup() {
        }

        @Before
        public void Setup() throws CrashException {
            arrangement();
            action();
        }

        @After
        public void TearDown() {
            cleanup();
        }

    }
}