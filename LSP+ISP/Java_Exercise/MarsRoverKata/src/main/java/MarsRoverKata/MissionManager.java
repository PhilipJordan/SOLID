package MarsRoverKata;

import MarsRoverKata.Commands.*;
import org.apache.commons.lang3.StringUtils;

import java.beans.EventHandler;
import java.util.ArrayList;

public class MissionManager {
    private Rover rover;

    public Rover getRover() {
        return rover;
    }

    public Mars planet;

    public Mars getPlanet() {
        return planet;
    }

    private final Commander _commander;

    public MissionManager(Rover rover) {
        this.rover = rover;
        planet = rover.getMars();
        _commander = new Commander();
        //MissionManager MissionManager = EventHandler.create(this.getClass(), this, "updateAliens", "");
        EventHandler eventHandler = new EventHandler(this, "updateAliens", null, null);
        _commander.setEventHandler(eventHandler);
    }

    //TODO: EventHandler implementation
    public void updateAliens() {
        getPlanet().updateAliens();
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
        else if (command == 'm')
            _commander.accept(new FireMissileCommand(rover));
        else if (command == 'g')
            _commander.accept(new FireMortarCommand(rover));
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
        IObstacle obstacle = createObstacle(location, type);
        getPlanet().addObstacle(obstacle);
    }

    private IObstacle createObstacle(Point location, String type) {
        if (type.equalsIgnoreCase("Alien")) {
            return new Alien(getPlanet(), location);
        }
        return new Obstacle(location);
    }
}

