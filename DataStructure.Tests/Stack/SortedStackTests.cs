using DataStructurePractice.Stack;
using Shouldly;

namespace DataStructure.Tests.Stack
{
    [TestFixture]
    public class SortedStackTests
    {
        [Test]
        public void Push_ShouldMaintainSortedOrder()
        {
            var stack = new SortedStack();
            stack.Push(5);
            stack.Push(1);
            stack.Push(3);
            stack.Push(2);

            stack.Pop().ShouldBe(1);
            stack.Pop().ShouldBe(2);
            stack.Pop().ShouldBe(3);
            stack.Pop().ShouldBe(5);
        }

        [Test]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            var stack = new SortedStack();
            Should.Throw<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_ShouldReturnTopElementWithoutRemovingIt()
        {
            var stack = new SortedStack();
            stack.Push(4);
            stack.Peek().ShouldBe(4);

            stack.Push(2);

            stack.Peek().ShouldBe(2);
            stack.Pop().ShouldBe(2);
            stack.Peek().ShouldBe(4);
        }

        [Test]
        public void IsEmpty_ShouldReturnTrue_WhenStackIsEmpty()
        {
            var stack = new SortedStack();
            stack.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void IsEmpty_ShouldReturnFalse_WhenStackHasElements()
        {
            var stack = new SortedStack();
            stack.Push(10);
            stack.IsEmpty().ShouldBeFalse();
        }
    }
}
