namespace ProjGenspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //User menu

            while (true)
            {

                Console.WriteLine("\n--- System Menu ---");
                Console.WriteLine("0. Search for a game");
                Console.WriteLine("1. Add a new game to the stock");
                Console.WriteLine("2. Edit a games details");
                Console.WriteLine("2. Remove a game from the stock");
                Console.WriteLine("3. Show all games in stock");
                Console.WriteLine("4. Show all games in waiting list");
                Console.WriteLine("5. Show all games in requests");
                Console.WriteLine("6. Show all games in stock, waiting list and requests");
                Console.WriteLine("7. Exit");

                ConsoleKeyInfo menuChoice = Console.ReadKey(true);
               
                switch (menuChoice.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        //Search for a game
                        //TODO: Open stock list, make a search function, that loops through the list/array/arrayList, to find a matching game. The list is located in the Stock class.
                        Console.WriteLine("\nSearch for a game");
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //Add a new game to the stock
                        //TODO: Method that creates a game with parameters from a constructor, and saves the game in a list in the Stock Class. The constructor is located in the BoardGame Class.
                        Console.WriteLine("\nAdd a game");
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //Edit a games details
                        //TODO: Method that ask user to enter name of the game, then shows a list of the game with different conditions, and prompts the user to pick one and then what details to change The Method is located in the BoardGame class.
                        Console.WriteLine("\nEdit a game");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //Remove a game from the stock
                        //TODO: Method that ask a user to enter the games name, and then the method shows a list of the game, with different conditions if any. Method is located in the BoardGame class.
                        Console.WriteLine("\nRemoving a game");
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //Show all games in stock
                        //TODO: A print Method, that prints the whole list in Stock, sorted by their condition. Method is located in the stock class.
                        Console.WriteLine("\nShow all games in stock");
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        //Show all games in waiting list
                        //TODO: A print Method, that prints all the games, that are currently on a waiting list sorted by either new/old or old/new. Method is located Stock Class.
                        Console.WriteLine("\nShow all games in waiting list");
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        //Show all requests
                        //TODO: A print Method, that prints all the requests made by the customers, sorted by either new -> old or then old -> new. Method is located Stock Class.
                        Console.WriteLine("\nShow all requests");
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        //Show all games, waiting list and requests in stock
                        //TODO: A print method that prints everything in a sorted manner. Like games grouped by name and sorted by condition. Waiting list sorted by new/old or old/new and same with requests. Method is located Stock Class.
                        Console.WriteLine("\nShow All lists at once");
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("\nTest GOODBYE! ");
                        return;
                }
                
            }

            

        }
    }
}
