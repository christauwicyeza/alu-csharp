using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Add_TwoPositiveIntegers_ReturnsCorrectSum()
        {
            // Arrange
            int a = 2;
            int b = 3;
            int expected = 5;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected), "The sum of two positive integers should be correct.");
        }

        [Test]
        public void Add_NegativeAndPositiveInteger_ReturnsCorrectSum()
        {
            // Arrange
            int a = -2;
            int b = 3;
            int expected = 1;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected), "The sum of a negative and a positive integer should be correct.");
        }

        [Test]
        public void Add_TwoNegativeIntegers_ReturnsCorrectSum()
        {
            // Arrange
            int a = -2;
            int b = -3;
            int expected = -5;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected), "The sum of two negative integers should be correct.");
        }
    }
}