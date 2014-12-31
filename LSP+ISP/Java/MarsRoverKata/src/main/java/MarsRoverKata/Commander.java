package MarsRoverKata;

import MarsRoverKata.Commands.ICommand;

import java.beans.EventHandler;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;

public class Commander {
    // TODO: Implementation, functionality check
    private EventHandler commandExecuted;

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

    public void setEventHandler(EventHandler event) {
        this.commandExecuted = event;
    }

    public EventHandler getCommandExecuted() {
        return commandExecuted;
    }

    public boolean executeCommands() {
        for (ICommand command : commands) {
            boolean success = command.execute();
            onCommandExecuted();
            if (!success)
                return false;
        }
        return true;
    }

    private void onCommandExecuted() {
        if (commandExecuted != null) {
            try {
                Method method = commandExecuted.getTarget().getClass().getMethod(commandExecuted.getAction(), Object[].class);
                Object[] arguments = new Object[0];
                commandExecuted.invoke(commandExecuted.getTarget(), method, arguments);
            } catch (NoSuchMethodException nsme) {
                System.err.println("Error invoking commandExecuted: " + nsme);
            }
        }
    }

}