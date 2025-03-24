using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    class BoardGameCopy
    {
        private string _gameCondition;
        private double _gamePrice;
        private BoardGameVariant variant;

        
        public string GameCondition { get => _gameCondition; set => _gameCondition = value; }
        public double GamePrice { get => _gamePrice; set => _gamePrice = value; }
        public BoardGameVariant Variant { get => variant; set => variant = value; }

        public BoardGameCopy(string gameCondition, double gamePrice, BoardGameVariant variant)
        {
            GameCondition = gameCondition;
            GamePrice = gamePrice;
            Variant = variant;
        }

    }
}
