using ProjGenspil;

namespace TestProject
{
    [TestClass]
    public sealed class SearchHandlerTests
    {
        private Stock stock;

        [TestInitialize]
        public void Setup()
        {
            stock = new Stock
            {
                Games = new List<BoardGameVariant>
                {
                    new BoardGameVariant("Chess", "Classic", "Strategy", 2, 2, "English"),
                    new BoardGameVariant("Monopoly", "Standard", "Family", 2, 6, "English"),
                    new BoardGameVariant("Catan", "Base", "Strategy", 3, 4, "English")
                }
            };
        }

        [TestMethod]
        public void TestSearchForAGameByName_Found()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Chess"))
                {
                    Console.SetIn(sr);
                    SearchHandler.SearchForAGameByName(stock);
                }

                var result = sw.ToString();
                Assert.IsTrue(result.Contains("Game name: Chess"));
            }
        }

        [TestMethod]
        public void TestSearchForAGameByName_NotFound()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Checkers"))
                {
                    Console.SetIn(sr);
                    SearchHandler.SearchForAGameByName(stock);
                }

                var result = sw.ToString();
                Assert.IsTrue(result.Contains("No games with the name \"Checkers\" was found!"));
            }
        }

        [TestMethod]
        public void TestSearchForAGameByNameWithIndex_Found()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Monopoly\n1"))
                {
                    Console.SetIn(sr);
                    int index = SearchHandler.SearchForAGameByNameWithIndex(stock);
                    Assert.AreEqual(1, index);
                }
            }
        }

        [TestMethod]
        public void TestSearchForAGameByNameWithIndex_NotFound()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Checkers\n1"))
                {
                    Console.SetIn(sr);
                    int index = SearchHandler.SearchForAGameByNameWithIndex(stock);
                    Assert.AreEqual(-1, index);
                }
            }
        }

        [TestMethod]
        public void TestSearchForAGameGenre_Found()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Strategy"))
                {
                    Console.SetIn(sr);
                    SearchHandler.SearchForAGameGenre(stock);
                }

                var result = sw.ToString();
                Assert.IsTrue(result.Contains("Game name: Chess"));
                Assert.IsTrue(result.Contains("Game name: Catan"));
            }
        }

        [TestMethod]
        public void TestSearchForAGameGenre_NotFound()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Adventure"))
                {
                    Console.SetIn(sr);
                    SearchHandler.SearchForAGameGenre(stock);
                }

                var result = sw.ToString();
                Assert.IsTrue(result.Contains("No games with the genre \"Adventure\" was found!"));
            }
        }

        [TestMethod]
        public void TestSearchForAGenreWithIndex_Found()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Family\n2"))
                {
                    Console.SetIn(sr);
                    int index = SearchHandler.SearchForAGenreWithIndex(stock);
                    Assert.AreEqual(1, index);
                }
            }
        }

        [TestMethod]
        public void TestSearchForAGenreWithIndex_NotFound()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Adventure\n1"))
                {
                    Console.SetIn(sr);
                    int index = SearchHandler.SearchForAGenreWithIndex(stock);
                    Assert.AreEqual(-1, index);
                }
            }
        }

        [TestMethod]
        public void TestSearchByNumberOfPlayers_Found()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("4"))
                {
                    Console.SetIn(sr);
                    SearchHandler.SearchByNumberOfPlayers(stock);
                }

                var result = sw.ToString();
                Assert.IsTrue(result.Contains("Game name: Catan"));
            }
        }

        [TestMethod]
        public void TestSearchByNumberOfPlayers_NotFound()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("8"))
                {
                    Console.SetIn(sr);
                    SearchHandler.SearchByNumberOfPlayers(stock);
                }

                var result = sw.ToString();
                Assert.IsTrue(result.Contains("No games with \"8\" players was found!"));
            }
        }

        [TestMethod]
        public void TestSearchByNumberOfPlayersWithIndex_Found()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("4\n3"))
                {
                    Console.SetIn(sr);
                    int index = SearchHandler.SearchByNumberOfPlayersWithIndex(stock);
                    Assert.AreEqual(2, index);
                }
            }
        }

        [TestMethod]
        public void TestSearchByNumberOfPlayersWithIndex_NotFound()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("8\n1"))
                {
                    Console.SetIn(sr);
                    int index = SearchHandler.SearchByNumberOfPlayersWithIndex(stock);
                    Assert.AreEqual(-1, index);
                }
            }
        }
    }
}
