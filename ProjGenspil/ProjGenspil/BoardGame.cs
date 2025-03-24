using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    internal class BoardGame
    {
        private string _gameName;
        private string _gameVariant;
        private string _gameGenre;
        private int _gameNumOfPlayers;
        private string _gameCondition;
        private string _gameLanguage;
        private double _gamePrice;

        public string GameName { get => _gameName; set => _gameName = value; }
        public string GameVariant { get => _gameVariant; set => _gameVariant = value; }
        public string GameGenre { get => _gameGenre; set => _gameGenre = value; }
        public int GameNumOfPlayers { get => _gameNumOfPlayers; set => _gameNumOfPlayers = value; }
        public string GameCondition { get => _gameCondition; set => _gameCondition = value; }
        public string GameLanguage { get => _gameLanguage; set => _gameLanguage = value; }
        public double GamePrice { get => _gamePrice; set => _gamePrice = value; }

        public BoardGame(string gameName, string gameVariant, string gameGenre, int gameNumOfPlayers, string gameCondition, string gameLanguage, double gamePrice)
        {
            GameName = gameName;
            GameVariant = gameVariant;
            GameGenre = gameGenre;
            GameNumOfPlayers = gameNumOfPlayers;
            GameCondition = gameCondition;
            GameLanguage = gameLanguage;
            GamePrice = gamePrice;

        }
    }
}
