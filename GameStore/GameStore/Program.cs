using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Store store = new Store();
            User user = new User(90);

            while (true)
            {
                store.PrintShowcase();
                Console.WriteLine("Input command: buy/details/add/quit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "buy":
                        Console.WriteLine("Insert game number");
                        string buyInput = Console.ReadLine();
                        int gameN = int.Parse(buyInput);
                        if (store.IsValidGame(gameN))
                        {
                            store.Sell(gameN, user);
                        }
                        else
                        {
                            Console.WriteLine("Invalid game");
                        }
                        break;
                    case "add":
                        Console.WriteLine("What's the games name?");
                        string name = Console.ReadLine();
                        Console.WriteLine("What's the games price?");
                        string newprice = Console.ReadLine();
                        float price = float.Parse(newprice);
                        Console.WriteLine("What's the games genre?");
                        string genre = Console.ReadLine();
                        Console.WriteLine("What's the games description?");
                        string description = Console.ReadLine();
                        store.AddGame(new Game(name, price, genre, description));
                        break;
                    case "details":
                        store.PrintShowcaseDetailed();
                        Console.WriteLine("Go back?");
                        Console.ReadLine();
                        break;
                    case "quit":
                        Console.WriteLine("Goodbye :)");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Invalid Comment");
                        break;
                }
            }
        }
    }
}