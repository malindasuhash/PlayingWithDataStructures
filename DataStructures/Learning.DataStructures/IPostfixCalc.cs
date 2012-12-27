using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This is the interface of the PostFix calculator.
    /// </summary>
    public interface IPostfixCalc
    {
        int Result(string input);
    }
}
