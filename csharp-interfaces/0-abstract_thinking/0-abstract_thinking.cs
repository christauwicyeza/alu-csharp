using System;



/// <summary>
/// base class for inheritance
/// </summary>
public abstract class Base{

/// <summary>
/// holds the name
/// </summary>
    public String? name;

/// <summary>
/// override to display custom properties
/// </summary>
/// <returns></returns>
    public override String ToString(){
        return $"{name} is a {this.GetType()}";
    }
}