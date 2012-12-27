using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This is the interface of a simple queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T>
    {
        void Enqueue(T value);

        T Dequeue();

        T Peek();

        int Count { get; }
    }
}
