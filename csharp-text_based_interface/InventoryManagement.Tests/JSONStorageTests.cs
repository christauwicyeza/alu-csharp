using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryLibrary;
using System.Collections.Generic;

namespace InventoryManagement.Tests
{
    [TestClass]
    public class JSONStorageTests
    {
        [TestMethod]
        public void TestJSONStorageInitialization()
        {
            JSONStorage storage = new JSONStorage();
            Assert.IsNotNull(storage.All());
            Assert.AreEqual(0, storage.All().Count);
        }

        [TestMethod]
        public void TestJSONStorageNewAndAllMethods()
        {
            JSONStorage storage = new JSONStorage();
            User user = new User("Jane Doe");
            storage.New(user);
            Dictionary<string, BaseClass> objects = storage.All();
            Assert.AreEqual(1, objects.Count);
            Assert.IsTrue(objects.ContainsKey($"User.{user.Id}"));
        }
    }
}
