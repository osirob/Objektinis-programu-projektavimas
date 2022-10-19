using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Command
{
    public class CommandInvoker
    {
        List<ICommand> commands;

        public CommandInvoker()
        {
            commands = new List<ICommand>();
        }

        public void Run(ICommand command)
        {
            commands.Add(command);
            command.Execute();
        }

        public bool Undo()
        {
            int index = commands.Count() - 1;

            if (index < 0)
                return false;

            ICommand command = commands[index];
            commands.RemoveAt(index);
            command.Undo();
            return true;
        }
    }
}
