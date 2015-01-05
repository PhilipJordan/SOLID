package MarsRoverKata;

import MarsRoverKata.Commands.ICommand;

import java.beans.EventHandler;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;

public class Commander {
    private List<ICommand> commands;

    public Commander() {
        commands = new ArrayList<ICommand>();
    }

    public void accept(List<ICommand> commands) {
        this.commands.addAll(commands);
    }

    public void accept(ICommand command) {
        commands.add(command);
    }

    public List<ICommand> getCommands() {
        return commands;
    }

    public void setCommands(List<ICommand> commands) {
        this.commands = commands;
    }

    public boolean executeCommands() {
        for (ICommand command : commands) {
            boolean success = command.execute();
            if (!success)
                return false;
        }
        return true;
    }

}