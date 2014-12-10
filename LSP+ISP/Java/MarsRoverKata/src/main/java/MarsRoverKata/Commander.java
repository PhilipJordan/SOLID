package MarsRoverKata;

import MarsRoverKata.Commands.ICommand;

import java.util.ArrayList;
import java.util.List;

public class Commander {
    private List<ICommand> commands;

    // TODO: Implementation, functionality check
    //public Event CommandExecuted = new Event<Void>();

    public List<ICommand> getCommands() {
        return commands;
    }

    public void setCommands(List<ICommand> commands) {
        this.commands = commands;
    }

    public Commander() {
        commands = new ArrayList<ICommand>();
    }

    public void accept(List<ICommand> commands) {
        commands.addAll(commands);
    }

    public void accept(ICommand command) {
        commands.add(command);
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
        // TODO: EventHandler implementation
//        if (CommandExecuted != null) {
//            CommandExecuted(this, EventArgs.Empty);
//        }
    }
}
