using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This is a simple implementation of a Queue using
    /// an array as a backing store.
    /// </summary>
    public class Queue<T> : IQueue<T>
    {
        private const int Increment = 4;

        private int _headIndex = 0;
        private int _tailIndex = -1;
        private int _size = 0;

        private T[] _items = new T[0];

        public void Enqueue(T value)
        {
            // 1 - At the start _size and length is zero
            // 2 - When max of array size is reached size becomes
            // equal to the length.
            if (_size == _items.Length)
            {
                var newLength = _items.Length == 0 ? Increment : Increment * 2;

                var newArray = new T[newLength];

                int startIndex = 0;

                if (_size > 0)
                {
                    // Copy  
                    if (_tailIndex < _headIndex)
                    {
                        // Head to end of the array
                        for (int i = _headIndex; i <= _items.Length; i++)
                        {
                            newArray[startIndex] = _items[i];
                            startIndex++;
                        }

                        // 0 to tail
                        for (int i = 0; i < _tailIndex; i++)
                        {
                            newArray[startIndex] = _items[i];
                            startIndex++;
                        }
                    }
                    else
                    {
                        for (int i = _headIndex; i <= _tailIndex; i++)
                        {
                            newArray[startIndex] = _items[i];
                            startIndex++;
                        }
                    }

                    _headIndex = 0;
                    _tailIndex = startIndex - 1;
                }
                else
                {
                    _headIndex = 0;
                    _tailIndex = -1;
                }

                _items = newArray;
            }

            if (_tailIndex == _items.Length - 1)
            {
                _tailIndex = 0;
            }
            else
            {
                _tailIndex++;
            }

            _items[_tailIndex] = value;

            _size++;
        }

        public T Dequeue()
        {
            ThrowIfQueueEmpty();

            // Gets the item at head index.
            var valueToReturn = _items[_headIndex];
            _items[_headIndex] = default(T);

            if (_headIndex == _items.Length - 1)
            {
                _headIndex = 0;
            }
            else
            {
                _headIndex++;
            }

            _size--;

            return valueToReturn;
        }

        public T Peek()
        {
            ThrowIfQueueEmpty();

            var value = _items[_headIndex];

            return value;
        }

        public int Count
        {
            get { return _size; }
        }

        private void ThrowIfQueueEmpty()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("No items in the Queue.");
            }
        }

        /// <summary>
        /// This method is purely to read the contents of the 
        /// backing store.
        /// </summary>
        /// <returns></returns>
        internal T[] GetBackingStore()
        {
            return _items;
        }

        internal Tuple<int, int> GetHeadAndTail()
        {
            return new Tuple<int, int>(_headIndex, _tailIndex);
        }
    }
}
