using System;

namespace InventoryLibrary
{
    /// <summary>
    /// Represents an inventory record that links a user and an item with a quantity.
    /// </summary>
    public class Inventory : BaseClass
    {
        /// <summary>
        /// Gets or sets the user ID. Required.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the item ID. Required.
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item. Default is 1. Cannot be less than 0.
        /// </summary>
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be less than 0.", nameof(value));
                }
                _quantity = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="itemId">The item ID.</param>
        /// <param name="quantity">The quantity of the item. Default is 1.</param>
        public Inventory(string userId, string itemId, int quantity = 1)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("User ID is required.", nameof(userId));
            }
            if (string.IsNullOrEmpty(itemId))
            {
                throw new ArgumentException("Item ID is required.", nameof(itemId));
            }

            UserId = userId;
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}
