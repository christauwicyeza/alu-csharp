using System;

namespace Enemies {
    /// <summary>
    /// Zombie is a public class 
    /// </summary>
    public class Zombie {

        // local health variable
        int health;

        /// <summary>
        /// Name sets and gets the local name variable
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        // local name variable
        string name = "(No name)";

        /// <summary>
        /// Zombie Constructor inits health to zero
        /// </summary>
        public Zombie() {
            health = 0;
        }

        /// <summary>
        /// Zombie Constructor inits only for int greater than or equal to zero
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Zombie(int value) {
            if (value < 0) {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }

            health = value;
        }

        /// <summary>
        /// ToString  prints Zombie details
        /// </summary>
        /// <returns> string </returns>
        public override string ToString() {
            return $"Zombie Name: {name} / Total Health: {health}";
        }

        /// <summary>
        /// Method returns health local variable
        /// </summary>
        /// <returns>health</returns>
        public int GetHealth() {
            return health;
        }

        // Entry point of the program
        public static void Main(string[] args) {
            // Main method, entry point of the program
            Console.WriteLine("Hello from the Main method!");
        }
    }
}
