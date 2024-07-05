using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    /// <summary>
    /// Handles storage of inventory objects in a JSON file.
    /// </summary>
    public class JSONStorage
    {
        /// <summary>
        /// Dictionary to store objects with keys as <ClassName>.<id> and values as the objects.
        /// </summary>
        public Dictionary<string, BaseClass> Objects { get; private set; }

        private string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONStorage"/> class.
        /// </summary>
        public JSONStorage()
        {
            Objects = new Dictionary<string, BaseClass>();
            _filePath = Path.Combine("storage", "inventory_manager.json");

            // Ensure the storage directory exists
            Directory.CreateDirectory("storage");

            // Load existing data if the file exists
            Load();
        }

        /// <summary>
        /// Returns the objects dictionary.
        /// </summary>
        public Dictionary<string, BaseClass> All()
        {
            return Objects;
        }

        /// <summary>
        /// Adds a new object to the storage.
        /// </summary>
        /// <param name="obj">The object to be added.</param>
        public void New(BaseClass obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "The object cannot be null.");
            }

            string key = $"{obj.GetType().Name}.{obj.Id}";
            Objects[key] = obj;
        }

        /// <summary>
        /// Serializes the objects to JSON and saves to the JSON file.
        /// </summary>
        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Objects, options);
            File.WriteAllText(_filePath, jsonString);
        }

        /// <summary>
        /// Deserializes the JSON file to objects.
        /// </summary>
        public void Load()
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                Objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(jsonString) ?? new Dictionary<string, BaseClass>();
            }
        }
    }
}
