using System;
using InventoryLibrary;

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
        }
    }
}
