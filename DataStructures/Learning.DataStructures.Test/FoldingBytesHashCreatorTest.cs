using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures.Test
{
    [TestClass]
    public class FoldingBytesHashCreatorTest
    {
        [TestMethod]
        public void CreateHash_WhenItemIsGiven_ShouldCreateExpectedHash()
        {
            // Arrange
            var c = new FoldingBytesHashCreator<string>();

            // Act
            var result = c.CreateHash("Hello");

            // Assert
            Assert.AreEqual(1819043255, result, "Should match expected hash value.");
        }
    }
}
