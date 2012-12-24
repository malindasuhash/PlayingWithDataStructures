using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This is the interface of the Singly linked list.
    /// </summary>
    public interface ISinglyLinkedList<T>
    {
        int Count { get; }

        void AddFirst(SinglyLinkListNode<T> node);

        void RemoveFirst();
    }
}
