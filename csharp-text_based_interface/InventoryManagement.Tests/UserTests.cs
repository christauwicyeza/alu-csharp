using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestUserInitialization()
        {
            string name = "John Doe";
            User user = new User(name);
            Assert.AreEqual(name, user.Name);
        }

        [TestMethod]
        public void TestUserUpdateTimestamp()
        {
            User user = new User("John Doe");
            DateTime originalDateUpdated = user.DateUpdated;
            user.UpdateTimestamp();
            Assert.AreNotEqual(originalDateUpdated, user.DateUpdated);
        }
    }
}
