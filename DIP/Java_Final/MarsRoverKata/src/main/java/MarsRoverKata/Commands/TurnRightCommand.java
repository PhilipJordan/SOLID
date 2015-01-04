package MarsRoverKata.Commands;

import MarsRoverKata.IMovable;

public class TurnRightCommand implements ICommand {
    private IMovable movable;

    public IMovable getMovable() {
        return movable;
    }

    public void setRover(IMovable movable) {
        this.movable = movable;
    }

    public TurnRightCommand(IMovable movable) {
        this.movable = movable;
    }

    public boolean execute() {
        return movable.turnRight();
    }

}
