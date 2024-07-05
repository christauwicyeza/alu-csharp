using System;

namespace InventoryLibrary
{
    /// <summary>
    /// Represents the base class for all entities in the inventory system.
    /// </summary>
    public class BaseClass
    {
        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClass"/> class.
        /// </summary>
        public BaseClass()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        /// <summary>
        /// Updates the DateUpdated property to the current date and time.
        /// </summary>
        public void UpdateTimestamp()
        {
            DateUpdated = DateTime.Now;
        }
    }
}
