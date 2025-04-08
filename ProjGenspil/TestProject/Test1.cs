using ProjGenspil;

namespace TestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestAddCopy()
        {
            var variant = new BoardGameVariant();
            var copy = new BoardGameCopy();
            variant.AddCopy(copy);

            Assert.AreEqual(1, variant.BoardGameCopies.Count);
            Assert.AreEqual(copy, variant.BoardGameCopies[0]);
        }

        [TestMethod]
        public void TestRemoveCopy()
        {
            var variant = new BoardGameVariant();
            var copy = new BoardGameCopy();
            variant.AddCopy(copy);
            variant.RemoveCopy(copy);

            Assert.AreEqual(0, variant.BoardGameCopies.Count);
        }

        [TestMethod]
        public void TestGetGameDetails()
        {
            var variant = new BoardGameVariant("Chess", "Classic", "Strategy", 2, 2, "English");
            string details = variant.GetGameDetails();

            Assert.IsTrue(details.Contains("Game name: Chess"));
            Assert.IsTrue(details.Contains("Game variant: Classic"));
            Assert.IsTrue(details.Contains("Genre: Strategy"));
            Assert.IsTrue(details.Contains("Minimum number of players: 2"));
            Assert.IsTrue(details.Contains("Maximum number of players: 2"));
            Assert.IsTrue(details.Contains("Language: English"));
        }

        [TestMethod]
        public void TestGetAllCopies()
        {
            var variant = new BoardGameVariant();
            var copy1 = new BoardGameCopy();
            var copy2 = new BoardGameCopy();
            variant.AddCopy(copy1);
            variant.AddCopy(copy2);

            List<BoardGameCopy> copies = variant.GetAllCopies();

            Assert.AreEqual(2, copies.Count);
            Assert.AreEqual(copy1, copies[0]);
            Assert.AreEqual(copy2, copies[1]);
        }

        [TestMethod]
        public void TestToString()
        {
            var variant = new BoardGameVariant("Chess", "Classic", "Strategy", 2, 2, "English");
            var copy = new BoardGameCopy();
            variant.AddCopy(copy);

            string result = variant.ToString();

            Assert.IsTrue(result.Contains("Chess,Classic,Strategy,2,2,English"));
            Assert.IsTrue(result.Contains("1"));
            Assert.IsTrue(result.Contains(copy.ToString()));
        }

        [TestMethod]
        public void TestFromString()
        {
            string[] lines = new string[]
            {
                "Chess,Classic,Strategy,2,2,English",
                "1",
                "A,20.0"
            };
            int currentLine = 0;
            var variant = BoardGameVariant.FromString(lines, ref currentLine);

            Assert.AreEqual("Chess", variant.GameName);
            Assert.AreEqual("Classic", variant.GameVariant);
            Assert.AreEqual("Strategy", variant.GameGenre);
            Assert.AreEqual(2, variant.GameMinNumOfPlayers);
            Assert.AreEqual(2, variant.GameMaxNumOfPlayers);
            Assert.AreEqual("English", variant.GameLanguage);
            Assert.AreEqual(1, variant.BoardGameCopies.Count);
        }
    }
}