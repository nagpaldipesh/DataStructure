using DataStructurePractice.Stack;
using Shouldly;

namespace DataStructure.Tests.Stack
{
    [TestFixture]
    public class MinStackTests
    {
        private MinStack minStack;

        [SetUp]
        public void Setup()
        {
            minStack = new MinStack();
        }

        [Test]
        public void Push_ShouldStoreElementsCorrectly()
        {
            minStack.Push(5);
            minStack.Push(3);
            minStack.Push(8);

            minStack.Peek().ShouldBe(8);
        }

        [Test]
        public void GetMinimum_ShouldReturnMinimumValue()
        {
            minStack.Push(5);
            minStack.Push(3);
            minStack.Push(8);

            minStack.GetMinimum().ShouldBe(3);
        }

        [Test]
        public void Pop_ShouldRemoveElementsCorrectly()
        {
            minStack.Push(5);
            minStack.Push(3);
            minStack.Push(8);

            minStack.Pop().ShouldBe(8);  // Last-in-first-out (LIFO)
            minStack.Peek().ShouldBe(3);
        }

        [Test]
        public void Pop_ShouldUpdateMinimum_WhenMinElementIsRemoved()
        {
            minStack.Push(5);
            minStack.Push(3);
            minStack.Push(8);
            minStack.Push(2);

            minStack.GetMinimum().ShouldBe(2);

            minStack.Pop(); // Removes 2

            minStack.GetMinimum().ShouldBe(3);
        }

        [Test]
        public void Peek_ShouldReturnLastElement()
        {
            minStack.Push(10);
            minStack.Push(20);

            minStack.Peek().ShouldBe(20);
        }

        [Test]
        public void GetMinimum_ShouldThrowException_WhenStackIsEmpty()
        {
            Should.Throw<InvalidOperationException>(() => minStack.GetMinimum());
        }

        [Test]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            Should.Throw<InvalidOperationException>(() => minStack.Pop());
        }

        [Test]
        public void Peek_ShouldThrowException_WhenStackIsEmpty()
        {
            Should.Throw<InvalidOperationException>(() => minStack.Peek());
        }
    }
}
