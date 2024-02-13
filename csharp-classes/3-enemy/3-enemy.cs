using System;

namespace Enemies {
    /// <summary>
    /// Zombie is a public class 
    /// </summary>
    public class Zombie {

        /// <summary>
        /// Holds the value of health
        /// </summary>
        public int health;

        /// <summary>
        /// Zombie Constructor inits health to zero
        /// </summary>
        public Zombie() {
            health = 0;
        }

        /// <summary>
        /// Zombie Constructor inits only for int greater than or equal to zero
        /// </summary>
        /// <param name="value">The initial health value</param>
        /// <exception cref="ArgumentException">Thrown when the provided value is less than 0</exception>
        public Zombie(int value) {
            if (value < 0) {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }

            health = value;
        }
    }

    public class Program {
        static void Main(string[] args) {
            // Main method, entry point of the program
            Console.WriteLine("Hello from the Main method!");
        }
    }
}
