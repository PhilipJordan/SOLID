package MarsRoverKata.Commands;

import MarsRoverKata.Mortar;
import MarsRoverKata.Rover;

public class FireMortarCommand implements ICommand {
    private Rover rover;

    public Rover getRover() {
        return rover;
    }

    public void setRover(Rover rover) {
        this.rover = rover;
    }

    public FireMortarCommand(Rover rover) {
        this.rover = rover;
    }

    public boolean execute() {
        return rover.fireProjectile(Mortar.class);
    }
}

