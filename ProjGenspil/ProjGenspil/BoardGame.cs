using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    internal class BoardGame
    {
        private string gameName;
        private string gameVarient;
        private string gameGenre;
        private int gamePlayers;
        private string gameCondition;
        private string gameLanguage;
        private double gamePrice;

        public string GameName { get => gameName; set => gameName = value; }
        public string GameVarient { get => gameVarient; set => gameVarient = value; }
        public string GameGenre { get => gameGenre; set => gameGenre = value; }
        public int GamePlayers { get => gamePlayers; set => gamePlayers = value; }
        public string GameCondition { get => gameCondition; set => gameCondition = value; }
        public string GameLanguage { get => gameLanguage; set => gameLanguage = value; }
        public double GamePrice { get => gamePrice; set => gamePrice = value; }

        public BoardGame(string gameName, string gameVarient, string gameGenre, int gamePlayers, string gameCondition, string gameLanguage, double gamePrice)
        {
            GameName = gameName;
            GameVarient = gameVarient;
            GameGenre = gameGenre;
            GamePlayers = gamePlayers;
            GameCondition = gameCondition;
            GameLanguage = gameLanguage;
            GamePrice = gamePrice;
        }
    }
}
