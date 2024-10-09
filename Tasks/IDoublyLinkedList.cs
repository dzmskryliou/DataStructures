using System.Collections.Generic;

public interface IDoublyLinkedList<T> : IEnumerable<T>
{
    void Add(T e);            
    void AddAt(int index, T e); 
    T ElementAt(int index);
    void Remove(T item);
    T RemoveAt(int index);
    int Length { get; }
}