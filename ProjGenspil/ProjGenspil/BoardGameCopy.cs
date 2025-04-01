using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    class BoardGameCopy
    {
        private char _gameCondition;
        private double _gamePrice;
        private BoardGameVariant variant;

        
        public char GameCondition { get => _gameCondition; set => _gameCondition = value; }
        public double GamePrice { get => _gamePrice; set => _gamePrice = value; }
        

        public BoardGameCopy(char gameCondition, double gamePrice)
        {
            _gameCondition = gameCondition;
            _gamePrice = gamePrice;
        }

        public string GetCopyDetails()
        {
            string copyDetails = $"Game condition: \"{GameCondition}\"".PadRight(Console.WindowWidth) + 
                $"\nPrice: {GamePrice} DOLLARS".PadRight(Console.WindowWidth);
            return copyDetails;
        }
    }
}
