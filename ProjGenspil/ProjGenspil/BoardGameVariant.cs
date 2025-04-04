using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    public class BoardGameVariant
    {
        private string _gameName;
        private string _gameVariant;
        private string _gameGenre;
        private int _gameMinNumOfPlayers;
        private int _gameMaxNumOfPlayers;
        private string _gameLanguage;
        private List<BoardGameCopy> _boardGameCopies = new List<BoardGameCopy>();


        public string GameName { get => _gameName; set => _gameName = value; }
        public string GameVariant { get => _gameVariant; set => _gameVariant = value; }
        public string GameGenre { get => _gameGenre; set => _gameGenre = value; }
        public int GameMinNumOfPlayers { get => _gameMinNumOfPlayers; set => _gameMinNumOfPlayers = value; }
        public int GameMaxNumOfPlayers { get => _gameMaxNumOfPlayers; set => _gameMaxNumOfPlayers = value; }
        public string GameLanguage { get => _gameLanguage; set => _gameLanguage = value; }
        //public List<BoardGameCopy> BoardGameCopies => _boardGameCopies ??= new List<BoardGameCopy>();

        public List<BoardGameCopy> BoardGameCopies { get => _boardGameCopies; set => _boardGameCopies = value; }

        public BoardGameVariant() { }

        public BoardGameVariant(string gameName, string gameVariant, string gameGenre, int gameMinNumOfPlayers, int gameMaxNumOfPlayers, string gameLanguage)
        {
            _gameName = gameName;
            _gameVariant = gameVariant;
            _gameGenre = gameGenre;
            _gameMinNumOfPlayers = gameMinNumOfPlayers;
            _gameMaxNumOfPlayers = gameMaxNumOfPlayers;
            _gameLanguage = gameLanguage;
            _boardGameCopies = new List<BoardGameCopy>();
        
        }

        public void AddCopy(BoardGameCopy copy)
        {
            _boardGameCopies.Add(copy);
        }

        public void RemoveCopy(BoardGameCopy copy)
        {
            _boardGameCopies.Remove(copy);
        }


        public string GetGameDetails()
        {
            string details = $"\nGame name: {GameName}".PadRight(Console.WindowWidth) +
                $"\nGame variant: {GameVariant}".PadRight(Console.WindowWidth) +
                $"\nGenre: {GameGenre}".PadRight(Console.WindowWidth) +
                $"\nMinimum number of players: {GameMinNumOfPlayers}".PadRight(Console.WindowWidth) +
                $"\nMaximum number of players: {GameMaxNumOfPlayers}".PadRight(Console.WindowWidth) +
                $"\nLanguage: {GameLanguage}".PadRight(Console.WindowWidth);
            return details;
        }

        public List<BoardGameCopy> GetAllCopies()
        {
            return new List<BoardGameCopy>(_boardGameCopies); //Returner en kopi for at undgå ekstern manipulation
        }

        //public override string ToString()
        //{
        //    string variantData = $"{GameName},{GameVariant},{GameGenre},{GameMinNumOfPlayers},{GameMaxNumOfPlayers},{GameLanguage}";
        //    variantData += $"\n{BoardGameCopies.Count}";

        //    foreach (var copy in BoardGameCopies)
        //    {
        //        variantData += $"\n{copy.ToString()}";
        //    }
        //    return variantData;
        //}

        public override string ToString()
        {
            var variantData = new System.Text.StringBuilder();
            variantData.Append($"{GameName},{GameVariant},{GameGenre},{GameMinNumOfPlayers},{GameMaxNumOfPlayers},{GameLanguage}");
            variantData.AppendLine(); // Adds platform-specific line ending (\r\n on Windows)
            variantData.Append($"{BoardGameCopies.Count}");
            variantData.AppendLine(); // Adds platform-specific line ending

            foreach (var copy in BoardGameCopies)
            {
                variantData.Append($"{copy.ToString()}");
                variantData.AppendLine(); // Adds platform-specific line ending
            }

            return variantData.ToString();
        }


        public static BoardGameVariant FromString(string[] lines, ref int currentLine)
        {
            // Parse the BoardGameVariant details
            string[] variantParts = lines[currentLine].Split(',');
            var variant = new BoardGameVariant
            {
                GameName = variantParts[0],
                GameVariant = variantParts[1],
                GameGenre = variantParts[2],
                GameMinNumOfPlayers = int.Parse(variantParts[3]),
                GameMaxNumOfPlayers = int.Parse(variantParts[4]),
                GameLanguage = variantParts[5]
            };

            // Move to the next line (number of copies)
            currentLine++;
            int numCopies = int.Parse(lines[currentLine]);

            // Parse each copy
            for (int i = 0; i < numCopies; i++)
            {
                currentLine++;
                var copy = BoardGameCopy.FromString(lines[currentLine]);
                copy.BoardGameVariant = variant; // Set the reference back to the variant
                variant.AddCopy(copy);
            }

         return variant;
        }

    }
}
