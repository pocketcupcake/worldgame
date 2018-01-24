using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldGame
{
    class Terminal
    {
        private readonly Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public ICollection<Command> GetAllCommands()
        {
            return commands.Values;
        }

        public void AddCommand(string name, string description, Command.ActionDelegate action)
        {
            commands.Add(name, new Command(name, description, action));
        }

        public void ExecuteCommand(string entry)
        {
            try
            {
                var command = FindCommand(entry);
                command.Action();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("I don't know that command.");
            }
        }

        private Command FindCommand(string entry)
        {
            foreach (Command command in GetAllCommands()) 
            {
                if (command.Name == entry)
                {
                    return command;
                }
            }
            throw new ArgumentException("Command not found.");
        }
    }
}
