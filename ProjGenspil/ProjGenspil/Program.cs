namespace ProjGenspil
{
    class Program
    {
        public static string systemMenu = @"
-------------------- System Menu -------------------
|                                                  |
|    1. Game management                            |
|    2. Search menu                                |
|    3. Stock management                           |
|                                                  |
|    ESC. Exit                                     |
|                                                  |
----------------------------------------------------";

        public static string gameManager = @"
-------------------- Game Manager ------------------
|                                                  |
|    1. Add a new game to the stock                |
|    2. Add a new copy to the stock                |
|    3. Edit a games details                       |
|    4. Remove a copy from the stock               |
|    5. Add a game to waiting list                 |
|    6. Make a request on a game                   |
|    7. Prints all copies of a game                |
|    8. Remove all instances of a game             |
|                                                  |
|    ESC. To go back to the previous menu          |
|                                                  |
----------------------------------------------------";

        public static string searchMenu = @"
-------------------- Search Menu -------------------
|                                                  |
|    1. Search by game name                        |
|    2. Search by game genre                       |
|    3. Search by number of players                |
|                                                  |
|    ESC. To go back to the previous menu          |
|                                                  |
----------------------------------------------------";

        public static string stockManager = @"
-------------------- Stock Manager -----------------
|                                                  |
|    1. Show all games available in stock          |
|    2. Show all games that's in a waiting list    |
|    3. Show all games that've been requested      |
|                                                  |
|    ESC. To go back to the previous menu          |
|                                                  |
----------------------------------------------------";

        public static string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string folder = Path.Combine(projectPath, "Data");
        public static string gamesFile = Path.Combine(folder, "games.txt");
        static string waitingListFile = Path.Combine(folder, "waitinglist.txt");
        public static string requestFile = Path.Combine(folder, "requestlist.txt");

        //static DataHandler handler;

        public static void Main(string[] args)
        {

            Directory.CreateDirectory(folder);
            // Create a single Stock instance
            var stock = new Stock();

            // Load existing data from the file (if it exists)
            stock.LoadFromFile(gamesFile);
            stock.LoadFromFileRequest(requestFile);

            //User menu
            Console.WriteLine(systemMenu);

            Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)

            while (true)
            {

                ConsoleKeyInfo menuChoice = Console.ReadKey(true);

                switch (menuChoice.Key)
                {

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        // Game manager
                        Console.Clear();
                        Console.WriteLine(gameManager);
                        Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                        bool innerGameLoop = true;
                        while (innerGameLoop)
                        {
                            ConsoleKeyInfo gameMenuChoice = Console.ReadKey(true);
                            switch (gameMenuChoice.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    //Add a new game to the stock
                                    Console.Clear();
                                    GameHandler.AddBoardGame(stock);

                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    //Add a new copy to the stock, with a given condition and price and adds it to the specific game.
                                    Console.Clear();

                                    int gameIndexForCopy = GameHandler.addCopyWithSearchIndex(stock);

                                    if (gameIndexForCopy != -1)
                                    {
                                        GameHandler.AddAGameCopy(stock, gameIndexForCopy);
                                    }

                                    break;
                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    //Edit a games details - Based on Index
                                    //TODO: Method that ask user to enter name of the game, then shows a list of the game with different conditions, and prompts the user to pick one and then what details to change The Method is located in the BoardGame class.
                                    Console.Clear();

                                    int editIndex = SearchHandler.SearchForAGameByNameWithIndex(stock);

                                    if (editIndex != -1)
                                    {
                                        GameHandler.EditGameVariant(stock, editIndex);
                                    }
                                    break;

                                case ConsoleKey.D4:
                                case ConsoleKey.NumPad4:
                                    //Remove a copy from the stock - Based on Index
                                    Console.Clear();
                                    GameHandler.DeleteAGameCopy(stock);

                                    break;

                                case ConsoleKey.D5:
                                case ConsoleKey.NumPad5:
                                    //Add a game to waiting list 
                                    //TODO: A method that adds a game to a waiting list, takes a game with all its properties from a list, based on Index.

                                    break;

                                case ConsoleKey.D6:
                                case ConsoleKey.NumPad6:
                                    //Make a request on a game 
                                    //TODO: A method that makes a request on a game, that does not exist in the stock, and adds it to a list of requested games.
                                    GameHandler.AddGameRequest(stock);


                                    break;

                                case ConsoleKey.D7:
                                case ConsoleKey.NumPad7:
                                    //Print all copies on a game
                                    //TODO: A method that prints all copies on a game, with the condition, price and quantity
                                    Console.Clear();
                                    int gameIndex = GameHandler.PrintCopyWithSearchIndex(stock);

                                    if (gameIndex != -1)
                                    {
                                        GameHandler.PrintAllCopies(stock, gameIndex);

                                    }
                                    break;
                                case ConsoleKey.D8:
                                case ConsoleKey.NumPad8:
                                    //Remove all instances of a game
                                    int deleteGameIndex = GameHandler.PrintCopyWithSearchIndex(stock);

                                    if (deleteGameIndex != -1)
                                    {
                                        GameHandler.DeleteGameInstance(stock, deleteGameIndex);

                                    }
                                    break;

                                case ConsoleKey.Escape:
                                    Console.Clear();
                                    innerGameLoop = false; // Exit the inner loop to return to outer switch
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine(gameManager);
                                    Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                                    Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                                    Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                                    break;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine(systemMenu);
                        Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //Search menu
                        //TODO: Open stock list, make a search function, that loops through the list/array/arrayList, to find a matching game. The list is located in the Stock class.
                        Console.Clear();
                        Console.WriteLine(searchMenu);
                        Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                        bool innerSearchLoop = true;
                        while (innerSearchLoop)
                        {
                            ConsoleKeyInfo searchMenuChoice = Console.ReadKey(true);
                            switch (searchMenuChoice.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    //Search by game name
                                    //SearchForAGame();
                                    SearchHandler.SearchForAGameByName(stock);
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    //Search by game genre
                                    SearchHandler.SearchForAGameGenre(stock);
                                    break;
                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    //Search by number of players
                                    SearchHandler.SearchByNumberOfPlayers(stock);
                                    break;
                                case ConsoleKey.Escape:
                                    Console.Clear();
                                    innerSearchLoop = false; // Exit the inner loop to return to outer switch
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine(searchMenu);
                                    Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                                    Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                                    Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                                    break;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine($"{systemMenu}");
                        Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                        break;



                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //Stock Menu
                        Console.Clear(); // Clear once at the start
                        Console.WriteLine(stockManager);
                        Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                        bool innerStockLoop = true;
                        while (innerStockLoop)
                        {

                            ConsoleKeyInfo stockMenuChoice = Console.ReadKey(true);
                            switch (stockMenuChoice.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    GameHandler.PrintTest(stock);
                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:

                                    break;

                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    //Prints all requested games
                                    GameHandler.PrintRequest(stock);

                                    break;

                                case ConsoleKey.Escape:
                                    Console.Clear();
                                    innerStockLoop = false; // Exit the inner loop to return to outer switch
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine(stockManager);
                                    Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                                    Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                                    Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                                    break;
                            }

                        }
                        Console.Clear();
                        Console.WriteLine(systemMenu);
                        Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine(systemMenu);
                        Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                        Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                        Console.SetCursorPosition(0, 11); // Move cursor below the menu (line 11)
                        break;
                }

            }
        }

    }
}
