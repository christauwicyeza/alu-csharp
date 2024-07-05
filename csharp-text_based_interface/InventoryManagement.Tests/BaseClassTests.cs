using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    [TestClass]
    public class BaseClassTests
    {
        [TestMethod]
        public void TestBaseClassInitialization()
        {
            BaseClass baseClass = new BaseClass();
            Assert.IsNotNull(baseClass.Id);
            Assert.AreEqual(DateTime.Now.Date, baseClass.DateCreated.Date);
            Assert.AreEqual(DateTime.Now.Date, baseClass.DateUpdated.Date);
        }

        [TestMethod]
        public void TestBaseClassUpdateTimestamp()
        {
            BaseClass baseClass = new BaseClass();
            DateTime originalDateUpdated = baseClass.DateUpdated;
            baseClass.UpdateTimestamp();
            Assert.AreNotEqual(originalDateUpdated, baseClass.DateUpdated);
        }
    }
}
