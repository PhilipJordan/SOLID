package MarsRoverKata;

import MarsRoverKata.Commands.BackwardCommand;
import MarsRoverKata.Commands.ForwardCommand;
import MarsRoverKata.Commands.TurnLeftCommand;
import MarsRoverKata.Commands.TurnRightCommand;

import java.util.Random;

public class AlienBehavior {
    private final Random random;

    public AlienBehavior() {
        this.random = new Random();
    }

    public void moveAlien(Alien alien) {
        switch (random.nextInt(4)) {
            case 0:
                new ForwardCommand(alien).execute();
                break;
            case 1:
                new BackwardCommand(alien).execute();
                break;
            case 2:
                new TurnLeftCommand(alien).execute();
                moveAlien(alien);
                break;
            case 3:
                new TurnRightCommand(alien).execute();
                moveAlien(alien);
                break;
        }
    }
}

