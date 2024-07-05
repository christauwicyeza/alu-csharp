using System;
using System.Collections.Generic;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        static JSONStorage storage = new JSONStorage();

        static void Main(string[] args)
        {
            storage.Load();
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("-------------------------");
            PrintCommands();

            string? command;
            while (true)
            {
                Console.Write("> ");
                command = Console.ReadLine()?.Trim().ToLower();

                if (command == "exit")
                {
                    storage.Save();
                    break;
                }

                if (command != null)
                {
                    ProcessCommand(command);
                }
            }
        }

        static void PrintCommands()
        {
            Console.WriteLine("<ClassNames> show all ClassNames of objects");
            Console.WriteLine("<All> show all objects");
            Console.WriteLine("<All [ClassName]> show all objects of a ClassName");
            Console.WriteLine("<Create [ClassName]> a new object");
            Console.WriteLine("<Show [ClassName object_id]> an object");
            Console.WriteLine("<Update [ClassName object_id]> an object");
            Console.WriteLine("<Delete [ClassName object_id]> an object");
            Console.WriteLine("<Exit>");
        }

        static void ProcessCommand(string command)
        {
            string[] parts = command.Split(' ', 2);
            string action = parts[0];
            string? argument = parts.Length > 1 ? parts[1] : null;

            switch (action)
            {
                case "classnames":
                    PrintClassNames();
                    break;
                case "all":
                    PrintAll(argument);
                    break;
                case "create":
                    if (argument != null) CreateObject(argument);
                    else Console.WriteLine("Invalid command.");
                    break;
                case "show":
                    if (argument != null) ShowObject(argument);
                    else Console.WriteLine("Invalid command.");
                    break;
                case "update":
                    if (argument != null) UpdateObject(argument);
                    else Console.WriteLine("Invalid command.");
                    break;
                case "delete":
                    if (argument != null) DeleteObject(argument);
                    else Console.WriteLine("Invalid command.");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
            PrintCommands();
        }

        static void PrintClassNames()
        {
            Console.WriteLine("User");
            Console.WriteLine("Item");
            Console.WriteLine("Inventory");
        }

        static void PrintAll(string? className = null)
        {
            foreach (var obj in storage.All())
            {
                if (className == null || obj.Value.GetType().Name.ToLower() == className.ToLower())
                {
                    Console.WriteLine($"{obj.Key}: {obj.Value}");
                }
            }
        }

        static void CreateObject(string className)
        {
            switch (className.ToLower())
            {
                case "user":
                    Console.Write("Enter name: ");
                    string? userName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(userName))
                    {
                        User newUser = new User(userName);
                        storage.New(newUser);
                        Console.WriteLine("User created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("User creation failed: Name cannot be empty.");
                    }
                    break;
                case "item":
                    Console.Write("Enter name: ");
                    string? itemName = Console.ReadLine();
                    Console.Write("Enter price: ");
                    string? priceInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(itemName) && float.TryParse(priceInput, out float itemPrice))
                    {
                        Item newItem = new Item(itemName, itemPrice);
                        Console.Write("Enter description: ");
                        newItem.Description = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter tags (comma separated): ");
                        string? tags = Console.ReadLine();
                        if (!string.IsNullOrEmpty(tags))
                        {
                            newItem.Tags = new List<string>(tags.Split(','));
                        }
                        storage.New(newItem);
                        Console.WriteLine("Item created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Item creation failed: Invalid name or price.");
                    }
                    break;
                case "inventory":
                    Console.Write("Enter user ID: ");
                    string? userId = Console.ReadLine();
                    Console.Write("Enter item ID: ");
                    string? itemId = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    string? quantityInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(itemId) && int.TryParse(quantityInput, out int quantity))
                    {
                        Inventory newInventory = new Inventory(userId, itemId, quantity);
                        storage.New(newInventory);
                        Console.WriteLine("Inventory created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Inventory creation failed: Invalid user ID, item ID, or quantity.");
                    }
                    break;
                default:
                    Console.WriteLine($"{className} is not a valid object type");
                    break;
            }
        }

        static void ShowObject(string argument)
        {
            string[] parts = argument.Split(' ', 2);
            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid command.");
                return;
            }

            string className = parts[0];
            string objectId = parts[1];
            string key = $"{className}.{objectId}";

            if (storage.All().ContainsKey(key))
            {
                Console.WriteLine(storage.All()[key]);
            }
            else
            {
                Console.WriteLine($"Object {objectId} could not be found");
            }
        }

        static void UpdateObject(string argument)
        {
            string[] parts = argument.Split(' ', 2);
            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid command.");
                return;
            }

            string className = parts[0];
            string objectId = parts[1];
            string key = $"{className}.{objectId}";

            if (storage.All().ContainsKey(key))
            {
                BaseClass obj = storage.All()[key];
                Console.WriteLine("Enter new values (leave blank to keep current value):");
                foreach (var property in obj.GetType().GetProperties())
                {
                    Console.Write($"{property.Name} ({property.GetValue(obj)}): ");
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        if (property.PropertyType == typeof(int) && int.TryParse(input, out int intValue))
                            property.SetValue(obj, intValue);
                        else if (property.PropertyType == typeof(float) && float.TryParse(input, out float floatValue))
                            property.SetValue(obj, floatValue);
                        else if (property.PropertyType == typeof(string))
                            property.SetValue(obj, input);
                        else if (property.PropertyType == typeof(List<string>))
                            property.SetValue(obj, new List<string>(input.Split(',')));
                    }
                }
                obj.UpdateTimestamp();
                Console.WriteLine("Object updated successfully.");
            }
            else
            {
                Console.WriteLine($"Object {objectId} could not be found");
            }
        }

        static void DeleteObject(string argument)
        {
            string[] parts = argument.Split(' ', 2);
            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid command.");
                return;
            }

            string className = parts[0];
            string objectId = parts[1];
            string key = $"{className}.{objectId}";

            if (storage.All().ContainsKey(key))
            {
                storage.All().Remove(key);
                Console.WriteLine($"Object {objectId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Object {objectId} could not be found");
            }
        }
    }
}
