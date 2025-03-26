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
        private int _gameNumOfPlayers;
        private string _gameLanguage;
        private List<BoardGameCopy> _boardGameCopies;
        

        public string GameName { get => _gameName; set => _gameName = value; }
        public string GameVariant { get => _gameVariant; set => _gameVariant = value; }
        public string GameGenre { get => _gameGenre; set => _gameGenre = value; }
        public int GameNumOfPlayers { get => _gameNumOfPlayers; set => _gameNumOfPlayers = value; }
        public string GameLanguage { get => _gameLanguage; set => _gameLanguage = value; }
        public List<BoardGameCopy> BoardGameCopies { get; set; }

        public BoardGameVariant(string gameName, string gameVariant, string gameGenre, int gameNumOfPlayers, string gameLanguage)
        {
            _gameName = gameName;
            _gameVariant = gameVariant;
            _gameGenre = gameGenre;
            _gameNumOfPlayers = gameNumOfPlayers;
            _gameLanguage = gameLanguage;
            _boardGameCopies = new List<BoardGameCopy>();
        
        }
    }
}
