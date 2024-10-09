using static System.Net.Mime.MediaTypeNames;

namespace Tasks
{
    public class DoublyLinkedListBase
    {
        public class Node<T>
        {
            private T _data;
            public T Data 
            { 
                get { return _data; }
                set { _data = value; }
            }
            private Node<T> _next;
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }
    }
}