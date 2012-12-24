using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures.Test
{
    [TestClass]
    public class SinglyLinkedListTest
    {
        [TestMethod]
        public void SinglyLinkedList_WhenInstanceCreated_CountShouldBeZero()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();

            // Act
            var count = linkedList.Count;

            // Assert
            Assert.AreEqual(0, count, "There should not be any items in the list");
            Assert.AreEqual(0, linkedList.Count(), "Should not enumerate any items.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Head should be null");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Tail should be null");
        }

        [TestMethod]
        public void AddFirst_WhenNoItemsInTheList_ShouldBeTheOnlyElement()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();
            var node = new SinglyLinkListNode<int>(10);

            // Act
            linkedList.AddFirst(node);

            // Assert
            Assert.AreEqual(1, linkedList.Count, "There should be only 1 item.");
            Assert.AreEqual(1, linkedList.Count(), "Enumeration should return single item.");
            Assert.AreEqual(10, linkedList.First(), "The first item that it returns shall we the expected item.");
            Assert.IsNotNull(linkedList.GetHeadAndTail().Item1, "Should not be null");
            Assert.AreSame(node, linkedList.GetHeadAndTail().Item1, "Head should be referring to the same item.");
            Assert.AreSame(node, linkedList.GetHeadAndTail().Item2, "Tail should be referring to the same item.");
        }

        [TestMethod]
        public void AddFirst_SecondItem_ShouldNowBecomeTheHeadNode()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();

            linkedList.AddFirst(new SinglyLinkListNode<int>(10));

            // Act
            linkedList.AddFirst(new SinglyLinkListNode<int>(20));

            // Assert 20 -> 10 -> null
            Assert.AreEqual(2, linkedList.Count, "Should contain two items.");
            Assert.AreEqual(20, linkedList.GetHeadAndTail().Item1.Value, "Head should contain the the expected value.");
            Assert.AreEqual(10, linkedList.GetHeadAndTail().Item2.Value, "Tail should contain the expected value.");
            Assert.AreEqual(linkedList.GetHeadAndTail().Item1.Next, linkedList.GetHeadAndTail().Item2, "Head.Next should be pointing to the tail.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2.Next, "Tail should not point to null.");
            Assert.AreEqual(20, linkedList.ElementAt(0), "Enumeration should return the expected value.");
            Assert.AreEqual(10, linkedList.ElementAt(1), "Enumberation should return the expected value.");
        }

        [TestMethod]
        public void RemoveFirst_WhenNoItemsInList_ListShouldRemainTheSame()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();

            // Assert
            Assert.AreEqual(0, linkedList.Count, "There shall be no items");
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Head should be null");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Tail should be null");

            // Act
            linkedList.RemoveFirst();

            // Assert
            Assert.AreEqual(0, linkedList.Count, "There shall be no items.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Head should be null");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Tail should be null");
        }

        [TestMethod]
        public void RemoveFirst_WhenThereAreItems_ShouldResetTheHeadNode()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();
            linkedList.AddFirst(new SinglyLinkListNode<int>(10));
            linkedList.AddFirst(new SinglyLinkListNode<int>(20));
            linkedList.AddFirst(new SinglyLinkListNode<int>(30));

            // Act
            linkedList.RemoveFirst();

            // Assert
            Assert.AreEqual(20, linkedList.GetHeadAndTail().Item1.Value, "Should return the expected head value.");
            Assert.AreEqual(10, linkedList.GetHeadAndTail().Item2.Value, "Tail should have the expected value.");
            Assert.AreEqual(2, linkedList.Count, "Number of items shall match.");
        }

        [TestMethod]
        public void RemoveFirst_WhenThereAreOnlySingleItem_RemovingThisShouldSetListToEmpty()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();

            // Act
            linkedList.AddFirst(new SinglyLinkListNode<int>(10));
            
            // Assert
            Assert.AreEqual(1, linkedList.Count, "Should only contain 1 element.");
            Assert.AreSame(linkedList.GetHeadAndTail().Item1, linkedList.GetHeadAndTail().Item2, "Head and tail should be pointing to same element.");

            // Act
            linkedList.RemoveFirst();

            // Assert
            Assert.AreEqual(0, linkedList.Count, "List should be empty.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Head should be empty.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Tail should be empty.");
        }

        [TestMethod]
        public void AddLast_ItemShallBeAdded_ToTheEndOfList()
        {
            // Arrange
            var linkedList = new SinglyLinkList<decimal>();

            var lastItem = new SinglyLinkListNode<decimal>(10.0m);

            // Act
            linkedList.AddLast(lastItem);

            // Assert
            Assert.AreEqual(1, linkedList.Count, "There should be 1 item.");
            Assert.AreEqual(lastItem, linkedList.GetHeadAndTail().Item1, "Head should point to the same item.");
            Assert.AreEqual(lastItem, linkedList.GetHeadAndTail().Item2, "Tail should point to the same item.");
        }

        [TestMethod]
        public void AddLast_WhenThereAreMoreElements_ShouldAddToTheLastPosition()
        {
            // Arrange
            var linkedList = new SinglyLinkList<decimal>();

            linkedList.AddFirst(new SinglyLinkListNode<decimal>(2.0m));
            linkedList.AddFirst(new SinglyLinkListNode<decimal>(3.4m));
            
            // Act
            linkedList.AddLast(new SinglyLinkListNode<decimal>(5.5m));

            // Assert
            Assert.AreEqual(5.5m, linkedList.GetHeadAndTail().Item2.Value, "Should contain expected value.");
            Assert.AreEqual(3.4m, linkedList.ElementAt(0), "Should be the expected value.");
            Assert.AreEqual(2.0m, linkedList.ElementAt(1), "Should be the expected value.");
            Assert.AreEqual(5.5m, linkedList.ElementAt(2), "Should be the expected value.");
        }

        [TestMethod]
        public void AddLast_WhenThereAreOnlySingleItemInTheListAddingNew_ShouldBeTheLast()
        {
            // Arrange
            var linkedList = new SinglyLinkList<short>();
            linkedList.AddFirst(new SinglyLinkListNode<short>(1));
            
            // Act
            linkedList.AddLast(new SinglyLinkListNode<short>(3));

            // Assert
            Assert.AreEqual(1, linkedList.GetHeadAndTail().Item1.Value, "Should contain the expected value.");
            Assert.AreEqual(3, linkedList.GetHeadAndTail().Item2.Value, "Should contain the expected value.");
            Assert.AreEqual(linkedList.GetHeadAndTail().Item1.Next, linkedList.GetHeadAndTail().Item2, "Head should point to tail.");
        }

        [TestMethod]
        public void RemoveLast_WhenNoItemsInList_NothingShouldChange()
        {
            // Arrange
            var linkedList = new SinglyLinkList<decimal>();

            // Act
            linkedList.RemoveLast();
            
            // Assert
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Should be null.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Should be null.");
            Assert.AreEqual(0, linkedList.Count, "There should not be any item.");
        }

        [TestMethod]
        public void RemoveLast_WhenThereIsASingleItem_RemovingItShouldSetCounter()
        {
            // Arrange
            var linkedList = new SinglyLinkList<string>();

            linkedList.AddFirst(new SinglyLinkListNode<string>("hello"));

            // Act
            linkedList.RemoveLast();

            // Assert
            Assert.AreEqual(0, linkedList.Count, "There should not be any item.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Should be null.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Should be null.");
        }

        [TestMethod]
        public void RemoveLast_WhenThereAreItemsMultipleItems_ShoudlRemoveLast()
        {
            // Arrange
            var linkedList = new SinglyLinkList<string>();

            linkedList.AddFirst(new SinglyLinkListNode<string>("Hello"));
            linkedList.AddLast(new SinglyLinkListNode<string>("There"));
            linkedList.AddLast(new SinglyLinkListNode<string>("SomeMore"));

            // Act
            linkedList.RemoveLast();

            // Assert
            Assert.AreEqual("Hello", linkedList.GetHeadAndTail().Item1.Value, "Should contain the expected value.");
            Assert.AreEqual("There", linkedList.GetHeadAndTail().Item2.Value, "Should contain the expected value.");
            Assert.AreEqual(linkedList.GetHeadAndTail().Item1.Next, linkedList.GetHeadAndTail().Item2, "Pointer should be correct.");
            Assert.AreEqual(2, linkedList.Count, "Should contain the expected number of items.");
        }

        [TestMethod]
        public void Remove_WhenThereAreNoItemsInTheList_ShouldNotChange()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();
            
            // Act
            var status = linkedList.Remove(10);

            // Assert
            Assert.AreEqual(0, linkedList.Count, "Should not have any items");
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Should be null.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Should be null.");
            Assert.IsFalse(status, "Nothing to remove, therefore should return false.");
        }

        [TestMethod]
        public void Remove_WhenIsOnlySingleItem_RemovingItShouldResetHeadAndTail()
        {
            // Arrange
            var linkedList = new SinglyLinkList<string>();
            linkedList.AddLast(new SinglyLinkListNode<string>("Hello"));
            
            // Act
            linkedList.Remove("Hello");

            // Assert
            Assert.IsNull(linkedList.GetHeadAndTail().Item1, "Should be null.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2, "Should be null.");
            Assert.AreEqual(0, linkedList.Count, "Should not have any value.");
        }

        [TestMethod]
        public void Remove_OnlyItemInList_DoesNotMatchShouldReturnFalse()
        {
            // Arrange
            var linkedList = new SinglyLinkList<decimal>();
            linkedList.AddFirst(new SinglyLinkListNode<decimal>(20m));

            // Act
            var status =  linkedList.Remove(30);

            // Assert
            Assert.IsFalse(status, "Should not match.");
            Assert.AreEqual(1, linkedList.Count, "Should only be single item.");
        }

        [TestMethod]
        public void Remove_WhenThereAreMultipleItems_ItemInTheMiddleCanBeRemoved()
        {
            // Arrange
            var linkedList = new SinglyLinkList<int>();
            linkedList.AddFirst(new SinglyLinkListNode<int>(20));
            linkedList.AddFirst(new SinglyLinkListNode<int>(30));
            linkedList.AddFirst(new SinglyLinkListNode<int>(40));

            // Act
            linkedList.Remove(30);

            // Assert
            Assert.AreEqual(2, linkedList.Count, "There should only be 2 items.");
            Assert.AreEqual(40, linkedList.GetHeadAndTail().Item1.Value, "Should match the expected value.");
            Assert.AreEqual(20, linkedList.GetHeadAndTail().Item2.Value, "Should match the expected value.");
            Assert.AreEqual(linkedList.GetHeadAndTail().Item1.Next, linkedList.GetHeadAndTail().Item2, "Should be pointing to appropriate item.");
            Assert.IsNull(linkedList.GetHeadAndTail().Item2.Next, "Should be null.");

        }
    }
}
