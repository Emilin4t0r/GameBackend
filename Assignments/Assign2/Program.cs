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
                    Player plr = CreatePlayerWithItems(3);
                    PrintLevelsOfAllItems(plr);
                    Console.WriteLine("Highest level item of player " + plr.Id + " is item " + plr.GetHighestLevelItem().Id);
                    break;
                case "3":
                    Console.WriteLine("\nWithout LINQ:");
                    Item[] itemArray = GetItems(CreatePlayerWithItems(3));
                    for (int i = 0; i < itemArray.Length; i++)
                    {
                        Console.WriteLine("item number " + i + " ID in array: " + itemArray[i].Id);
                    }
                    Console.WriteLine("\nWith LINQ: ");
                    itemArray = GetItemsWithLinq(CreatePlayerWithItems(3));
                    for (int i = 0; i < itemArray.Length; i++)
                    {
                        Console.WriteLine("item number " + i + " ID in array: " + itemArray[i].Id);
                    }
                    break;
                case "4":
                    Console.WriteLine("\nWithout LINQ:");
                    Console.WriteLine("First item in the list: " + FirstItem(CreatePlayerWithItems(3)).Id);
                    Console.WriteLine("\nWith LINQ: ");
                    Console.WriteLine("First item in the list: " + FirstItemWithLinq(CreatePlayerWithItems(3)).Id);
                    break;
            }
        }

        static Item[] GetItems(Player player)
        {
            Item[] items = new Item[player.Items.Count];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = player.Items[i];
            }
            return items;
        }

        static Item[] GetItemsWithLinq(Player player)
        {
            Item[] items = player.Items.ToArray();
            return items;
        }

        static Item FirstItem(Player player)
        {
            Item[] items = player.Items.ToArray();
            if (items[0] != null)
            {
                return items[0];
            }
            return null;
        }

        static Item FirstItemWithLinq(Player player)
        {
            return player.Items.FirstOrDefault();
        }

        static Player CreatePlayerWithItems(int amount)
        {
            Player playerWithItems = new Player(Guid.NewGuid(), 0, new List<Item>());
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                playerWithItems.Items.Add(new Item(Guid.NewGuid(), rnd.Next(1, 101)));
            }
            return playerWithItems;
        }

        static void PrintLevelsOfAllItems(Player player)
        {
            for (int i = 0; i < player.Items.Count; i++)
            {
                Console.WriteLine(player.Items[i].Id + " level is " + player.Items[i].Level);
            }
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
