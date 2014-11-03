using System;
using System.Collections.Generic;
using MarsRoverKata.Commands;

namespace MarsRoverKata
{
    public class Commander
    {
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
                if (!command.Execute())
                    return false;
            }
            return true;
        }
    }
}
