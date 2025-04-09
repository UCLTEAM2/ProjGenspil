using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjGenspil;
using System;

namespace TestProject
{
    [TestClass]
    public class BoardGameCopyTests
    {
        [TestMethod]
        public void TestConstructor_Default()
        {
            var copy = new BoardGameCopy();
            Assert.IsNotNull(copy);
        }

        [TestMethod]
        public void TestConstructor_WithParameters()
        {
            var copy = new BoardGameCopy(Condition.A, 20.0);
            Assert.AreEqual(Condition.A, copy.GameCondition);
            Assert.AreEqual(20.0, copy.GamePrice);
        }

        [TestMethod]
        public void TestGameConditionProperty()
        {
            var copy = new BoardGameCopy();
            copy.GameCondition = Condition.B;
            Assert.AreEqual(Condition.B, copy.GameCondition);
        }

        [TestMethod]
        public void TestGamePriceProperty()
        {
            var copy = new BoardGameCopy();
            copy.GamePrice = 25.0;
            Assert.AreEqual(25.0, copy.GamePrice);
        }

        [TestMethod]
        public void TestBoardGameVariantProperty()
        {
            var variant = new BoardGameVariant("Chess", "Classic");
            var copy = new BoardGameCopy();
            copy.BoardGameVariant = variant;
            Assert.AreEqual(variant, copy.BoardGameVariant);
        }

        [TestMethod]
        public void TestGetCopyDetails()
        {
            var copy = new BoardGameCopy(Condition.A, 20.0);
            string details = copy.GetCopyDetails();
            Assert.IsTrue(details.Contains("Condition: A"));
            Assert.IsTrue(details.Contains("Price: 20,0"));
        }

        [TestMethod]
        public void TestToString()
        {
            var copy = new BoardGameCopy(Condition.A, 20.0);
            string result = copy.ToString();
            Assert.AreEqual("A,20,0", result);
        }

        [TestMethod]
        public void TestFromString()
        {
            string data = "A,20,0";
            var copy = BoardGameCopy.FromString(data);
            Assert.AreEqual(Condition.A, copy.GameCondition);
            Assert.AreEqual(20.0, copy.GamePrice);
        }
    }
}
