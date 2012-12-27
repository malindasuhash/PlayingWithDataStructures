using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This class is the concrete (simple) implementation of Postfix calculator.
    /// </summary>
    public class PostfixCalc : IPostfixCalc
    {
        private const string Plus = "+";
        private const string Minus = "-";

        private readonly Stack<int> _stack = new Stack<int>();

        /// <summary>
        /// Accepts a Postfix string and returns the result.
        /// </summary>
        /// <example>
        /// Input 1,3,+ will return 4
        /// </example>
        public int Result(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be empty.");
            }

            var elements = input.Split(new char[] { ',' });

            ThowIfStartIsNotInteger(elements[0]);

            foreach (var element in elements)
            {
                var result = Validate(element);

                switch (result.Item1)
                {
                    case ElementType.Operand:
                        var validatedInt = (ElementResult<int>)result.Item2;
                        _stack.Push(validatedInt.Result);
                        continue;

                    case ElementType.Operator:
                        var rhs = _stack.Pop();
                        var lhs = _stack.Pop();
                        _stack.Push(Calculate(lhs, rhs, ((ElementResult<string>)result.Item2).Result));
                        continue;

                    default:
                        throw new InvalidOperationException("Not supported.");
                }
            }

            return _stack.Pop();
        }

        private int Calculate(int lhs, int rhs, string op)
        {
            switch (op)
            {
                case Plus:
                    return lhs + rhs;

                case Minus:
                    return lhs - rhs;

                default:
                    throw new InvalidOperationException("Operand not supported.");
            }
        }

        private Tuple<ElementType, IElementResult> Validate(string element)
        {
            int intval;

            var result = int.TryParse(element, out intval);

            if (result)
            {
                return new Tuple<ElementType, IElementResult>(ElementType.Operand, new ElementResult<int>(intval));
            }

            var operators = element.Equals(Plus) || element.Equals(Minus);

            if (operators)
            {
                return new Tuple<ElementType, IElementResult>(ElementType.Operator, new ElementResult<string>(element));
            }

            throw new FormatException("Operator or operand not supported");
        }

        private void ThowIfStartIsNotInteger(string element)
        {
            int intval;

            var result = int.TryParse(element, out intval);

            if (!result)
            {
                throw new FormatException("Should start with an integer.");
            }
        }

        /// <summary>
        /// The types of items in the input string.
        /// </summary>
        private enum ElementType
        {
            NotSpecified = 0,

            Operand,

            Operator
        }

        /// <summary>
        /// This class specify the validated result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class ElementResult<T> : IElementResult
        {
            public ElementResult(T element)
            {
                Result = element;
            }

            public T Result { get; private set; }
        }

        /// <summary>
        /// This interface is a marker interface for 
        /// generalising the storage of validated result.
        /// </summary>
        private interface IElementResult
        {
        }
    }
}
