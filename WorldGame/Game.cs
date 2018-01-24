using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldGame
{
    class Game
    {
        private readonly World world = new World();
        private Room currentRoom;
        private bool quit;
        private readonly Terminal terminal = new Terminal();

        public void Start()
        {
            CreateCommands();
            currentRoom = world.GetRoom("porch");
            quit = false;
            Console.WriteLine("Welcome");
            Look();
            while (!quit)
            {
                Console.Write("> ");
                var entry = Console.ReadLine().ToLower();

                terminal.ExecuteCommand(entry);
            }
        }

        private void CreateCommands()
        {
            terminal.AddCommand(
                "north",
                "Moves you north",
                () => GoDirection(Direction.North));
            terminal.AddCommand(
                "south",
                "Moves you south",
                () => GoDirection(Direction.South));
            terminal.AddCommand(
                "east",
                "Moves you east",
                () => GoDirection(Direction.East));
            terminal.AddCommand(
                "west",
                "Moves you west",
                () => GoDirection(Direction.West));
            terminal.AddCommand(
                "help",
                "Lists the commands",
                ShowCommands);
            terminal.AddCommand(
                "quit",
                "Exits the game",
                QuitGame);
            terminal.AddCommand(
                "look",
                "Says what room you're in",
                Look);
            terminal.AddCommand(
                "exits",
                "Gives the exits of the room",
                ShowAllExits);
            terminal.AddCommand(
                "up",
                "Moves you up",
                () => GoDirection(Direction.Up));
            terminal.AddCommand(
                "down",
                "Moves you down",
                () => GoDirection(Direction.Down));
            terminal.AddCommand(
                "smile",
                "Smile emote",
                () => Console.WriteLine("You smile at nothing."));
            terminal.AddCommand(
                "wave",
                "Wave emote",
                () => Console.WriteLine("You wave at whatever's in front of you."));
            terminal.AddCommand(
                "jump",
                "Jump emote",
                () => Console.WriteLine("You jump in the air."));
            terminal.AddCommand(
                "dance",
                "Dance emote",
                () => Console.WriteLine("You do a little dance."));
            terminal.AddCommand(
                "punch",
                "Punch emote",
                () => Console.WriteLine("You throw a punch at the air."));
        }

        private void Look()
        {
            Console.WriteLine(currentRoom.Title);
            Console.WriteLine(currentRoom.Description);
        }

        private void GoDirection(Direction direction)
        {
            if (world.HasExit(currentRoom.Key, direction))
            {
                var roomKey = world.GetExit(currentRoom.Key, direction);
                currentRoom = world.GetRoom(roomKey);
                Look();
            }
            else
            {
                Console.WriteLine("There's no exit in that direction.");
            }
        }

        private void ShowAllExits()
        {
            if (AreAnyExits())
            {
                foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                {
                    ShowExit(direction);
                }
            }
            else
            {
                Console.WriteLine("No exits! You're trapped!");
            }
        }

        private void ShowExit(Direction direction)
        {
            if (world.HasExit(currentRoom.Key, direction))
            {
                var roomKey = world.GetExit(currentRoom.Key, direction);
                var room = world.GetRoom(roomKey);

                Console.WriteLine($"{direction} - {room.Title}");
            }
        }

        private bool AreAnyExits()
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                if (world.HasExit(currentRoom.Key, direction))
                {
                    return true;
                }
            }
            return false;
        }

        private void ShowCommands()
        {
            foreach (Command command in terminal.GetAllCommands())
            {
                Console.WriteLine($"{command.Name} - {command.Description}");
            }
        }

        private void Wave()
        {
            Console.WriteLine("You wave to whatever's in front of you.");
        }

        private void QuitGame()
        {
            Console.WriteLine("Come back soon!");
            quit = true;
        }
    }
}
