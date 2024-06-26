using System;

namespace CustomQueue
{
    public class Queue<T>
    {
        public Type CheckType()
        {
            return typeof(T);
        }
    }
}
