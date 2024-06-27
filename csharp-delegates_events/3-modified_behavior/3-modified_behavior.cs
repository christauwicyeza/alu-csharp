using System;

/// <summary>
/// enum modifier
/// </summary>
public enum Modifier {
    /// <summary>
    /// weak value
    /// </summary>
    Weak,

    /// <summary>
    /// base value
    /// </summary>
    Base,

    /// <summary>
    /// strong value
    /// </summary>
    Strong
}
/// <summary>
/// calculatemodifier delegate
/// </summary>
/// <param name="baseValue"></param>
/// <param name="modifier"></param>
/// <returns></returns>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

/// <summary>
/// player class
/// </summary>
public class Player {

   
    private string name = "Player";

    private float maxHp = 100f;


    private float hp;

   /// <summary>
   /// calculatehealth delegate
   /// </summary>
   /// <param name="amount"></param>
    delegate void CalculateHealth(float amount);

    /// <summary>
    /// player method
    /// </summary>
    /// <param name="name"></param>
    /// <param name="maxHp"></param>
    public Player(string name = "Player", float maxHp = 100f){

        if(maxHp <= 0){
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }else{
               this.maxHp = maxHp;
        }

        this.name = name;
        hp = this.maxHp;
    }

 


/// <summary>
/// take damage method
/// </summary>
/// <param name="damage"></param>
    public void TakeDamage(float damage){
        
        if(damage < 0){
            Console.WriteLine($"{name} takes 0 damage!");
        }else{
            hp -= damage;
            Console.WriteLine($"{name} takes {damage} damage!");
        }
        ValidateHP(hp);
    }

    /// <summary>
    /// heldamage method
    /// </summary>
    /// <param name="heal"></param>
    public void HealDamage(float heal){
        
        if(heal < 0){
            Console.WriteLine($"{name} heals 0 HP!");
        }else{
            hp += heal;
            Console.WriteLine($"{name} heals {Math.Round(heal,1)} HP!");
        }
        ValidateHP(hp);
    }

/// <summary>
/// validatehp method
/// </summary>
/// <param name="newHp"></param>
    public void ValidateHP(float newHp){
        if(newHp < 0 ){
            hp  = 0;
        }else if(newHp > maxHp){
            hp = maxHp;
        }else{
            hp = newHp;
        }
    }

    /// <summary>
    /// applymodifier method
    /// </summary>
    /// <param name="baseValue"></param>
    /// <param name="modifier"></param>
    /// <returns></returns>

    public float ApplyModifier(float baseValue, Modifier modifier){

        if(modifier == Modifier.Weak){
            return baseValue/2;
        } 
        
        if(modifier == Modifier.Base){
            return baseValue;
        }
        
        if(modifier == Modifier.Strong){
            return baseValue * 1.5f;
        }

        return default(float);
    }

    /// <summary>
    /// printhealth mthod
    /// </summary>
    public void PrintHealth(){
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

}