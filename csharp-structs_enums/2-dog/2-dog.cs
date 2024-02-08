using System;

public enum Rating{
    Good,
    Great, 
    Excellent,
}


public struct Dog {

    public Dog(string name, float age, string owner, Rating rating){
        this.name = name;
        this.age = age;
        this.owner = owner;
        this.rating = rating;
    }
    public string name;
    public float age;
    public string owner;
    public Rating rating;
}