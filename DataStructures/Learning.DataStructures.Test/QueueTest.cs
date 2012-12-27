using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures.Test
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void Enqueue_WhenThereAreNoItems_NewItemShouldBeTheFirst()
        {
            // Arrange
            var q = new Queue<int>();

            // Act
            q.Enqueue(10);

            // Assert
            Assert.AreEqual(1, q.Count, "Should only be a single item in the queue.");
            Assert.AreEqual(10, q.GetBackingStore()[0], "First element should be the given value.");
            Assert.AreEqual(0, q.GetHeadAndTail().Item1, "Head node should be 0.");
            Assert.AreEqual(0, q.GetHeadAndTail().Item2, "Tail node should be 0.");
        }

        [TestMethod]
        public void Enqueue_WhenSecondItemAdded_SecondItemShouldBeTheTail()
        {
            // Arrange
            var q = new Queue<int>();
            q.Enqueue(10);
           
            // Act
            q.Enqueue(20);

            // Assert
            Assert.AreEqual(2, q.Count, "Number of items in the queue.");
            Assert.AreEqual(10, q.GetBackingStore()[0], "Frist element should be 10.");
            Assert.AreEqual(20, q.GetBackingStore()[1], "Second element should be 20.");
            Assert.AreEqual(0, q.GetHeadAndTail().Item1, "Position of head should not change.");
            Assert.AreEqual(1, q.GetHeadAndTail().Item2, "Position of tail should be the new element.");
        }

        [TestMethod]
        public void Enqueue_WhenNumberOfElementsBecomeMoreThan4_BackingStoreShouldIncreaseInSize()
        {
            // Arrange
            var q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);

            // Act
            q.Enqueue(5);

            // Assert
            Assert.AreEqual(5, q.Count, "Length shall be 5");
            Assert.AreEqual(8, q.GetBackingStore().Length, "Backing store should have doubled the size.");
            Assert.AreEqual(1, q.GetBackingStore()[0], "1 should be at position 0");
            Assert.AreEqual(2, q.GetBackingStore()[1], "2 should be at position 1");
            Assert.AreEqual(3, q.GetBackingStore()[2], "3 should be at position 2");
            Assert.AreEqual(4, q.GetBackingStore()[3], "4 should be at position 3");
            Assert.AreEqual(5, q.GetBackingStore()[4], "5 should be at position 4");
            Assert.AreEqual(0, q.GetHeadAndTail().Item1, "Head should still be 0.");
            Assert.AreEqual(4, q.GetHeadAndTail().Item2, "Tail should be at 4.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_WhenThereAreNoItems_ShouldThrowException()
        {
            // Arrange
            var q = new Queue<int>();

            // Act, Assert
            q.Dequeue();
        }

        [TestMethod]
        public void Dequeue_WhenThereIsSingleItemInQueue_ShouldReturnIt()
        {
            // Arrange
            var q = new Queue<int>();
            q.Enqueue(10);

            // Assert
            var result = q.Dequeue();

            // Assert
            Assert.AreEqual(10, result, "Should be 10.");
            Assert.AreEqual(1, q.GetHeadAndTail().Item1, "Head should be 0.");
            Assert.AreEqual(0, q.GetHeadAndTail().Item2, "Tail should be 0.");
        }

        [TestMethod]
        public void Dequeue_ShouldReturnFirstInItem_AndUpdateHeadIndex()
        {
            // Arrange
            var q = new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(20);

            // Act
            var result = q.Dequeue();

            // Assert
            Assert.AreEqual(10, result, "Should return the first element.");
            Assert.AreEqual(1, q.GetHeadAndTail().Item1, "Head element index should update");
            Assert.AreEqual(1, q.GetHeadAndTail().Item2, "Tail element index should not change.");
            Assert.AreEqual(0, q.GetBackingStore()[0], "Old head element should be empty (zero)");
            Assert.AreEqual(1, q.Count, "Queue length should be 1.");
        }

        [TestMethod]
        public void Enqueue_WhenAnItemIsDequeued_EnqueingShouldAddItAtStart()
        {
            // Arrange
            var q = new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);

            q.Dequeue();

            // Act
            q.Enqueue(40);

            // Assert
            Assert.AreEqual(3, q.Count, "3 items should be in the queue.");
            Assert.AreEqual(1, q.GetHeadAndTail().Item1, "Head node should be pointing to the second slot.");
            Assert.AreEqual(3, q.GetHeadAndTail().Item2, "Tail should be pointing to the index 3.");
            Assert.AreEqual(0, q.GetBackingStore()[0], "Should contain new value.");
            Assert.AreEqual(20, q.GetBackingStore()[1], "Should contain the 20 at index 1.");
            Assert.AreEqual(30, q.GetBackingStore()[2], "Should contain 30 at index 2.");
            Assert.AreEqual(40, q.GetBackingStore()[3], "Should contain 30 at index 2.");
        }

        [TestMethod]
        public void Peek_ShouldReturnTheHeadItem_ShouldNotRemoveFromQueue()
        {
            // Arrange
            var q = new Queue<int>();
            q.Enqueue(20);
            q.Enqueue(30);
            q.Dequeue();

            // Act
            var result = q.Peek();

            // Assert
            Assert.AreEqual(30, result, "Should return expected value 30.");
            Assert.AreEqual(0, q.GetBackingStore()[0], "Index 0 should be empty.");
            Assert.AreEqual(30, q.GetBackingStore()[1], "Index 1 should have 30.");
        }
    }
}
