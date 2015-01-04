package MarsRoverKata.Commands;

import MarsRoverKata.Rover;

public class TurnRightCommand implements ICommand {
    private Rover rover;

    public Rover getMovable() {
        return rover;
    }

    public void setRover(Rover movable) {
        this.rover = movable;
    }

    public TurnRightCommand(Rover movable) {
        this.rover = movable;
    }

    public boolean execute() {
        return rover.turnRight();
    }

}
