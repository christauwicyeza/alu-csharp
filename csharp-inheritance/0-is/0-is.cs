using System;


class Obj{

    public static bool IsOfTypeInt(Object obj){
        if(obj is int){
            return true;
        }

        return false;
    }
}