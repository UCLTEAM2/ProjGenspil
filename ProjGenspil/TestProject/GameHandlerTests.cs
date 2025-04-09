using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjGenspil;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class GameHandlerTests
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
                    new BoardGameVariant("Monopoly", "Standard", "Family", 2, 6, "English")
                },
                GameRequest = new List<Customer>()
            };
        }

        [TestMethod]
        public void TestDeleteGameInstance()
        {
            GameHandler.DeleteGameInstance(stock, 0);
            Assert.AreEqual(1, stock.Games.Count);
            Assert.AreEqual("Monopoly", stock.Games[0].GameName);
        }

        [TestMethod]
        public void TestAddBoardGame()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Catan\nBase\nStrategy\n3\n4\nEnglish"))
                {
                    Console.SetIn(sr);
                    GameHandler.AddBoardGame(stock);
                }

                Assert.AreEqual(3, stock.Games.Count);
                Assert.AreEqual("Catan", stock.Games[2].GameName);
            }
        }

        [TestMethod]
        public void TestAddAGameCopy()
        {
            TextWriter originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("A\n20,0"))
                {
                    Console.SetIn(sr);
                    GameHandler.AddAGameCopy(stock, 0);
                }

                Console.SetOut(originalConsoleOut);

                Assert.AreEqual(1, stock.Games[0].BoardGameCopies.Count);
                Assert.AreEqual(Condition.A, stock.Games[0].BoardGameCopies[0].GameCondition);
                Assert.AreEqual(20.0, stock.Games[0].BoardGameCopies[0].GamePrice);
            }
        }

        [TestMethod]
        public void TestDeleteAGameCopy()
        {
            var copy = new BoardGameCopy(Condition.A, 20.0);
            stock.Games[0].AddCopy(copy);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("Chess\n1\n1"))
                {
                    Console.SetIn(sr);
                    GameHandler.DeleteAGameCopy(stock);
                }

                Assert.AreEqual(0, stock.Games[0].BoardGameCopies.Count);
            }
        }

        [TestMethod]
        public void TestPrintAllCopies()
        {
            var copy = new BoardGameCopy(Condition.A, 20.0);
            stock.Games[0].AddCopy(copy);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameHandler.PrintAllCopies(stock, 0);
                var result = sw.ToString();
                Assert.IsTrue(result.Contains("---- Copies of Chess ----"));
                Assert.IsTrue(result.Contains("Condition: A"));
                Assert.IsTrue(result.Contains("Price: 20,0"));
            }
        }

        [TestMethod]
        public void TestPrintTest()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameHandler.PrintTest(stock);
                var result = sw.ToString();
                Assert.IsTrue(result.Contains("All games in stock"));
                Assert.IsTrue(result.Contains("Game name: Chess"));
                Assert.IsTrue(result.Contains("Game name: Monopoly"));
            }
        }

        [TestMethod]
        public void TestAddCopyWithSearchIndex()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("1\nChess\n1"))
                {
                    Console.SetIn(sr);
                    int index = GameHandler.addCopyWithSearchIndex(stock);
                    Assert.AreEqual(0, index);
                }
            }
        }

        [TestMethod]
        public void TestPrintCopyWithSearchIndex()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("1\nChess\n1"))
                {
                    Console.SetIn(sr);
                    int index = GameHandler.PrintCopyWithSearchIndex(stock);
                    Assert.AreEqual(0, index);
                }
            }
        }

        [TestMethod]
        public void TestAddGameRequest()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("John Doe\n1234567890\njohn.doe@example.com\nChess\nClassic"))
                {
                    Console.SetIn(sr);
                    GameHandler.AddGameRequest(stock);
                }

                Assert.AreEqual(1, stock.GameRequest.Count);
                Assert.AreEqual("John Doe", stock.GameRequest[0].CustomerName);
            }
        }

        [TestMethod]
        public void TestPrintRequest()
        {
            var customer = new Customer("John Doe", "1234567890", "john.doe@example.com", "Chess", "Classic");
            stock.GameRequest.Add(customer);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameHandler.PrintRequest(stock);
                var result = sw.ToString();
                Assert.IsTrue(result.Contains("All games Requests"));
                Assert.IsTrue(result.Contains("Customers name: John Doe"));
            }
        }
    }
}

