using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures.Test
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void Push_ItemShouldBeAdded_ToTheStack()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Push(10);

            // Assert
            Assert.AreEqual(1, stack.Count, "There should be a single item in the list.");
            Assert.AreEqual(10, stack.GetBackingList().GetHeadAndTail().Item1.Value, "Head should be 10.");
        }

        [TestMethod]
        public void Push_LastPushedItem_ShouldBeTheTop()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Assert
            Assert.AreEqual(3, stack.Count, "Should have 3 items in the stack.");
            Assert.AreEqual(30, stack.GetBackingList().ElementAt(0), "First element.");
            Assert.AreEqual(20, stack.GetBackingList().ElementAt(1), "Second element.");
            Assert.AreEqual(10, stack.GetBackingList().ElementAt(2), "Third element.");
        }

        [TestMethod]
        public void Pop_WhenPoped_ShouldReturnTopElement()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(30);

            // Act
            var result = stack.Pop();

            // Assert
            Assert.AreEqual(1, stack.Count, "There should be only single item.");
            Assert.AreEqual(30, result, "Should return the top value.");
            Assert.AreEqual(10, stack.GetBackingList().GetHeadAndTail().Item1.Value, "Head should point to 10");
        }

        [TestMethod]
        public void Peek_ShouldReturnTopItem_ButShallNotRemoveFromList()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(30);
            stack.Push(40);
            
            // Assert
            Assert.AreEqual(2, stack.Count, "There should be 2 items.");

            // Act
            var result = stack.Peek();

            // Assert
            Assert.AreEqual(2, stack.Count, "There should be 2 items.");
            Assert.AreEqual(40, result, "Should return expected value.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_IfThereAreNoItems_ShouldThrowException()
        {
            // Arrange
            var stack = new Stack<decimal>();

            // Assert
            Assert.AreEqual(0, stack.Count, "There shall be no items");

            // Act
            stack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_IfThereAreNoItems_ShouldThrowException()
        {
            // Arrange
            var stack = new Stack<decimal>();

            // Assert
            Assert.AreEqual(0, stack.Count, "There shall be no items");

            // Act
            stack.Pop();
        }
    }
}
