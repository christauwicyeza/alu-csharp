using System;
using System.Collections.Generic;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        private static JSONStorage storage = new JSONStorage();

        static void Main(string[] args)
        {
            storage.Load();
            PrintCommands();

            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine().ToLower();
                string[] commandParts = input.Split(' ');

                if (commandParts.Length == 0)
                {
                    continue;
                }

                switch (commandParts[0])
                {
                    case "classnames":
                        PrintClassNames();
                        break;
                    case "all":
                        if (commandParts.Length == 1)
                        {
                            PrintAll();
                        }
                        else if (commandParts.Length == 2)
                        {
                            PrintAll(commandParts[1]);
                        }
                        break;
                    case "create":
                        if (commandParts.Length == 2)
                        {
                            Create(commandParts[1]);
                        }
                        break;
                    case "show":
                        if (commandParts.Length == 3)
                        {
                            Show(commandParts[1], commandParts[2]);
                        }
                        break;
                    case "update":
                        if (commandParts.Length == 3)
                        {
                            Update(commandParts[1], commandParts[2]);
                        }
                        break;
                    case "delete":
                        if (commandParts.Length == 3)
                        {
                            Delete(commandParts[1], commandParts[2]);
                        }
                        break;
                    case "exit":
                        storage.Save();
                        return;
                    default:
                        Console.WriteLine("Invalid command.");
                        PrintCommands();
                        break;
                }
            }
        }

        static void PrintCommands()
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("<ClassNames> show all ClassNames of objects");
            Console.WriteLine("<All> show all objects");
            Console.WriteLine("<All [ClassName]> show all objects of a ClassName");
            Console.WriteLine("<Create [ClassName]> a new object");
            Console.WriteLine("<Show [ClassName object_id]> an object");
            Console.WriteLine("<Update [ClassName object_id]> an object");
            Console.WriteLine("<Delete [ClassName object_id]> an object");
            Console.WriteLine("<Exit>");
        }

        static void PrintClassNames()
        {
            var classNames = new List<string> { "user", "item", "inventory" };
            Console.WriteLine(string.Join(", ", classNames));
        }

        static void PrintAll(string className = null)
        {
            var allObjects = storage.All();
            foreach (var obj in allObjects)
            {
                if (className == null || obj.Key.StartsWith(className + "."))
                {
                    Console.WriteLine($"{obj.Key}: {obj.Value}");
                }
            }
        }

        static void Create(string className)
        {
            switch (className.ToLower())
            {
                case "user":
                    Console.Write("Enter user name: ");
                    string userName = Console.ReadLine();
                    User user = new User(userName);
                    storage.New(user);
                    break;
                case "item":
                    Console.Write("Enter item name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter item price: ");
                    float itemPrice = float.Parse(Console.ReadLine());
                    Item item = new Item(itemName, itemPrice);
                    Console.Write("Enter item description: ");
                    item.Description = Console.ReadLine();
                    Console.Write("Enter item tags (comma separated): ");
                    string tags = Console.ReadLine();
                    item.Tags = new List<string>(tags.Split(','));
                    storage.New(item);
                    break;
                case "inventory":
                    Console.Write("Enter user ID: ");
                    string userId = Console.ReadLine();
                    Console.Write("Enter item ID: ");
                    string itemId = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Inventory inventory = new Inventory(userId, itemId, quantity);
                    storage.New(inventory);
                    break;
                default:
                    Console.WriteLine($"{className} is not a valid object type");
                    break;
            }
        }

        static void Show(string className, string id)
        {
            string key = $"{className.ToLower()}.{id}";
            if (storage.All().TryGetValue(key, out object obj))
            {
                Console.WriteLine(obj);
            }
            else
            {
                Console.WriteLine($"Object {id} could not be found");
            }
        }

        static void Update(string className, string id)
        {
            string key = $"{className.ToLower()}.{id}";
            if (!storage.All().TryGetValue(key, out object obj))
            {
                Console.WriteLine($"Object {id} could not be found");
                return;
            }

            switch (obj)
            {
                case User user:
                    Console.Write($"Enter new name (current: {user.Name}): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        user.Name = newName;
                    }
                    user.UpdateTimestamp();
                    break;
                case Item item:
                    Console.Write($"Enter new name (current: {item.Name}): ");
                    string newNameItem = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newNameItem))
                    {
                        item.Name = newNameItem;
                    }
                    Console.Write($"Enter new description (current: {item.Description}): ");
                    string newDescription = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDescription))
                    {
                        item.Description = newDescription;
                    }
                    Console.Write($"Enter new price (current: {item.Price}): ");
                    string newPriceStr = Console.ReadLine();
                    if (float.TryParse(newPriceStr, out float newPrice))
                    {
                        item.Price = newPrice;
                    }
                    Console.Write($"Enter new tags (current: {string.Join(", ", item.Tags)}): ");
                    string newTags = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTags))
                    {
                        item.Tags = new List<string>(newTags.Split(','));
                    }
                    item.UpdateTimestamp();
                    break;
                case Inventory inventory:
                    Console.Write($"Enter new user ID (current: {inventory.UserId}): ");
                    string newUserId = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newUserId))
                    {
                        inventory.UserId = newUserId;
                    }
                    Console.Write($"Enter new item ID (current: {inventory.ItemId}): ");
                    string newItemId = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newItemId))
                    {
                        inventory.ItemId = newItemId;
                    }
                    Console.Write($"Enter new quantity (current: {inventory.Quantity}): ");
                    string newQuantityStr = Console.ReadLine();
                    if (int.TryParse(newQuantityStr, out int newQuantity))
                    {
                        inventory.Quantity = newQuantity;
                    }
                    inventory.UpdateTimestamp();
                    break;
                default:
                    Console.WriteLine($"{className} is not a valid object type");
                    return;
            }

            storage.Save();
            Console.WriteLine($"Updated {className} {id}");
        }

        static void Delete(string className, string id)
        {
            string key = $"{className.ToLower()}.{id}";
            if (storage.All().Remove(key))
            {
                Console.WriteLine($"Deleted {className} {id}");
                storage.Save();
            }
            else
            {
                Console.WriteLine($"Object {id} could not be found");
            }
        }
    }
}
