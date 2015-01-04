package MarsRoverKata.Commands;

import MarsRoverKata.Missile;
import MarsRoverKata.Rover;

public class FireMissileCommand implements ICommand {
    private Rover rover;

    public Rover getRover() {
        return rover;
    }

    public void setRover(Rover rover) {
        this.rover = rover;
    }

    public FireMissileCommand(Rover rover) {
        this.rover = rover;
    }

    public boolean execute() {
        return rover.fireMissile(); //Projectile(Missile.class);
    }
}

