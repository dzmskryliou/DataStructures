using System;
using System.Collections;
using System.Collections.Generic;
using static Tasks.DoublyLinkedListBase;

namespace Tasks
{

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int Length
        {

            get { return count; }
        }

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
            }
            tail = newNode;
            count++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

            Node<T> newNode = new Node<T>(e);
            newNode.Next = head;

            if (index == 0)
            {
                if (head == null)
                {
                    tail = newNode;

                }
                else
                {
                    head.Previous = newNode;
                }
                head = newNode;
                count++;
            }
            else if (index == count)
            {
                Add(e);
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current;
                newNode.Previous = current.Previous;

                if (current.Previous != null)
                {
                    current.Previous.Next = newNode;
                }

                current.Previous = newNode;
                count++;
            }
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }


        public void Remove(T item)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    RemoveNode(current);
                    return; 
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            T data = current.Data;
            RemoveNode(current);

            return data;
        }

        private void RemoveNode(Node<T> node)
        {
            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            else
            {
                head = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            else
            {
                tail = node.Previous;
            }

            count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void IDoublyLinkedList<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        private class DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private readonly DoublyLinkedList<T> list;
            private Node<T> currentNode;
            private bool firstMove;

            public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
            {
                this.list = list;
                this.currentNode = null;
                this.firstMove = true;
            }

            public T Current
            {
                get
                {
                    if (currentNode == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return currentNode.Data;
                }
            }

            object IEnumerator.Current => Current;
            public bool MoveNext()
            {
                if (firstMove) 
                {
                    currentNode = list.head;
                    firstMove = false;
                }
                else
                {
                    currentNode = currentNode?.Next;
                }

                return currentNode != null;
            }

            public void Reset()
            {
                currentNode = null;
                firstMove = true;
            }

            public void Dispose()
            {

            }
        }
    }
}