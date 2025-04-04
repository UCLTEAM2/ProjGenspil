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

        static string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        static string folder = Path.Combine(projectPath, "Data");
        static string gamesFile = Path.Combine(folder, "games.txt");
        static string waitingListFile = Path.Combine(folder, "waitinglist.txt");
        static string requestListFile = Path.Combine(folder, "requestlist.txt");

        //static DataHandler handler;

        public static void Main(string[] args)
        {

            Directory.CreateDirectory(folder);
            // Create a single Stock instance
            var stock = new Stock();

            // Load existing data from the file (if it exists)
            stock.LoadFromFile(gamesFile);

            // Verify the contents of the Stock
            //foreach (var loadedVariant in stock.Games)
            //{
            //    Console.WriteLine($"Variant: {loadedVariant.GameName} {loadedVariant.GameVariant}");
            //    foreach (var copy in loadedVariant.BoardGameCopies)
            //    {
            //        Console.WriteLine($"  Copy: {copy.GameCondition}, {copy.GamePrice}");
            //    }
            //}

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
                                    AddBoardGame(stock);

                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    //Add a new copy to the stock, with a given condition and price and adds it to the specific game.
                                    Console.Clear();

                                    int gameIndexForCopy = addCopyWithSearchIndex(stock);

                                    if (gameIndexForCopy != -1)
                                    {
                                        AddAGameCopy(stock, gameIndexForCopy);
                                    }

                                        break;
                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    //Edit a games details - Based on Index
                                    //TODO: Method that ask user to enter name of the game, then shows a list of the game with different conditions, and prompts the user to pick one and then what details to change The Method is located in the BoardGame class.

                                    break;

                                case ConsoleKey.D4:
                                case ConsoleKey.NumPad4:
                                    //Remove a copy from the stock - Based on Index
                                     Console.Clear();
                                        DeleteAGameCopy(stock);

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

                                    break;

                                case ConsoleKey.D7:
                                case ConsoleKey.NumPad7:
                                    //Print all copies on a game
                                    //TODO: A method that prints all copies on a game, with the condition, price and quantity
                                    Console.Clear();
                                    int gameIndex = PrintCopyWithSearchIndex(stock);

                                    if (gameIndex != -1)
                                    {
                                        PrintAllCopies(stock, gameIndex);

                                    }
                                        break;
                                case ConsoleKey.D8:
                                case ConsoleKey.NumPad8:
                                    //Remove all instances of a game
                                    int deleteGameIndex = PrintCopyWithSearchIndex(stock);

                                    if (deleteGameIndex != -1)
                                    {
                                        DeleteGameInstance(stock, deleteGameIndex);

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
                                    SearchForAGameByName(stock);
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    //Search by game genre
                                    SearchForAGameGenre(stock);
                                    break;
                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    //Search by number of players
                                    SearchByNumberOfPlayers(stock);
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
                                    PrintTest(stock);
                                    break;

                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:

                                    break;

                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:

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

       

        static void PrintAllCopies(Stock stock, int gameIndex)
        {
            Console.Clear();
            Console.WriteLine($"\n ---- Copies of {stock.Games[gameIndex].GameName} ----".PadRight(Console.WindowWidth));
            var copies = stock.Games[gameIndex].GetAllCopies();

            foreach (var copy in copies)
            {
                Console.WriteLine(stock.Games[gameIndex].GetGameDetails());
                Console.WriteLine(copy.GetCopyDetails().PadRight(Console.WindowWidth));
            }
        }

        static void PrintTest(Stock stock)
        {

            Console.WriteLine("\n---- Test method ----".PadRight(Console.WindowWidth));
            foreach (var game in stock.Games)
            {

                Console.WriteLine(game.GetGameDetails());

            }

        }

        //static int ChooseGame()
        //{
        //    Console.WriteLine("\n---- Add a new copy to the stock ----");

        //    if (stock.Games.Count == 0)
        //    {
        //        Console.WriteLine("There is no games in the system, please add some games first!");
        //        return -1;
        //    }

        //    Console.Write("\nChoose a game: ");

        //    for (int i = 0; i < stock.Games.Count; i++)
        //    {
        //        Console.WriteLine($"{i + 1} {stock.Games[i].GetGameDetails()}");
        //    }

        //    Console.Write("Enter the games number: ");

        //    int gameIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        //    if (gameIndex < 0 || gameIndex >= stock.Games.Count)
        //    {

        //        Console.WriteLine("Invalid game selection!");

        //        return -1;
        //    }

        //    return gameIndex;
        //}


        static int addCopyWithSearchIndex(Stock stock)
        {
            Console.Clear();
            Console.WriteLine(searchMenu);
            Console.SetCursorPosition(0, 11);



            if (stock.Games.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                 Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 11)
                Console.Write("There is no games in the stock!".PadRight(Console.WindowWidth));
                 Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 11)
                

                return -1;

            }

            
            int gameIndex = -1;
            
            while (gameIndex <= -1)
            {
                

                ConsoleKeyInfo AddCopySearchMenu = Console.ReadKey(true);
                switch (AddCopySearchMenu.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        gameIndex = SearchForAGameByNameWithIndex(stock);

                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        gameIndex = SearchForAGenreWithIndex(stock);

                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        gameIndex = SearchByNumberOfPlayersWithIndex(stock);

                        break;


                }

                return gameIndex;
            }
            return gameIndex;
         
        }

        static int PrintCopyWithSearchIndex(Stock stock)
        {
            Console.Clear();
            Console.WriteLine(searchMenu);
            Console.SetCursorPosition(0, 11);



            if (stock.Games.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 11)
                Console.Write("There is no games in the stock!".PadRight(Console.WindowWidth));
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 11)


                return -1;

            }


            int gameIndex = -1;

            while (gameIndex <= -1)
            {


                ConsoleKeyInfo AddCopySearchMenu = Console.ReadKey(true);
                switch (AddCopySearchMenu.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        gameIndex = SearchForAGameByNameWithIndex(stock);

                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        gameIndex = SearchForAGenreWithIndex(stock);

                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        gameIndex = SearchByNumberOfPlayersWithIndex(stock);

                        break;


                }

                return gameIndex;
            }
            return gameIndex;

        }
        static void SearchForAGameByName(Stock stock)
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

        static int SearchForAGameByNameWithIndex(Stock stock)
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
        static void SearchForAGameGenre(Stock stock)
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

        static int SearchForAGenreWithIndex(Stock stock)
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

        static void SearchByNumberOfPlayers(Stock stock)
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

        static int SearchByNumberOfPlayersWithIndex(Stock stock)
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

        static void AddBoardGame(Stock stock)
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
            stock.Games.Add(newGame);
            stock.SaveToFile(gamesFile);

            Console.Clear();

            Console.WriteLine($"{gameManager}");

             Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
            Console.WriteLine("The boardgame has been added to the system!".PadRight(Console.WindowWidth));
             Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)



        }

        static void AddAGameCopy(Stock stock, int gameIndex)
        {
            Console.WriteLine($"\nWhat's the condition of the copy?" +
                $"\n1. \"A\" for new" +
                $"\n2. \"B\" for slightly used" +
                $"\n3. \"C\" for used" +
                $"\n4. \"D\" for a bit worn" +
                $"\n5. \"E\" for very worn" +
                $"\n6. \"F\" for spareparts");

            //int conditionEnum = Convert.ToInt32(Console.ReadLine()) - 1;
            Condition conditionEnum = Enum.Parse<Condition>(Console.ReadLine(), true) - 1;

            //Console.WriteLine($"\n\"A\" for new\n\"B\" for slightly used\n\"C\" for used\n\"D\" for a bit worn\n\"E\" for very worn\n\"F\" for trash");
            
            //char condition = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write($"\nEnter a price for the game: ");
            double price = Convert.ToDouble(Console.ReadLine());

            var chosen = stock.Games[gameIndex];

            BoardGameCopy copy = new BoardGameCopy(conditionEnum, price, chosen);

            stock.Games[gameIndex].AddCopy(copy);
            stock.SaveToFile(gamesFile);

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();

            Console.WriteLine(gameManager);
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
            Console.WriteLine("The copy has been added to the game".PadRight(Console.WindowWidth));
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)

        }

        static void DeleteAGameCopy(Stock stock)
        {
            Console.WriteLine(gameManager);
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 16)
            Console.Write("Enter the games name: ".PadRight(Console.WindowWidth));
            Console.SetCursorPosition("Enter the games name: ".Length, 16);



            string search = Console.ReadLine();
            bool foundGame = false;
            bool foundCopy = false;

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
                //return -1;
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
                //return -1;
            }
            

            for (int i = 0; i < stock.Games[gameIndex].BoardGameCopies.Count; i++)
            {
                Console.Write($"\nCopy index number: {i + 1} \n{stock.Games[gameIndex].BoardGameCopies[i].GetCopyDetails()}\n");
                
            }


            int copyIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (copyIndex < 0 || copyIndex > stock.Games[gameIndex].BoardGameCopies.Count - 1)
            {
                Console.Clear();
                Console.WriteLine(gameManager);
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                Console.WriteLine("Invalid input, please try again!".PadRight(Console.WindowWidth)); // Clear line
                Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
                //return -1;
            }

            stock.Games[gameIndex].BoardGameCopies.RemoveAt(copyIndex);
            stock.SaveToFile(gamesFile);

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();

            Console.WriteLine(gameManager);
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
            Console.WriteLine("The copy has been removed from the game".PadRight(Console.WindowWidth));
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)

        }

        static void DeleteGameInstance(Stock stock, int deleteGameIndex)
        {
            stock.Games.RemoveAt(deleteGameIndex);
            stock.SaveToFile(gamesFile);

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();

            Console.WriteLine(gameManager);
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
            Console.WriteLine("The game variant and it's copies,  has been removed from the stock".PadRight(Console.WindowWidth));
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
        }


    }



}
