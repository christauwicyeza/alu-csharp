using System;

namespace InventoryLibrary
{
    /// <summary>
    /// Represents a user in the inventory system.
    /// </summary>
    public class User : BaseClass
    {
        /// <summary>
        /// Gets or sets the name of the user. Required.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        public User(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is required.", nameof(name));
            }

            Name = name;
        }
    }
}
