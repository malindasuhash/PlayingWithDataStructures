using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This is a basic stack implementation using the custom <see cref="ISinglyLinkedList"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T> : IStack<T>
    {
        private readonly SinglyLinkList<T> _linkedList = new SinglyLinkList<T>();

        public void Push(T value)
        {
            _linkedList.AddFirst(new SinglyLinkListNode<T>(value));
        }

        public T Pop()
        {
            ThrowIfNoItems();

            var value = _linkedList.ElementAt(0);
            _linkedList.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            ThrowIfNoItems();

            var value = _linkedList.ElementAt(0);

            return value;
        }


        public int Count
        {
            get { return _linkedList.Count; }
        }

        /// <summary>
        /// This method is purely for testing the structure of the stack.
        /// </summary>
        /// <returns></returns>
        internal SinglyLinkList<T> GetBackingList()
        {
            return _linkedList;
        }

        private void ThrowIfNoItems()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("There are no items in the stack.");
            }
        }
    }
}
