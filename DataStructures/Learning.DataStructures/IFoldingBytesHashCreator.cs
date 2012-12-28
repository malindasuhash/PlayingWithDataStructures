using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This is the interface of the Folding byte 
    /// hash value creator.
    /// </summary>
    public interface IFoldingBytesHashCreator<T>
    {
        int CreateHash(T valueToHash);
    }
}
