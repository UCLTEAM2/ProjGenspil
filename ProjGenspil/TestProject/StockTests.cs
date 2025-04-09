using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjGenspil;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class StockTests
    {
        [TestMethod]
        public void TestGamesProperty()
        {
            var stock = new Stock();
            var games = new List<BoardGameVariant>
            {
                new BoardGameVariant("Chess", "Classic"),
                new BoardGameVariant("Monopoly", "Standard")
            };
            stock.Games = games;
            Assert.AreEqual(games, stock.Games);
        }

        [TestMethod]
        public void TestGameRequestProperty()
        {
            var stock = new Stock();
            var requests = new List<Customer>
            {
                new Customer("John Doe", "1234567890", "john.doe@example.com", "Chess", "Classic"),
                new Customer("Jane Doe", "0987654321", "jane.doe@example.com", "Monopoly", "Standard")
            };
            stock.GameRequest = requests;
            Assert.AreEqual(requests, stock.GameRequest);
        }

        [TestMethod]
        public void TestSaveToFile()
        {
            var stock = new Stock
            {
                Games = new List<BoardGameVariant>
                {
                    new BoardGameVariant("Chess", "Classic", "Strategy", 2, 2, "English"),
                    new BoardGameVariant("Monopoly", "Standard", "Family", 2, 6, "English")
                }
            };
            string filePath = "test_games.txt";
            stock.SaveToFile(filePath);

            Assert.IsTrue(File.Exists(filePath));
            var lines = File.ReadAllLines(filePath);
            Assert.AreEqual(3, lines.Length); // 2 games + 1 line for the count
            File.Delete(filePath);
        }

        [TestMethod]
        public void TestSaveToFileRequest()
        {
            var stock = new Stock
            {
                GameRequest = new List<Customer>
                {
                    new Customer("John Doe", "1234567890", "john.doe@example.com", "Chess", "Classic"),
                    new Customer("Jane Doe", "0987654321", "jane.doe@example.com", "Monopoly", "Standard")
                }
            };
            string filePath = "test_requests.txt";
            stock.SaveToFileRequest(filePath);

            Assert.IsTrue(File.Exists(filePath));
            var lines = File.ReadAllLines(filePath);
            Assert.AreEqual(3, lines.Length); // 2 requests + 1 line for the count
            File.Delete(filePath);
        }

        [TestMethod]
        public void TestLoadFromFile()
        {
            string filePath = "test_games.txt";
            var lines = new string[]
            {
                "2",
                "Chess,Classic,Strategy,2,2,English",
                "0",
                "Monopoly,Standard,Family,2,6,English",
                "0"
            };
            File.WriteAllLines(filePath, lines);

            var stock = new Stock();
            stock.LoadFromFile(filePath);

            Assert.AreEqual(2, stock.Games.Count);
            Assert.AreEqual("Chess", stock.Games[0].GameName);
            Assert.AreEqual("Monopoly", stock.Games[1].GameName);
            File.Delete(filePath);
        }

        [TestMethod]
        public void TestLoadFromFileRequest()
        {
            string filePath = "test_requests.txt";
            var lines = new string[]
            {
                "2",
                "John Doe,1234567890,john.doe@example.com,Chess,Classic",
                "Jane Doe,0987654321,jane.doe@example.com,Monopoly,Standard"
            };
            File.WriteAllLines(filePath, lines);

            var stock = new Stock();
            stock.LoadFromFileRequest(filePath);

            Assert.AreEqual(2, stock.GameRequest.Count);
            Assert.AreEqual("John Doe", stock.GameRequest[0].CustomerName);
            Assert.AreEqual("Jane Doe", stock.GameRequest[1].CustomerName);
            File.Delete(filePath);
        }
    }
}
