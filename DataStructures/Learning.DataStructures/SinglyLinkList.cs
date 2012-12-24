using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This is the concrete implementation of Singly linked list.
    /// </summary>
    public class SinglyLinkList<T> : ISinglyLinkedList<T>, IEnumerable<T>
    {
        private SinglyLinkListNode<T> _head = null;

        private SinglyLinkListNode<T> _tail = null;


        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// The node being added becomes the Head node.
        /// </summary>
        public void AddFirst(SinglyLinkListNode<T> node)
        {
            // This is the first item being added.
            if (Count == 0)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                // When there are items in the list 
                // make the new node the head node.
                var currentHeadNode = _head;

                _head = node;
                _head.Next = currentHeadNode;
            }

            Count++;
        }

        /// <summary>
        /// Removed the node that is currently the head node.
        /// </summary>
        public void RemoveFirst()
        {
            // No items in the list.
            if (Count == 0)
            {
                return;
            }

            // Head and Tail points to same item.
            // Removing this resets the list.
            if (Count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                var headNext = _head.Next;

                _head = headNext;
            }

            Count--;
        }

        /// <summary>
        /// Adds the item to the end of the linked list.
        /// </summary>
        /// <param name="node"></param>
        public void AddLast(SinglyLinkListNode<T> node)
        {
            // First item being added.
            if (Count == 0)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                var currentTail = _tail;
                _tail = node;

                currentTail.Next = _tail;
            }

            Count++;
        }

        /// <summary>
        /// Removes tail element.
        /// </summary>
        public void RemoveLast()
        {
            // Nothing to remove.
            if (Count == 0)
            {
                return;
            }

            // Head and tail points to the same node.
            if (Count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                SinglyLinkListNode<T> previous = null;
                SinglyLinkListNode<T> current = _head;

                while (current.Next != null)
                {
                    previous = current;
                    current = current.Next;
                }

                previous.Next = null;
                _tail = previous;
            }

            Count--;
        }

        public bool Remove(T value)
        {
            if (Count == 0)
            {
                return false;
            }

            SinglyLinkListNode<T> current = _head;
            SinglyLinkListNode<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    // Only a single item in the list.
                    if (Count == 1)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        var nextPointer = current.Next;
                        previous.Next = nextPointer;
                        Count--;
                    }

                    return true;
                }
          
                previous = current;
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;

            while (node != null)
            {
                yield return node.Value;

                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// This method is purely for testing purpose to find out the status of the head and tail elements.
        /// </summary>
        /// <returns></returns>
        internal Tuple<SinglyLinkListNode<T>, SinglyLinkListNode<T>> GetHeadAndTail()
        {
            return new Tuple<SinglyLinkListNode<T>, SinglyLinkListNode<T>>(_head, _tail);
        }
    }
}
