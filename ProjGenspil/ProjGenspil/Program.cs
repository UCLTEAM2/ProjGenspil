namespace ProjGenspil
{
    class Program
    {
        //public static List<BoardGameVariant> Games = new List<BoardGameVariant>();
        public static void Main(string[] args)
        {

            //User menu

            while (true)
            {

                Console.WriteLine("\n-------------------- System Menu -------------------");
                Console.WriteLine("|                                                  |");
                Console.WriteLine("|    0. Search for a game                          |");
                Console.WriteLine("|    1. Add a new game to the stock                |");
                Console.WriteLine("|    2. Add a new copy to the stock                |");
                Console.WriteLine("|    3. Edit a games details                       |");
                Console.WriteLine("|    4. Remove a game from the stock               |");
                Console.WriteLine("|    5. Stock lists                                |");
                Console.WriteLine("|    6. Print test method                          |");
                Console.WriteLine("|    ESC. Exit                                     |");
                Console.WriteLine("|                                                  |");
                Console.WriteLine("----------------------------------------------------");

                ConsoleKeyInfo menuChoice = Console.ReadKey(true);

                switch (menuChoice.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        //Search for a game
                        //TODO: Open stock list, make a search function, that loops through the list/array/arrayList, to find a matching game. The list is located in the Stock class.
                        Console.Clear();
                        Console.WriteLine("\nSearch for a game");
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //Add a new game to the stock
                        //TODO: Method that creates a game with parameters from a constructor, and saves the game in a list in the Stock Class. The constructor is located in the BoardGame Class.
                        Console.Clear();
                        AddBoardGame();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //Add a new copy to the stock, with a given condition and price and adds it to the specific game.
                        //TODO: Method, that opens up stock list, find the list e.g Monopoly and adds a copy to it, with a given condition and price.
                        Console.Clear();
                        Console.WriteLine("\nAdd a copy");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //Edit a games details
                        //TODO: Method that ask user to enter name of the game, then shows a list of the game with different conditions, and prompts the user to pick one and then what details to change The Method is located in the BoardGame class.
                        Console.Clear();
                        Console.WriteLine("\nEdit a game");
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //Remove a game from the stock
                        //TODO: Method that ask a user to enter the games name, and then the method shows a list of the game, with different conditions if any. Method is located in the BoardGame class.
                        Console.Clear();
                        Console.WriteLine("\nRemoving a game");
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        bool innerLoop = true;
                        while (innerLoop)
                        {
                            // Show options available in stock
                            Console.WriteLine("\n-------------------- Stock Menu --------------------");
                            Console.WriteLine("|                                                  |");
                            Console.WriteLine("|    1. Show all games available in stock          |");
                            Console.WriteLine("|    2. Show all games that's in a waiting list    |");
                            Console.WriteLine("|    3. Show all games that've been requested      |");
                            Console.WriteLine("|    ESC. To go back to the previous menu          |");
                            Console.WriteLine("|                                                  |");
                            Console.WriteLine("----------------------------------------------------");

                            ConsoleKeyInfo menuChoiceInner1 = Console.ReadKey(true);
                            switch (menuChoiceInner1.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    Console.Clear();
                                    Console.WriteLine("\nShowing all games in stock");

                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Console.Clear();
                                    Console.WriteLine("\nShowing all games in waiting list");
                                    break;

                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    Console.Clear();
                                    Console.WriteLine("\nShowing all requests");
                                    break;

                                case ConsoleKey.Escape:

                                    innerLoop = false; // Exit the inner loop to return to outer switch
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("\nInvalid input, please try again");
                                    break;
                            }
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        //Testing the program to print the current list of games.
                        Console.Clear();
                        PrintTest();
                        break;
                        
                    case ConsoleKey.Escape:
                        Console.WriteLine("\nTest GOODBYE! ");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nInvalid input, please try again");
                        break;
                }

            }

            static void PrintTest()
            {
                Console.WriteLine("\n---- Test method ----");
                foreach (var game in Stock.Games)
                {
                    Console.WriteLine(game.GetGameDetails());
                    //Console.WriteLine();
                }
            }

            static void AddBoardGame()
            {
                Console.WriteLine("\n---- Add a new boardgame to the stock ----");

                Console.Write("\nEnter the name of the game: ");
                string name = Console.ReadLine();

                Console.Write("\nEnter the variant of the game: ");
                string variant = Console.ReadLine();

                Console.Write("\nEnter the genre of the game: ");
                string genre = Console.ReadLine();

                Console.Write("\nEnter the minimum number of required players: ");
                int minPlayers = int.Parse(Console.ReadLine());

                Console.Write("\nEnter the maximum number of required players: ");
                int maxPlayers = int.Parse(Console.ReadLine());

                Console.Write("\nEnter the games language: ");
                string language = Console.ReadLine();


                BoardGameVariant newGame = new BoardGameVariant(name, variant, genre, minPlayers, maxPlayers, language);
                Stock.Games.Add(newGame);

                Console.Clear();

                Console.WriteLine("\n***********************************************");
                Console.WriteLine("**  Boardgame has been added to the system!  **");
                Console.WriteLine("***********************************************");

            }

            //static int ChooseGame()
            //{

            //}


        }

        
    }
}
