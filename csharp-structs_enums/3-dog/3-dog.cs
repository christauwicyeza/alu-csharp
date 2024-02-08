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

    public override string ToString(){

        return $"Dog Name: {name}\nAge: {age}\nOwner: {owner}\nRating: {rating}";
    }
    public string name;
    public float age;
    public string owner;
    public Rating rating;
}