using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LinkedListPlay
    {
        public void Play()
        {
            var linkedList = new MyLinkedList();
            linkedList.AddAtStart(new Node() { Value = 10 });
            linkedList.AddAtLast(new Node() { Value = 20 });
            linkedList.AddAtStart(new Node() { Value = 30 });
            linkedList.Remove(new Node() { Value = 20 });

            foreach (var item in linkedList)
            {
                Console.WriteLine(item.Value);
            }
        }
    }

    /// <summary>
    /// This is a simple Linked List implementation.
    /// NOTES:
    /// 1. Only the head and tail nodes.
    /// 2. Allows navigation between nodes. (using next etc)
    /// 3. Can made the list generic.
    /// 4. This is a singly linked list.
    /// </summary>
    class MyLinkedList : IEnumerable<Node>
    {
        private Node _headNode = null;
        private Node _tailNode = null;

        public int Count { get; private set; }

        /// <summary>
        /// Adds a node to the start of the Linked List.
        /// </summary>
        /// <remarks>
        /// This is an effient operation regardless of the number of
        /// items in the list. Therefore the execution is predictable.
        /// </remarks>
        /// <param name="node"></param>
        public void AddAtStart(Node node)
        {
            // Take a node of the head node
            Node headNode = _headNode;

            // Node that was passed in becomes the head node.
            _headNode = node;
            
            // New head node points to what was the original node.
            _headNode.Next = headNode;

            // Increase the size of the linked list by 1
            Count++;

            // When there is only 1 item in the list
            if (Count == 1)
            {
                _tailNode = _headNode;
            }
        }

        /// <summary>
        /// Add the new tail node.
        /// </summary>
        /// <remarks>
        /// This is also an efficient operation simply because we are
        /// setting the current tail node to point to the new node.
        /// </remarks>
        /// <param name="node"></param>
        public void AddAtLast(Node node)
        {
            // When there are no items in the list
            if (Count == 0)
            {
                _tailNode = node;

                _headNode = _tailNode;
            }
            else
            {
                // Set current tail to look for the new node.
                _tailNode.Next = node;

                // Set the Tail node to be the new node.
                _tailNode = node;
            }

            Count++;
        }
        /// <summary>
        /// Removes the current tail node.
        /// </summary>
        /// <remarks>
        /// This is an ineffient operation. As the number of nodes increase
        /// time it takes to complete the operation increases. Therefore
        /// performance degrade. This is because we only store references
        /// to the head and tail nodes.
        /// </remarks>
        public void RemoveLast()
        {
            if (Count == 1)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                var node = _headNode;

                // Starting from the head node
                // find just before the tail node
                while (node != _tailNode)
                {
                    node = node.Next;
                }

                // This will make node just before the
                // tail to be pointing to null, in effect
                // making it the tail node.
                node.Next = null;

                // Make the new node the tail
                _tailNode = node;

                // Reduce the counter to represent the removal.
                Count--;
            }
        }

        /// <summary>
        /// Removes the current head node.
        /// </summary>
        /// <remarks>
        /// This is a predicatable operation. We are only changing the current head node
        /// to point to what it used to point. Regardless of the number of nodes
        /// this operation has predictable execution time.
        /// </remarks>
        public void RemoveFirst()
        {
            // Performs this operation only when there are items.
            if (Count > 0)
            {
                var head = _headNode;

                // Make the head node point to what the "old"
                // head node used to point to. 
                _headNode = head.Next;
                
                // Decrease the counter to represent the removal.
                Count--;

                // When there are no more items 
                if (Count == 0)
                {
                    _tailNode = null;
                }
            }
        }

        /// <summary>
        /// Removes an item from the linked list.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Remove(Node node)
        {
            // When there is nothing in the Linked List.
            if (Count == 0)
            {
                return false;
            }

            Node current = _headNode;
            Node previous = null;

            while (current != null)
            {
                if (current.Value == node.Value)
                {
                    // The match is the head node. Then remove first
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        // This is the node that current is pointing to.
                        var currentNextPointer = current.Next;

                        previous.Next = currentNextPointer;

                        // When the next pointer is null, the tail
                        if (currentNextPointer == null)
                        {
                            _tailNode = previous;
                        }

                        Count--;
                    }

                    return true;
                }

                // Finished processing, then current becomes previous
                previous = current;
                
                // Next becomes what current is pointing to.
                current = current.Next;
            }

            // No matches found then stop.
            return false;

        }

        /// <summary>
        /// This method enumerates over the the list.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node> GetEnumerator()
        {
            var node = _headNode;

            while (node != null)
            {
                yield return node;

                node = node.Next;
            }
        }

        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
