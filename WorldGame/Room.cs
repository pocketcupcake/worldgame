using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldGame
{
    class Room
    {
        public readonly string Key;
        public readonly string Title;
        public readonly string Description;

        public Room(string key, string title, string description)
        {
            Key = key;
            Title = title;
            Description = description;
        }
    }
}
