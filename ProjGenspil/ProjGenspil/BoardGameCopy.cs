namespace ProjGenspil
{
    public class BoardGameCopy
    {
        private Condition _gameCondition;
        private double _gamePrice;
        private BoardGameVariant _boardGameVariant;

        public Condition GameCondition { get => _gameCondition; set => _gameCondition = value; }
        public double GamePrice { get => _gamePrice; set => _gamePrice = value; }
        public BoardGameVariant BoardGameVariant { get => _boardGameVariant; set => _boardGameVariant = value; }

        // Parameterless constructor
        public BoardGameCopy() { }

        // Existing constructor
        public BoardGameCopy(Condition gameCondition, double gamePrice)
        {
            _gameCondition = gameCondition;
            _gamePrice = gamePrice;
        }

        public string GetCopyDetails()
        {
            string copyDetails = $"Game condition: \"{GameCondition}\"".PadRight(Console.WindowWidth) +
                $"\nPrice: {GamePrice:C}".PadRight(Console.WindowWidth);
            return copyDetails;
        }

        public override string ToString()
        {
            string gameVariantName = BoardGameVariant != null ? BoardGameVariant.GameName : "No Game Name";
            string gameVariantVariant = BoardGameVariant != null ? BoardGameVariant.GameVariant : "No Game Variant";

            return $"{GameCondition},{GamePrice}";
        }

        public static BoardGameCopy FromString(string data)
        {
            string[] parts = data.Split(',');
            return new BoardGameCopy
            {
                GameCondition = (Condition)Enum.Parse(typeof(Condition), parts[0]),
                GamePrice = double.Parse(parts[1]),
            };
        }
    }

}
