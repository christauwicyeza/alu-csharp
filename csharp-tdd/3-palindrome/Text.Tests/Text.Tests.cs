using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void IsPalindrome_WithPalindrome_ReturnsTrue()
        {
            string input = "Racecar";
            bool result = Str.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_WithNonPalindrome_ReturnsFalse()
        {
            string input = "Hello";
            bool result = Str.IsPalindrome(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPalindrome_WithSpacesAndPunctuation_ReturnsTrue()
        {
            string input = "A man, a plan, a canal: Panama.";
            bool result = Str.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_WithEmptyString_ReturnsTrue()
        {
            string input = "";
            bool result = Str.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_WithOnlySpaces_ReturnsTrue()
        {
            string input = "     ";
            bool result = Str.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_WithMixedCase_ReturnsTrue()
        {
            string input = "MadamImAdam";
            bool result = Str.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_WithOnlyPunctuation_ReturnsTrue()
        {
            string input = ",.!;";
            bool result = Str.IsPalindrome(input);
            Assert.IsTrue(result);
        }
    }
}