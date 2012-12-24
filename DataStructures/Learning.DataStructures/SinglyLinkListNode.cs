using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This class represents a node in the Singly linked list.
    /// </summary>
    public class SinglyLinkListNode<T>
    {
        public SinglyLinkListNode(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public SinglyLinkListNode<T> Next { get; set; }
    }
}
