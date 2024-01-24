using System;
using System.Collections.Generic;

public class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        Console.WriteLine("Number of items: " + aStack.Count);

        if (aStack.Count > 0)
        {
            Console.WriteLine("Top item: " + aStack.Peek());
        }
        else
        {
            Console.WriteLine("Stack is empty");
        }

        bool containsSearch = aStack.Contains(search);
        Console.WriteLine("Stack contains \"" + search + "\": " + containsSearch);

        if (containsSearch)
        {
            string item;
            do
            {
                item = aStack.Pop();
            }
            while (item != search && aStack.Count > 0);
        }

        aStack.Push(newItem);

        return aStack;
    }
}
