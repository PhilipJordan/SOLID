package MarsRoverKata.Commands;

import MarsRoverKata.Rover;

public class ForwardCommand implements ICommand {
    private Rover rover;

    public Rover getRover() {
        return rover;
    }

    public void setRover(Rover rover) {
        this.rover = rover;
    }

    public ForwardCommand(Rover rover) {
        this.rover = rover;
    }

    public boolean execute() {
        return rover.moveForward();
    }
}

