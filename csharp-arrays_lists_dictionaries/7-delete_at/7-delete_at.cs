using System.Collections;

class List{

    public static List<int> DeleteAt(List<int> myList, int index){
        int ListSize = myList.Count;
        List<int> CacheList = new List<int>();

        if(index >= 0 && index < ListSize){
            for(int i = 0; i < ListSize; i++){
                if(i == index){
               
               continue;
                }else{
                       // Console.WriteLine("Adding the number : " + myList[i]);
                        CacheList.Add(myList[i]);
                }
            
            }
    

            return CacheList;
        }else{
            Console.WriteLine("Index is out of range");
            return myList;
        }

    }
}