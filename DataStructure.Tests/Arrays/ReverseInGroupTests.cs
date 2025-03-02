using DataStructurePractice.Arrays.Problems;

namespace DataStructure.Tests.Arrays
{
    [TestFixture]
    internal class ReverseInGroupTests
    {

        private ReverseArrayInGroups arrayUtils;

        [SetUp]
        public void Setup()
        {
            arrayUtils = new ReverseArrayInGroups();
        }

        [Test]
        public void ReverseInGroups_WhenKIsThree_ShouldReverseCorrectly()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int k = 3;

            // Act
            int[] result = arrayUtils.ReverseInGroups(input, k);

            // Assert
            int[] expected = { 3, 2, 1, 6, 5, 4, 8, 7 };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseInGroups_WhenKIsTwo_ShouldReversePairs()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4, 5 };
            int k = 2;

            // Act
            int[] result = arrayUtils.ReverseInGroups(input, k);

            // Assert
            int[] expected = { 2, 1, 4, 3, 5 };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseInGroups_WhenKIsGreaterThanArrayLength_ShouldReverseEntireArray()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4 };
            int k = 6;

            // Act
            int[] result = arrayUtils.ReverseInGroups(input, k);

            // Assert
            int[] expected = { 4, 3, 2, 1 };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseInGroups_WhenKIsOne_ShouldReturnSameArray()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4, 5 };
            int k = 1;

            // Act
            int[] result = arrayUtils.ReverseInGroups(input, k);

            // Assert
            int[] expected = { 1, 2, 3, 4, 5 }; // No changes
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseInGroups_WhenArrayIsEmpty_ShouldReturnEmptyArray()
        {
            // Arrange
            int[] input = { };
            int k = 3;

            // Act
            int[] result = arrayUtils.ReverseInGroups(input, k);

            // Assert
            Assert.AreEqual(new int[] { }, result);
        }
    }

}
