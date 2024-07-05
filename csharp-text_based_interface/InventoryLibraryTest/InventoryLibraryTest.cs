using System;
using InventoryLibrary;
using System.Collections.Generic;

namespace InventoryLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // instance of BaseClass
            BaseClass baseClass = new BaseClass();
            Console.WriteLine($"ID: {baseClass.Id}");
            Console.WriteLine($"Date Created: {baseClass.DateCreated}");
            Console.WriteLine($"Date Updated: {baseClass.DateUpdated}");

            // Update the timestamp
            baseClass.UpdateTimestamp();
            Console.WriteLine($"Date Updated after update: {baseClass.DateUpdated}");
            Console.WriteLine();

            // Create an instance of User
            User user = new User("John Doe");
            Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}, Date Created: {user.DateCreated}, Date Updated: {user.DateUpdated}");
            Console.WriteLine();

            // Create an instance of Item
            Item item = new Item("Laptop", 999.99f)
            {
                Description = "A high-end gaming laptop.",
                Tags = new List<string> { "Electronics", "Computers" }
            };
            Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name}, Description: {item.Description}, Price: {item.Price}, Date Created: {item.DateCreated}, Date Updated: {item.DateUpdated}");
            Console.WriteLine("Tags: " + string.Join(", ", item.Tags));
            Console.WriteLine();

            // Create an instance of Inventory
            Inventory inventory = new Inventory(user.Id, item.Id, 5);
            Console.WriteLine($"Inventory ID: {inventory.Id}, User ID: {inventory.UserId}, Item ID: {inventory.ItemId}, Quantity: {inventory.Quantity}, Date Created: {inventory.DateCreated}, Date Updated: {inventory.DateUpdated}");
            Console.WriteLine();

            // Create an instance of JSONStorage
            JSONStorage storage = new JSONStorage();

            // Add objects to storage
            storage.New(user);
            storage.New(item);
            storage.New(inventory);

            // Save objects to JSON file
            storage.Save();

            // Output objects
            Console.WriteLine("Stored Objects:");
            foreach (var obj in storage.All())
            {
                Console.WriteLine($"{obj.Key}: {obj.Value.GetType().Name}, ID: {obj.Value.Id}");
            }

            // Load objects from JSON file
            JSONStorage newStorage = new JSONStorage();
            Console.WriteLine("\nLoaded Objects:");
            foreach (var obj in newStorage.All())
            {
                Console.WriteLine($"{obj.Key}: {obj.Value.GetType().Name}, ID: {obj.Value.Id}");
            }
        }
    }
}
