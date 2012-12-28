using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures
{
    /// <summary>
    /// This class creates a hash based on the folding bytes
    /// algorithm.
    /// </summary>
    public class FoldingBytesHashCreator<T> : IFoldingBytesHashCreator<T>
    {
        private const int IntBitSize = 32;

        public int CreateHash(T valueToHash)
        {
            int hash = Calculator(valueToHash.ToString());

            return hash;
        }

        private int Calculator(string value)
        {
            var totalBytes = Encoding.ASCII.GetBytes(value);

            var indexer = 0;
            var appender = new int[4];
            var hashSumValue = 0;

            for (int i = 0; i < totalBytes.Length; i++)
            {
                if (indexer > 3)
                {
                    // To prevent an int overflow exception.
                    unchecked
                    {
                        hashSumValue += BitShiftAndAdd(appender);
                    }

                    // Resets buffer rather than creating a new instance.
                    for (int j = 0; j < appender.Length; j++)
                    {
                        appender[j] = 0;
                    }

                    indexer = 0;
                }

                appender[indexer] = totalBytes[i];
                indexer++;
            }

            if (indexer != 0)
            {
                unchecked
                {
                    hashSumValue += BitShiftAndAdd(appender);
                }
            }

            return hashSumValue;
        }

        private int BitShiftAndAdd(int[] values)
        {
            int hashSumValue = 0;

            unchecked
            {
                hashSumValue += (values[0] << 0) + (values[1] << 8) + (values[2] << 16) + (values[3] << 24);
            }

            return hashSumValue;
        }
    }
}
