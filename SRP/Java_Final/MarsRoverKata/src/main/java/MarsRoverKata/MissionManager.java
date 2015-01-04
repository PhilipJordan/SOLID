package MarsRoverKata;

import MarsRoverKata.Commands.*;
import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;
import java.util.List;

public class MissionManager {
    private Rover rover;

    public Rover getRover() {
        return rover;
    }

    public Mars planet;

    public Mars getPlanet() {
        return planet;
    }

    public Size getBounds() { return getPlanet().getBounds(); }

    public List<Obstacle> getObstacles() { return getPlanet().getObstacles(); }

    private final Commander _commander;

    public MissionManager(Rover rover) {
        this.rover = rover;
        planet = rover.getMars();
        _commander = new Commander();
    }

    public String acceptCommands(String commandString) {
        _commander.setCommands(new ArrayList<ICommand>());

        char[] commands = commandString.toLowerCase().toCharArray();
        boolean success = true;
        for (char command : commands) {
            success = acceptCommand(success, command);
        }

        return success ? StringUtils.EMPTY : "Some invalid commands were found!!!";
    }

    private boolean acceptCommand(boolean success, char command) {
        if (command == 'f')
            _commander.accept(new ForwardCommand(rover));
        else if (command == 'b')
            _commander.accept(new BackwardCommand(rover));
        else if (command == 'r')
            _commander.accept(new TurnRightCommand(rover));
        else if (command == 'l')
            _commander.accept(new TurnLeftCommand(rover));
        else
            success = false;
        return success;
    }

    public String executeMission() {
        boolean success = _commander.executeCommands();
        return success ? StringUtils.EMPTY : "An error occured while executing commands";
    }

    public void addObstacle(int x, int y, String type) {
        Point location = new Point(x, y);
        Obstacle obstacle = createObstacle(location, type);
        getPlanet().addObstacle(obstacle);
    }

    private Obstacle createObstacle(Point location, String type) {
        return new Obstacle(location);
    }
}

