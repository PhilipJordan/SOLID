package MarsRoverKata.Commands;

import MarsRoverKata.IMovable;

public class BackwardCommand implements ICommand {
    private IMovable movable;

    public IMovable getMovable() {
        return movable;
    }

    public void setRover(IMovable movable) {
        this.movable = movable;
    }

    public BackwardCommand(IMovable movable) {
        this.movable = movable;
    }

    public boolean execute() {
        return movable.moveBackward();
    }
}

