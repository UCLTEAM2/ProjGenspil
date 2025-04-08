namespace ProjGenspil
{

    class GameHandler
    {

        static string gameManager = Program.gameManager;
        static string searchMenu = Program.searchMenu;
        static string stockManager = Program.stockManager;

        static string gamesFile = Program.gamesFile;
        static string requestFile = Program.requestFile;


        public static void DeleteGameInstance(Stock stock, int deleteGameIndex)
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

        public static void AddBoardGame(Stock stock)
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

        public static void AddAGameCopy(Stock stock, int gameIndex)
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

            BoardGameCopy copy = new BoardGameCopy(conditionEnum, price);

            stock.Games[gameIndex].AddCopy(copy);
            stock.SaveToFile(gamesFile);

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();

            Console.WriteLine(gameManager);
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
            Console.WriteLine($"The copy has been added to the game".PadRight(Console.WindowWidth));
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)

        }

        public static void DeleteAGameCopy(Stock stock)
        {
            Console.WriteLine(gameManager);
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 16)
            Console.Write("Enter the games name: ".PadRight(Console.WindowWidth));
            Console.SetCursorPosition("Enter the games name: ".Length, 16);



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

            Console.Write("\nEnter the copy index number: ");
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

        public static void PrintAllCopies(Stock stock, int gameIndex)
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

        public static void PrintTest(Stock stock)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();

            Console.WriteLine(stockManager);

            Console.WriteLine("\n---- All games in stock ----".PadRight(Console.WindowWidth));
            foreach (var game in stock.Games)
            {

                Console.WriteLine(game.GetGameDetails());

            }

        }

        public static int addCopyWithSearchIndex(Stock stock)
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
                        gameIndex = SearchHandler.SearchForAGameByNameWithIndex(stock);

                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        gameIndex = SearchHandler.SearchForAGenreWithIndex(stock);

                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        gameIndex = SearchHandler.SearchByNumberOfPlayersWithIndex(stock);

                        break;


                }

                return gameIndex;
            }
            return gameIndex;

        }

        public static int PrintCopyWithSearchIndex(Stock stock)
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
                        gameIndex = SearchHandler.SearchForAGameByNameWithIndex(stock);

                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        gameIndex = SearchHandler.SearchForAGenreWithIndex(stock);

                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        gameIndex = SearchHandler.SearchByNumberOfPlayersWithIndex(stock);

                        break;


                }

                return gameIndex;
            }
            return gameIndex;

        }

        public static void EditGameVariant(Stock stock, int editIndex)
        {

        }

        public static void AddGameRequest(Stock stock)
        {
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
            Console.WriteLine("\n---- Enter the customers information ----".PadRight(Console.WindowWidth));

            Console.Write("\nEnter the customers full name: ");
            string customerName = Console.ReadLine();

            Console.Write("\nEnter the customers phone number: ");
            string customerPhone = (Console.ReadLine());

            Console.Write("\nEnter the customers email adress: ");
            string customerEmail = Console.ReadLine();

            Console.WriteLine("\n---- Enter the information on the game ----");

            Console.Write("\nEnter the name of the game: ");
            string gameName = Console.ReadLine();

            Console.Write("\nEnter the variant of the game: ");
            string gameVariant = Console.ReadLine();




            Customer customer = new Customer(customerName, customerPhone, customerEmail, gameName, gameVariant);

            stock.GameRequest.Add(customer);
            stock.SaveToFileRequest(requestFile);

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();

            Console.WriteLine(gameManager);
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)
            Console.WriteLine("The request has been added to the stock".PadRight(Console.WindowWidth));
            Console.SetCursorPosition(0, 16); // Move cursor below the menu (line 15)

        }

        public static void PrintRequest(Stock stock)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();

            Console.WriteLine(stockManager);

            Console.WriteLine("\n---- All games Requests ----".PadRight(Console.WindowWidth));
            foreach (var customer in stock.GameRequest)
            {



                Console.WriteLine(customer.GetRequestDetails());

            }

        }

    }
}
