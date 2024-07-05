using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void TestInventoryInitialization()
        {
            string userId = "user1";
            string itemId = "item1";
            Inventory inventory = new Inventory(userId, itemId, 5);
            Assert.AreEqual(userId, inventory.UserId);
            Assert.AreEqual(itemId, inventory.ItemId);
            Assert.AreEqual(5, inventory.Quantity);
        }

        [TestMethod]
        public void TestInventoryQuantityValidation()
        {
            Assert.ThrowsException<ArgumentException>(() => new Inventory("user1", "item1", -1));
        }
    }
}
