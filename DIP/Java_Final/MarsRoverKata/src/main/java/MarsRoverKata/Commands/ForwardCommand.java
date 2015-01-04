package MarsRoverKata.Commands;

import MarsRoverKata.IMovable;

public class ForwardCommand implements ICommand {
    private IMovable movable;

    public IMovable getMovable() {
        return movable;
    }

    public void setRover(IMovable movable) {
        this.movable = movable;
    }

    public ForwardCommand(IMovable movable) {
        this.movable = movable;
    }

    public boolean execute() {
        return movable.moveForward();
    }
}

