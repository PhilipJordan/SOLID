package MarsRoverKata;

import MarsRoverKata.Commands.*;
import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;

public class MissionManager {
    private Rover rover;

    public Rover getRover() {
        return rover;
    }

    public Mars Planet;

    public Mars getPlanet() {
        return Planet;
    }

    private final Commander _commander;

    public MissionManager(Rover rover) {
        this.rover = rover;
        Planet = rover.getMars();
        _commander = new Commander();
        // _commander.CommandExecuted. += updateAliens;
    }

    // TODO: EventHandler implementation
//    private void updateAliens(Object sender, EventArgs e) {
//        Planet.UpdateAliens();
//    }

    public String acceptCommands(String commandString) {
        _commander.setCommands(new ArrayList<ICommand>());

        char[] commands = commandString.toLowerCase().toCharArray();
        boolean success = true;
        for (char command : commands) {
            success = AcceptCommand(success, command);
        }

        return success ? StringUtils.EMPTY : "Some invalid commands were found!!!";
    }

    private boolean AcceptCommand(boolean success, char command) {
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

    public String ExecuteMission() {
        boolean success = _commander.executeCommands();
        return success ? StringUtils.EMPTY : "An error occured while executing commands";
    }

    public void AddObstacle(int x, int y, String type) {
        Point location = new Point(x, y);
        IObstacle obstacle = CreateObstacle(location, type);
        Planet.addObstacle(obstacle);
    }

    private IObstacle CreateObstacle(Point location, String type) {
        if (type.equalsIgnoreCase("Alien")) {
            return new Alien(Planet, location);
        }
        return new Obstacle(location);
    }
}

