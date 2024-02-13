using System;


namespace Enemies{
   
    /// <summary>
    /// Zombie is a public class 
    /// </summary>
    public class Zombie{

        // local health variable
        int health;


        /// <summary>
        /// Zombie Constructor inits health to zero
        /// </summary>
        public Zombie(){
            health = 0;
        }


        /// <summary>
        /// Zoombie Constructor inits only for int greater than or equal to zero
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Zombie(int value){
            if( value < 0){
                throw new ArgumentException("Health must be greater than or equal to 0");
            }

            health = value;
        }

        /// <summary>
        /// Method returns health local variable
        /// </summary>
        /// <returns>health</returns>
        public int GetHealth(){
            return health;
        }



    }
}