using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructures.Test
{
    [TestClass]
    public class PostfixCalcTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Result_WhenThereIsNoInput_ShouldThrowException()
        {
            // Arrange
            var post = new PostfixCalc();

            // Act, Assert
            post.Result(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Result_WhenTheFirstInputValueIsNotInteger_ShouldThrowException()
        {
            // Arrange
            var post = new PostfixCalc();

            // Act, Assert
            post.Result(",1,4+");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Result_WhenUnsupportedOperatorProvided_ShouldThrowException()
        {
            // Arrange
            var post = new PostfixCalc();

            // Act, Assert
            post.Result("4,2,^");
        }

        [TestMethod]
        public void Result_ShouldCalculate_ExpectedOutput()
        {
            // Arrange
            var post = new PostfixCalc();

            // Act
            var output = post.Result("3,5,+");

            // Assert
            Assert.AreEqual(8, output, "Should be 8.");
        }
    }
}
