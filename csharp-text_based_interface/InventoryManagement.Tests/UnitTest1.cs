using System;
using Xunit;
using InventoryManagement;

namespace InventoryManagement.Tests
{
    public class InventoryManagementTests
    {
        [Fact]
        public void CreateInventory_WithValidInputs_ShouldAddNewInventory()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            string userId = "user1";
            string itemId = "item1";
            int quantity = 10;

            // Act
            inventoryManager.CreateInventory(userId, itemId, quantity);

            // Assert
            var inventory = inventoryManager.GetInventory(userId, itemId);
            Assert.NotNull(inventory);
            Assert.Equal(userId, inventory.UserId);
            Assert.Equal(itemId, inventory.ItemId);
            Assert.Equal(quantity, inventory.Quantity);
        }

        [Fact]
        public void CreateInventory_WithEmptyUserId_ShouldThrowArgumentException()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            string userId = "";
            string itemId = "item1";
            int quantity = 10;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventoryManager.CreateInventory(userId, itemId, quantity));
        }

        [Fact]
        public void CreateInventory_WithNegativeQuantity_ShouldThrowArgumentException()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            string userId = "user1";
            string itemId = "item1";
            int quantity = -1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventoryManager.CreateInventory(userId, itemId, quantity));
        }

        [Fact]
        public void UpdateInventoryQuantity_WithValidInputs_ShouldUpdateQuantity()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            string userId = "user1";
            string itemId = "item1";
            int initialQuantity = 10;
            int updatedQuantity = 15;
            inventoryManager.CreateInventory(userId, itemId, initialQuantity);

            // Act
            inventoryManager.UpdateInventoryQuantity(userId, itemId, updatedQuantity);

            // Assert
            var inventory = inventoryManager.GetInventory(userId, itemId);
            Assert.NotNull(inventory);
            Assert.Equal(updatedQuantity, inventory.Quantity);
        }

        [Fact]
        public void UpdateInventoryQuantity_WithInvalidInputs_ShouldThrowArgumentException()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            string userId = "user1";
            string itemId = "item1";
            int initialQuantity = 10;
            inventoryManager.CreateInventory(userId, itemId, initialQuantity);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventoryManager.UpdateInventoryQuantity(userId, itemId, -5));
        }

        [Fact]
        public void DeleteInventory_WithValidInputs_ShouldRemoveInventory()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            string userId = "user1";
            string itemId = "item1";
            int quantity = 10;
            inventoryManager.CreateInventory(userId, itemId, quantity);

            // Act
            inventoryManager.DeleteInventory(userId, itemId);

            // Assert
            var inventory = inventoryManager.GetInventory(userId, itemId);
            Assert.Null(inventory);
        }

        [Fact]
        public void DeleteInventory_WithNonExistentInventory_ShouldNotThrowException()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            string userId = "user1";
            string itemId = "item1";

            // Act & Assert
            inventoryManager.DeleteInventory(userId, itemId); // This should not throw any exception
        }
    }
}
