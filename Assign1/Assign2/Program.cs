using System;
using System.Collections.Generic;
using System.Linq;

namespace Assign2
{
    class Program
    {
        static Player[] players = new Player[1000000];

        //Type the number of the exercise when running script
        //Example: dotnet run 1     <--- This will run exercise 1
        static void Main(string[] args)
        {
            Console.WriteLine("Starting exercise " + args[0]);
            switch (args[0])
            {
                case "1":
                    InstantiatePlayers(1000000);
                    break;
                case "2":
                    CreatePlayerWithItems(3);
                    break;
            }
        }

        static void CreatePlayerWithItems(int amount)
        {
            Player playerWithItems = new Player(Guid.NewGuid(), 0, new List<Item>());
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                playerWithItems.Items.Add(new Item(Guid.NewGuid(), rnd.Next(1, 101)));
                Console.WriteLine(playerWithItems.Items[i].Id + " level is " + playerWithItems.Items[i].Level);
            }
            Console.WriteLine("Highest level item of player " + playerWithItems.Id + " is item " + playerWithItems.GetHighestLevelItem().Id);
        }

        static void InstantiatePlayers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                players[i] = new Player(Guid.NewGuid(), 0, null);
            }
            Console.WriteLine("Created " + amount + " players");
            CheckForDuplicates(players);
        }

        static bool CheckForDuplicates(Player[] array)
        {
            if (array.Length != array.Distinct().Count())
            {
                Console.WriteLine("Array contains duplicate IDs!");
                return true;
            }
            Console.WriteLine("Array contains no duplicate IDs!");
            return false;
        }
    }
}
