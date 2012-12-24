using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Stack:
    /// 1. Last In First Out (LIFO) structure.
    /// 2. Items are push on to the stack.
    /// 3. As new items are added, one that is at the customers disposal becomes the top item.
    /// 4. As new items are added, the depth of the stack increases.
    /// 5. We can peek at the items on the stack, this will only allow access to the top item.
    /// 6. The top item is poped, when it is removed.
    /// 7. At some point the stack will become empty. At this point no more popping.
    /// </summary>
    class StackPlay
    {
    }


    /// <summary>
    /// This class implements a stack using an array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack2<T> : IEnumerable<T>
    {
        private T[] _arrayForStack = new T[0];

        /// <summary>
        /// Provides the number of elements in the stack.
        /// </summary>
        public int Count { get { return _size; } }

        private int _size;

        /// <summary>
        /// Adds an item to the top of the array.
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            if (_arrayForStack.Length == _size)
            {
                var newLength = _size == 0 ? 4 : _size * 2;

                var newArray = new T[newLength];
                _arrayForStack.CopyTo(newArray, 0);

                _arrayForStack = newArray;
            }

            _arrayForStack[_size] = value;
            _size++;
        }

        /// <summary>
        /// Pops the top item from the array and sets to default.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Sorry no items to pop.");
            }

            var itemToReturn = _arrayForStack[_size];
            _arrayForStack[_size] = default(T);
            _size--;

            return itemToReturn;
        }

        /// <summary>
        /// Returns the top value but will not remove from stack.
        /// </summary>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Sorry stack is empty.");
            }

            var topValue = _arrayForStack[_size];

            return topValue;
        }

        /// <summary>
        /// We need to return from the top (which means from the back of the array).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _arrayForStack[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    /// <summary>
    /// This is a basic implementation of a stack
    /// using build in linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _linkedList = new LinkedList<T>();

        /// <summary>
        /// Returns the number of elements in the list.
        /// </summary>
        public int Count 
        {
            get
            {
                return _linkedList.Count;
            }
        }

        /// <summary>
        /// Add an items to the stack and makes it the top item.
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            _linkedList.AddFirst(value);
        }

        /// <summary>
        /// Removes the top item from the list.
        /// Then returns the value.
        /// </summary>
        public T Pop()
        {
            if (_linkedList.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty, nothing to pop.");
            }

            var firstElement = _linkedList.First.Value;
            _linkedList.RemoveFirst();

            return firstElement;
        }

        /// <summary>
        /// Return the top value but will not remove from the list.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_linkedList.Count == 0)
            {
                throw new InvalidOperationException("Nothing to peek.");
            }

            return _linkedList.First.Value;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
