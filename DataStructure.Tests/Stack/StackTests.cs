using DataStructurePractice.LinkedList;
using Shouldly;

namespace DataStructure.Tests.Stack
{
    public class StackTests
    {
        [Test]
        public void Push_ShouldIncreaseCount()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();

            // Act
            stack.Push(10);
            stack.Push(20);

            // Assert
            stack.Count.ShouldBe(2);
        }

        [Test]
        public void Pop_ShouldReturnLastPushedElement()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();
            stack.Push(10);
            stack.Push(20);

            // Act
            int popped = stack.Pop();

            // Assert
            popped.ShouldBe(20);
            stack.Count.ShouldBe(1);
        }

        [Test]
        public void Pop_EmptyStack_ShouldThrowException()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_ShouldReturnTopElementWithoutRemovingIt()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();
            stack.Push(10);
            stack.Push(20);

            // Act
            int topElement = stack.Peek();

            // Assert

            topElement.ShouldBe(20);
            stack.Count.ShouldBe(2);
        }

        [Test]
        public void Peek_EmptyStack_ShouldThrowException()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Clear_ShouldReset()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();
            stack.Push(10);
            stack.Push(20);

            // Act
            stack.Clear();

            // Assert
            stack.Count.ShouldBe(0);
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void IsCyclic_ShouldReturnFalseForNonCyclic()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Act
            bool isCyclic = stack.IsCyclic();

            // Assert
            Assert.False(isCyclic);
        }

        [Test]
        public void IsCyclic_ShouldDetectCycle()
        {
            // Arrange
            var stack = new DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Manually create a cycle (For testing purposes only)
            var fieldInfo = typeof(DataStructurePractice.Stack.StackImplementationUsingLinkedList.Stack).GetField("top", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Node topNode = (Node)fieldInfo.GetValue(stack);
            topNode.Next.Next.Next = topNode; // Creating cycle

            // Act
            bool isCyclic = stack.IsCyclic();

            // Assert
            Assert.True(isCyclic);
        }
    }
}
