package MarsRoverKata.Commands;

import MarsRoverKata.Rover;

public class TurnLeftCommand implements ICommand {
    private Rover rover;

    public Rover getRover() {
        return rover;
    }

    public void setRover(Rover rover) {
        this.rover = rover;
    }

    public TurnLeftCommand(Rover rover) {
        this.rover = rover;
    }

    public boolean execute() {
        return rover.turnLeft();
    }
}

