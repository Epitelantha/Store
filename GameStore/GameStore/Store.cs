using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    class Store
    {
        List<Game> showcase = new List<Game>();
        
        int maxGames = 4;

        public Store()
        {
            showcase.Add(new Game("Daddy Simulator", 19.99f, "Simulation, Real Life, Sexual Content", "How to dad"));
            showcase.Add(new Game("Half Life 3", 60f, "Unreal", "All your dreams come true"));
            showcase.Add(new Game("Deep Space Waifu", 9.99f, "Nudity, Sexual Content", "Become a sexual bear"));
            showcase.Add(new Game("Space Killaz!", 99.99f, "Game of the Year", "The greatest game of all time, 10/10 IGN"));
        }

        public bool IsValidGame(int n)
        {
            if (n < showcase.Count && n >= 0)
                return true;
            else
                return false;
        }

        public void PrintShowcase()
        {
            foreach (Game g in showcase)
            {
                Console.WriteLine("\t" + "[" + showcase.IndexOf(g) + "] " + g.name + ", " + g.price + " Euro");
            }
        }

        public void PrintShowcaseDetailed()
        {
            foreach (Game g in showcase)
            {
                Console.WriteLine("\t" + "[" + showcase.IndexOf(g) + "] " + g.name + ", " + g.price + " Euro, " + g.genre + ", " + g.description);
            }
        }

        public void AddGame(Game game)
        {
            /*if(showcase.Count < maxGames)
                showcase.Add(game);*/
            showcase.Add(game);
        }

        public void NewGame(Game game)
        {
            showcase.Add(game);
        }

        public void Sell(int game, User user)
        {
            Sell(showcase[game], user);
        }

        public void Sell(Game game, User user)
        {
            if(user.wallet >= game.price)
            {
                user.wallet = user.wallet - game.price;
                user.library.Add(game);
                RemoveGame(game);
            }
            else
                Console.WriteLine("Get rich, scrub!");
        }

        public void RemoveGame(Game game)
        {
            if(showcase.Contains(game))
                showcase.Remove(game);
        }
    }

    class User
    {
        public float wallet;
        public List<Game> library = new List<Game>();

        public User(float walletFunds)
        {
            wallet = walletFunds;
        }
    }

    class Game
    {
        public string genre;
        public string name;
        public string description;
        public float price;

        public Game(string name, float price, string genre, string description)
        {
            this.name = name;
            this.price = price;
            this.genre = genre;
            this.description = description;
        }
    }

    class DLC
    {
        public string connectedGame;
        public string name;
        public string description;
        public float price;
        public bool hasGame;

        public DLC(string name, float price, string connectedGame, string description, bool hasGame)
        {
            this.name = name;
            this.price = price;
            this.connectedGame = connectedGame;
            this.description = description;

            this.hasGame = hasGame;
        }
    }
}
