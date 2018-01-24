using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldGame
{
    class World
    {
        private readonly Dictionary<string, Room> rooms = new Dictionary<string, Room>();
        private readonly Dictionary<Tuple<string, Direction>, string> exits = new Dictionary<Tuple<string, Direction>, string>();

        public World()
        {
            CreateRooms();
            CreateExits();
        }

        public Room GetRoom(string key)
        {
             return rooms[key];
        }

        public string GetExit(string roomKey, Direction direction)
        {
            return exits[Tuple.Create(roomKey, direction)];
        }

        public bool HasExit(string roomKey, Direction direction)
        {
            return exits.ContainsKey(Tuple.Create(roomKey, direction));
        }

        private void CreateRooms()
        {
            AddRoom(new Room(
                "porch",
                "The Front Porch",
                "You're on a porch with a porch swing and Christmas lights on the roof."));

            AddRoom(new Room(
                "living room",
                "The Living Room",
                "You're in a living room with a couch and a TV."));

            AddRoom(new Room(
                "hallway",
                "The Hallway",
                "You're in a hallway."));

            AddRoom(new Room(
                "kitchen",
                "The Kitchen",
                "You're in a kitchen with a small dining table."));

            AddRoom(new Room(
                "hallway 2",
                "The Second Hallway",
                "You're in a hallway."));
            AddRoom(new Room(
                "bedroom",
                "The Bedroom",
                "You're in a bedroom with a desk and a closet."));
            AddRoom(new Room(
                "bathroom",
                "The Bathroom",
                "You're in a bathroom with no doorknob."));
            AddRoom(new Room(
                "backyard",
                "The Backyard",
                "You're in a backyard with a trampoline."));
        }

        private void AddRoom(Room room)
        {
            rooms.Add(room.Key, room);
        }

        private void CreateExits()
        {
            AddExit("porch", Direction.North, "living room");
            AddExit("living room", Direction.South, "porch");

            AddExit("living room", Direction.East, "kitchen");
            AddExit("kitchen", Direction.West, "living room");

            AddExit("kitchen", Direction.North, "hallway");
            AddExit("hallway", Direction.South, "kitchen");

            AddExit("hallway", Direction.East, "living room");
            AddExit("living room", Direction.West, "hallway");

            AddExit("living room", Direction.Up, "hallway 2");
            AddExit("hallway 2", Direction.Down, "living room");

            AddExit("hallway 2", Direction.North, "bedroom");
            AddExit("bedroom", Direction.South, "hallway 2");

            AddExit("bedroom", Direction.West, "bathroom");

            AddExit("kitchen", Direction.South, "backyard");
            AddExit("backyard", Direction.North, "kitchen");
        }

        private void AddExit(string fromKey, Direction direction, string toKey)
        {
            exits.Add(Tuple.Create(fromKey, direction), toKey);
        }
    }
}
