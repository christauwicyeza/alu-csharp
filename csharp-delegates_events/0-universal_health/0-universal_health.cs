using System;

/// <summary>
/// class player
/// </summary>
public class Player {

    private string name;
    private float maxHp;
    private float hp;

/// <summary>
/// player method
/// </summary>
/// <param name="name"></param>
/// <param name="maxHp"></param>
    public Player(string name = "Player", float maxHp = 100f) {

        if (maxHp <= 0) {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }else {
            this.maxHp = maxHp;
        }

        this.name = name;
        hp = this.maxHp;
    }

/// <summary>
/// printhealth method
/// </summary>
        public void PrintHealth() {
            Console.WriteLine($"{name} has {hp} / {maxHp} health");

        }
    }
