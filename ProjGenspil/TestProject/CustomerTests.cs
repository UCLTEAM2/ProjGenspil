using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjGenspil;
using System;

namespace TestProject
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TestConstructor_Default()
        {
            var customer = new Customer();
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void TestConstructor_WithParameters()
        {
            var customer = new Customer("John Doe", "1234567890", "john.doe@example.com", "Chess", "Classic");
            Assert.AreEqual("John Doe", customer.CustomerName);
            Assert.AreEqual("1234567890", customer.CustomerPhone);
            Assert.AreEqual("john.doe@example.com", customer.CustomerEmail);
            Assert.AreEqual("Chess", customer.GameName);
            Assert.AreEqual("Classic", customer.GameVariant);
        }

        [TestMethod]
        public void TestCustomerNameProperty()
        {
            var customer = new Customer();
            customer.CustomerName = "Jane Doe";
            Assert.AreEqual("Jane Doe", customer.CustomerName);
        }

        [TestMethod]
        public void TestCustomerPhoneProperty()
        {
            var customer = new Customer();
            customer.CustomerPhone = "0987654321";
            Assert.AreEqual("0987654321", customer.CustomerPhone);
        }

        [TestMethod]
        public void TestCustomerEmailProperty()
        {
            var customer = new Customer();
            customer.CustomerEmail = "jane.doe@example.com";
            Assert.AreEqual("jane.doe@example.com", customer.CustomerEmail);
        }

        [TestMethod]
        public void TestGameNameProperty()
        {
            var customer = new Customer();
            customer.GameName = "Monopoly";
            Assert.AreEqual("Monopoly", customer.GameName);
        }

        [TestMethod]
        public void TestGameVariantProperty()
        {
            var customer = new Customer();
            customer.GameVariant = "Standard";
            Assert.AreEqual("Standard", customer.GameVariant);
        }

        [TestMethod]
        public void TestGetRequestDetails()
        {
            var customer = new Customer("John Doe", "1234567890", "john.doe@example.com", "Chess", "Classic");
            string details = customer.GetRequestDetails();
            Assert.IsTrue(details.Contains("Customer Name: John Doe"));
            Assert.IsTrue(details.Contains("Phone: 1234567890"));
            Assert.IsTrue(details.Contains("Email: john.doe@example.com"));
            Assert.IsTrue(details.Contains("Game Name: Chess"));
            Assert.IsTrue(details.Contains("Game Variant: Classic"));
        }

        [TestMethod]
        public void TestToString()
        {
            var customer = new Customer("John Doe", "1234567890", "john.doe@example.com", "Chess", "Classic");
            string result = customer.ToString();
            Assert.AreEqual("John Doe,1234567890,john.doe@example.com,Chess,Classic", result);
        }

        [TestMethod]
        public void TestFromString()
        {
            string[] lines = new string[]
            {
                "John Doe,1234567890,john.doe@example.com,Chess,Classic"
            };
            int currentLine = 0;
            var customer = Customer.FromString(lines, ref currentLine);
            Assert.AreEqual("John Doe", customer.CustomerName);
            Assert.AreEqual("1234567890", customer.CustomerPhone);
            Assert.AreEqual("john.doe@example.com", customer.CustomerEmail);
            Assert.AreEqual("Chess", customer.GameName);
            Assert.AreEqual("Classic", customer.GameVariant);
        }
    }
}
