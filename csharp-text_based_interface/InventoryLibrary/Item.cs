using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
    public class Item : BaseClass
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string? Description { get; set; } // Make Description nullable

        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the item.
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="price">The price of the item.</param>
        public Item(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}
