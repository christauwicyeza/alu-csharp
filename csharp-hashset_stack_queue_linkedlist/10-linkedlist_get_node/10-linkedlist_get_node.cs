using System.Collections.Generic;

class LList{
    public static int GetNode(LinkedList<int> myLList, int n){
        int index = 0;
        foreach(int content in myLList){
            if(index == n){
                return content;
            }
            index++;
        }

        return 0;
    }
}