using System.Collections;

class List{
    public static int SafePrint(List<int> myList, int n){
        int count = 0;

        try{
    
            for(int i = 0; i < n ; i++){
                Console.WriteLine(myList[i]);
                count++;
            }
        }catch(System.Exception){
            return count;
        }

        return count;
    }
}