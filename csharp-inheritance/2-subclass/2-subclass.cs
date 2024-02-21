using System;

class Obj{
    /// <summary>
    /// Veries relationship btw based and derived types. 
    /// </summary>
    /// <param name="derivedType"></param>
    /// <param name="baseType"></param>
    /// <returns></returns>
    public static bool IsOnlyASubclass(Type derivedType, Type baseType){
        if(derivedType.IsSubclassOf(baseType)){
            return true;
        }else{
            return false;
        }
    }

}