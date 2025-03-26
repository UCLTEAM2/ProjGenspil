using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    class BoardGameVariant
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
        public List<BoardGameCopy> BoardGameCopies { get; private set; }

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
            string details = $"\nGame name: {GameName}\nGame variant: {GameVariant}\nGenre: {GameGenre}\nMinimum number of players: {GameMinNumOfPlayers}\nMaximum number of players: {GameMaxNumOfPlayers}\nLanguage: {GameLanguage}";
            return details;
        }

    }
}
