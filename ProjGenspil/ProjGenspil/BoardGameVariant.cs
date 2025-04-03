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
        private List<BoardGameCopy> _boardGameCopies;
        

        public string GameName { get => _gameName; set => _gameName = value; }
        public string GameVariant { get => _gameVariant; set => _gameVariant = value; }
        public string GameGenre { get => _gameGenre; set => _gameGenre = value; }
        public int GameMinNumOfPlayers { get => _gameMinNumOfPlayers; set => _gameMinNumOfPlayers = value; }
        public int GameMaxNumOfPlayers { get => _gameMaxNumOfPlayers; set => _gameMaxNumOfPlayers = value; }
        public string GameLanguage { get => _gameLanguage; set => _gameLanguage = value; }
        public List<BoardGameCopy> BoardGameCopies { get; set; }

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

        public override string ToString()
        {
            string result = $"{GetGameDetails}\n";
            foreach (var copy in BoardGameCopies)
            {
                result += copy.ToString() + "\n";
            }
            return result;
        }

        public static BoardGameVariant FromString(string data)
        {
            string[] parts = data.Split(','); // Opdeler strengen baseret på komma
            return new BoardGameVariant(


                parts[0], // Navn
                parts[1], // Variant
                parts[2], // Genre
                int.Parse(parts[3]), // Minimum antal spillere
                int.Parse(parts[4]), // Maksimum antal spillere
                parts[5] // Sprog


            );
        }

    }
}
