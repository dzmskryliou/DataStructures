using System;

namespace Tasks
{
    public interface IHybridFlowProcessor<T>
    {
        void Enqueue(T item); 
        T Dequeue(); 
        void Push(T item);
        T Pop();        
        bool IsEmpty(); 
        int Count { get; }               
    }
}
