using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> storage;

        public HybridFlowProcessor()
        {
            storage = new DoublyLinkedList<T>();
        }

        public void Enqueue(T item)
        {
            storage.Add(item);
        }

        public T Dequeue()
        {
            CheckIfEmpty();
            return storage.RemoveAt(0);
        }
        public void Push(T item)
        {
            storage.Add(item);
        }

        public T Pop()
        {
            CheckIfEmpty();
            return storage.RemoveAt(storage.Length - 1);
        }

        public bool IsEmpty()
        {
            return storage.Length == 0;
        }

        public int Count
        {
            get { return storage.Length; }
        }

        private void CheckIfEmpty()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Storage is empty");
            }
        }
    }
}
