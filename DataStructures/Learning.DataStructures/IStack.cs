using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This interface provides the basic interface of a stack.
    /// </summary>
    public interface IStack<T>
    {
        void Push(T value);

        T Pop();

        T Peek();

        int Count { get; }
    }
}
