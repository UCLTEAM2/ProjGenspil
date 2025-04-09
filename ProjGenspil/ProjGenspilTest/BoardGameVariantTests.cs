using ProjGenspil;

namespace ProjGenspilTest
{
    [TestClass]
    public sealed class BoardGameVariantTests
    {
        [TestMethod]
        public void GetGameName_ShouldReturnCorrectGameName()
        {
            // Arrange
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");
            

            // Act
            var actual = game.GameName;

            //Assert
            var expected = "Monopoly";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGameVariant_ShouldReturnCorrectGameVariant()
        {
            // Arrange
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");
            

            // Act
            var actual = game.GameVariant;

            //Assert
            var expected = "Junior";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGameGenre_ShouldReturnCorrectGameGenre()
        {
            // Arrange
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");
            

            // Act
            var actual = game.GameGenre;

            //Assert
            var expected = "Boardgame";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMinimumNumOfPlayers_ShouldReturnCorrectMinNumOfPlayers()
        {
            // Arrange
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");
            

            // Act
            var actual = game.GameMinNumOfPlayers;

            //Assert
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaximumNumOfPlayers_ShouldReturnCorrectMaxNumOfPlayers()
        {
            // Arrange
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");
           

            // Act
            var actual = game.GameMaxNumOfPlayers;

            //Assert
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGameLanguage_ShouldReturnCorrectGameLanguage()
        {
            // Arrange
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");
            

            // Act
            var actual = game.GameLanguage;

            //Assert
            var expected = "Dansk";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetGameDetails_ShouldReturnCorrectGameDetails()
        {
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");

            int windowWidth = 80;
            

            // Act
            var actual = game.GetGameDetails();

            //Assert
            var expected = "\nGame name: Monopoly".PadRight(windowWidth) +
                "\nGame variant: Junior".PadRight(windowWidth) +
                "\nGenre: Boardgame".PadRight(windowWidth) +
                "\nMinimum number of players: 2".PadRight(windowWidth) +
                "\nMaximum number of players: 8".PadRight(windowWidth) +
                "\nLanguage: Dansk".PadRight(windowWidth);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllCopies_ShouldReturnAllCopes()
        {
            // Arrange
            var game = new BoardGameVariant("Monopoly", "Junior", "Boardgame", 2, 8, "Dansk");
            var copy1 = new BoardGameCopy(Condition.A, 250.0);
            var copy2 = new BoardGameCopy(Condition.F, 0.0);
            game.AddCopy(copy1);
            game.AddCopy(copy2);
            int windowWidth = 80;
            var expectedGameDetails = "\nGame name: Monopoly".PadRight(windowWidth) +
                "\nGame variant: Junior".PadRight(windowWidth) +
                "\nGenre: Boardgame".PadRight(windowWidth) +
                "\nMinimum number of players: 2".PadRight(windowWidth) +
                "\nMaximum number of players: 8".PadRight(windowWidth) +
                "\nLanguage: Dansk".PadRight(windowWidth);

            


            // Act
            var gameDetails = game.GetGameDetails();
            var copy1Details = copy1.GetCopyDetails();
            var copy2Details = copy2.GetCopyDetails();
            var copyCount = game.GetAllCopies();

            // Assert
            var expectedCopy1Details = "Condition: A".PadRight(windowWidth) +
                "\nPrice: 250,0".PadRight(windowWidth);
            var expectedCopy2Details = "Condition: F".PadRight(windowWidth) +
                "\nPrice: 0,0".PadRight(windowWidth);
            var expectedCopyCount = 2;
            Assert.AreEqual(expectedGameDetails, gameDetails);
            Assert.AreEqual(expectedCopy1Details, copy1Details);
            Assert.AreEqual(expectedCopy2Details, copy2Details);
            Assert.AreEqual(expectedCopyCount, copyCount.Count);
        }

        [TestMethod]
        public void ToString_ReturnsExpectedFormat_WithGameDetailsAndCopies()
        {

            // Arrange
            var game = new BoardGameVariant
                {
                GameName = "Monopoly",
                GameVariant = "Junior",
                GameGenre = "Boardgame",
                GameMinNumOfPlayers = 2,
                GameMaxNumOfPlayers = 8,
                GameLanguage = "DA",
                BoardGameCopies = new List<BoardGameCopy>()
                {
                    new BoardGameCopy {GameCondition = Condition.A, GamePrice = 250.0 },
                    new BoardGameCopy {GameCondition = Condition.F, GamePrice = 0.0 }
                }
            };

            // Act
            string result = game.ToString();
            var copyCount = game.BoardGameCopies.Count;

            // Assert
            string toStringExpectedResult = "Monopoly,Junior,Boardgame,2,8,DA" +
                $"\r\n{copyCount}" +
                "\r\nA,250,0" +
                "\r\nF,0,0\r\n";

            Assert.AreEqual(toStringExpectedResult, result);
        }
    }
}
