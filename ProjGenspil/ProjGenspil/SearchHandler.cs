using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
     public class SearchHandler
    {
        static string systemMenu = Program.systemMenu;
        static string gameManager = Program.gameManager;
        static string searchMenu = Program.searchMenu;
        static string stockManager = Program.stockManager;

        public static void SearchForAGameByName(Stock stock)
        {
            Console.Clear();

            Console.WriteLine(searchMenu);

            if (stock.Games.Count == 0)
            {
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                Console.Write("There is no games in the stock!".PadRight(Console.WindowWidth));
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)

            }
            else
            {
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                Console.Write("Enter the games name: ".PadRight(Console.WindowWidth));
                Console.SetCursorPosition("Enter the games name: ".Length, 11);

                string search = Console.ReadLine();
                bool foundGame = false;

                foreach (var game in stock.Games)
                {
                    if (game.GameName.ToLower() == search.ToLower())
                    {
                        Console.WriteLine(game.GetGameDetails());
                        foundGame = true;
                    }

                }
                if (!foundGame)
                {
                    Console.Clear();
                    Console.WriteLine(searchMenu);
                    Console.SetCursorPosition(0, 11);
                    Console.Write($"No games with the name \"{search}\" was found!");
                }


            }
        }

        public static int SearchForAGameByNameWithIndex(Stock stock)
        {

            Console.Clear();

            Console.WriteLine(searchMenu);

            Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
            Console.Write("Enter the games name: ".PadRight(Console.WindowWidth));
            Console.SetCursorPosition("Enter the games name: ".Length, 11);



            string search = Console.ReadLine();
            bool foundGame = false;


            for (int i = 0; i < stock.Games.Count; i++)
            {
                if (stock.Games[i].GameName.ToLower() == search.ToLower())
                {
                    Console.Write($"\nGame index number: {i + 1} {stock.Games[i].GetGameDetails()}\n");
                    foundGame = true;
                }
            }
            if (!foundGame)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16);
                Console.Write($"No games with the name \"{search}\" was found!");
                return -1;
            }

            Console.Write("\nEnter the games index number: ");


            int gameIndex = Convert.ToInt32(Console.ReadLine()) - 1;


            if (gameIndex < 0 || gameIndex > stock.Games.Count - 1)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                return -1;
            }
            return gameIndex;

        }
        public static void SearchForAGameGenre(Stock stock)
        {
            Console.Clear();

            Console.WriteLine(searchMenu);

            if (stock.Games.Count == 0)
            {
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                Console.Write("There is no games in the stock!".PadRight(Console.WindowWidth));
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)

            }
            else
            {
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                Console.Write("Enter the games genre: ".PadRight(Console.WindowWidth));
                Console.SetCursorPosition("Enter the games genre: ".Length, 11);

                string search = Console.ReadLine();
                bool foundGame = false;

                foreach (var game in stock.Games)
                {
                    if (game.GameGenre.ToLower() == search.ToLower())
                    {
                        Console.WriteLine(game.GetGameDetails());
                        foundGame = true;
                    }

                }
                if (!foundGame)
                {
                    Console.Clear();
                    Console.WriteLine(searchMenu);
                    Console.SetCursorPosition(0, 11);
                    Console.Write($"No games with the genre \"{search}\" was found!");
                }


            }
        }

        public static int SearchForAGenreWithIndex(Stock stock)
        {

            Console.Clear();

            Console.WriteLine(searchMenu);

            Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
            Console.Write("Enter the games genre: ".PadRight(Console.WindowWidth));
            Console.SetCursorPosition("Enter the games genre: ".Length, 11);



            string search = Console.ReadLine();
            bool foundGame = false;


            for (int i = 0; i < stock.Games.Count; i++)
            {
                if (stock.Games[i].GameGenre.ToLower() == search.ToLower())
                {
                    Console.Write($"\nGame index number: {i + 1} {stock.Games[i].GetGameDetails()}\n");
                    foundGame = true;
                }
            }
            if (!foundGame)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16);
                Console.Write($"No games within the \"{search}\" genre was found!");
                return -1;
            }

            Console.Write("\nEnter the games index number: ");


            int gameIndex = Convert.ToInt32(Console.ReadLine()) - 1;


            if (gameIndex < 0 || gameIndex > stock.Games.Count - 1)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                return -1;
            }
            return gameIndex;

        }

        public static void SearchByNumberOfPlayers(Stock stock)
        {
            Console.Clear();

            Console.WriteLine($"{searchMenu}");

            if (stock.Games.Count == 0)
            {
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                Console.Write("There is no games in the stock!".PadRight(Console.WindowWidth));
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)

            }
            else
            {
                Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                Console.Write("Enter how many players you are: ".PadRight(Console.WindowWidth));
                Console.SetCursorPosition("Enter how many players you are: ".Length, 11);

                int search = Convert.ToInt32(Console.ReadLine());
                bool foundGame = false;

                foreach (var game in stock.Games)
                {
                    if (game.GameMinNumOfPlayers <= search && game.GameMaxNumOfPlayers >= search)
                    {
                        Console.WriteLine(game.GetGameDetails());
                        foundGame = true;
                    }

                }
                if (!foundGame)
                {
                    Console.Clear();
                    Console.WriteLine(searchMenu);
                    Console.SetCursorPosition(0, 11);
                    Console.Write($"No games with \"{search}\" players was found!");
                }


            }
        }

        public static int SearchByNumberOfPlayersWithIndex(Stock stock)
        {

            Console.Clear();

            Console.WriteLine(searchMenu);


            Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
            Console.Write("Enter the number of players: ".PadRight(Console.WindowWidth));
            Console.SetCursorPosition("Enter the number of players: ".Length, 11);



            int search = Convert.ToInt32(Console.ReadLine());
            bool foundGame = false;


            for (int i = 0; i < stock.Games.Count; i++)
            {
                if (stock.Games[i].GameMinNumOfPlayers <= search && stock.Games[i].GameMaxNumOfPlayers >= search)
                {
                    Console.Write($"\nGame index number: {i + 1} {stock.Games[i].GetGameDetails()}\n");
                    foundGame = true;
                }
            }
            if (!foundGame)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16);
                Console.Write($"No games with \"{search}\" players was found!");
                return -1;
            }

            Console.Write("\nEnter the games index number: ");


            int gameIndex = Convert.ToInt32(Console.ReadLine()) - 1;


            if (gameIndex < 0 || gameIndex > stock.Games.Count - 1)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                return -1;
            }
            return gameIndex;
        }


    }
}
