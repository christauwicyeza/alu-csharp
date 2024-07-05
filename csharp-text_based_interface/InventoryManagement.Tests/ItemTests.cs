using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryLibrary;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestItemInitialization()
        {
            string name = "Laptop";
            float price = 999.99f;
            Item item = new Item(name, price);
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(price, item.Price);
        }

        [TestMethod]
        public void TestItemOptionalProperties()
        {
            Item item = new Item("Laptop", 999.99f)
            {
                Description = "A high-end gaming laptop.",
                Tags = new List<string> { "Electronics", "Computers" }
            };
            Assert.AreEqual("A high-end gaming laptop.", item.Description);
            CollectionAssert.AreEqual(new List<string> { "Electronics", "Computers" }, item.Tags);
        }
    }
}
