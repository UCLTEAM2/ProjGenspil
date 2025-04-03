using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    public class BoardGameCopy
    {
        private Condition _gameCondition;
        private double _gamePrice;
        private BoardGameVariant _boardGameVariant;

        public Condition GameCondition { get => _gameCondition; set => _gameCondition = value; }
        public double GamePrice { get => _gamePrice; set => _gamePrice = value; }
        public BoardGameVariant BoardGameVariant { get; set; }

        // Existing constructor
        public BoardGameCopy(Condition gameCondition, double gamePrice)
        {
            _gameCondition = gameCondition;
            _gamePrice = gamePrice;
        }

        // Parameterless constructor
        public BoardGameCopy() { }

        public string GetCopyDetails()
        {
            string copyDetails = $"Game condition: \"{GameCondition}\"".PadRight(Console.WindowWidth) +
                $"\nPrice: {GamePrice} DOLLARS".PadRight(Console.WindowWidth);
            return copyDetails;
        }

        public override string ToString()
        {
            string gameVariantName = BoardGameVariant != null ? BoardGameVariant.GameName : "No Game Name";
            string gameVariantVariant = BoardGameVariant != null ? BoardGameVariant.GameVariant : "No Game Variant";

            return $"{GameCondition},{GamePrice},{gameVariantName},{gameVariantVariant}";
        }

        public static BoardGameCopy FromString(string data)
        {
            string[] parts = data.Split(',');
            return new BoardGameCopy
            {
                GameCondition = (Condition)Enum.Parse(typeof(Condition), parts[0]),
                GamePrice = double.Parse(parts[1]),
                BoardGameVariant = new BoardGameVariant
                {
                    GameName = parts[2],
                    GameVariant = parts[3]
                }
            };
        }
    }

}
