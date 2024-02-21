using System;

class Obj{

    public static bool IsInstanceOfArray(object obj){
        if(obj is Array){
            return true;
        }
        
        return false;
    }

}