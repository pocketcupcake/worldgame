using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldGame
{
    class Command
    {
        public delegate void ActionDelegate();

        public readonly string Name;
        public readonly string Description;
        public readonly ActionDelegate Action;

        public Command(string name, string description, ActionDelegate action)
        {
            Name = name;
            Description = description;
            Action = action;
        }
    }
}
