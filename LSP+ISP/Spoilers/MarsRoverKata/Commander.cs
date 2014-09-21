using System;
using System.Collections.Generic;
using MarsRoverKata.Commands;

namespace MarsRoverKata
{
    public class Commander
    {
        public event EventHandler CommandExecuted;

        public List<ICommand> Commands { get; set; }

        public Commander()
        {
            Commands = new List<ICommand>();
        }

        public void Accept(List<ICommand> commands)
        {
            Commands.AddRange(commands);
        }

        public void Accept(ICommand command)
        {
            Commands.Add(command);
        }

        public bool ExecuteCommands()
        {
            foreach (var command in Commands)
            {
                var success = command.Execute();
                OnCommandExecuted();
                if (!success)
                    return false;
            }
            return true;
        }

        private void OnCommandExecuted()
        {
            if (CommandExecuted != null)
            {
                CommandExecuted(this, EventArgs.Empty);
            }
        }
    }
}
