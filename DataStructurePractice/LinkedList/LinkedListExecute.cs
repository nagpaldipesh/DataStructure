using Shouldly;

namespace DataStructurePractice.LinkedList
{
    public class LinkedListExecute
    {
        public static void Execute()
        {
            //LinkedList_Operations_Should_Work_Correctly();
            //InsertAt_Should_Insert_Correctly();
            //RemoveAt_Should_Remove_Correctly();
            //RemoveAll_Should_Clear_List();
            //DoublyLinkedList_Insert_Should_Work_Correctly();
            //DoublyLinkedList_Insert_Delete_Should_Work_Correctly();

            LinkedList_Should_Detect_Cycle();
            LinkedList_Should_Not_Detect_Cycle();
            LinkedList_Should_Handle_Empty_List();
            LinkedList_Should_Handle_Single_Node();
            LinkedList_Should_Handle_Two_Node_Cycle();

            LinkedList_Should_Detect_Cycle();
            LinkedList_Should_Not_Detect_Cycle_When_List_Is_NullTerminated();
            LinkedList_Should_Detect_Cycle_At_Correct_Node();
            LinkedList_Should_Handle_Single_Node_Cycle();
            LinkedList_Should_Handle_Empty_List_Cyclic();
            LinkedList_Should_Detect_Cycle2();

            Insert_Should_Handle_Large_Numbers_Correctly();
            Insert_Should_Add_First_Element_To_Empty_List();
            Insert_Should_Add_Elements_In_Sorted_Order();
            Insert_Should_Handle_Duplicate_Values_Correctly();
            Insert_Should_Correctly_Handle_Single_Element_List();
            Insert_Should_Correctly_Handle_Inserting_At_End();
            Insert_Should_Correctly_Handle_Inserting_At_Beginning();
        }
        static void Insert_Should_Add_First_Element_To_Empty_List()
        {
            // Arrange
            SortedLinkedList sortedList = new SortedLinkedList();

            // Act
            sortedList.Insert(10);

            // Assert
            sortedList.Length.ShouldBe(1);
            sortedList.Head.ShouldNotBeNull();
            sortedList.Head.Data.ShouldBe(10);
        }

        static void Insert_Should_Add_Elements_In_Sorted_Order()
        {
            // Arrange
            SortedLinkedList sortedList = new SortedLinkedList();

            // Act
            sortedList.Insert(20);
            sortedList.Insert(10);
            sortedList.Insert(30);
            sortedList.Insert(25);
            sortedList.Insert(5);

            // Assert
            sortedList.Length.ShouldBe(5);
            sortedList.Head.Data.ShouldBe(5);
            sortedList.Head.Next.Data.ShouldBe(10);
            sortedList.Head.Next.Next.Data.ShouldBe(20);
            sortedList.Head.Next.Next.Next.Data.ShouldBe(25);
            sortedList.Head.Next.Next.Next.Next.Data.ShouldBe(30);
        }

        static void Insert_Should_Handle_Duplicate_Values_Correctly()
        {
            // Arrange
            SortedLinkedList sortedList = new SortedLinkedList();

            // Act
            sortedList.Insert(15);
            sortedList.Insert(10);
            sortedList.Insert(15);
            sortedList.Insert(20);

            // Assert
            sortedList.Length.ShouldBe(4);
            sortedList.Head.Data.ShouldBe(10);
            sortedList.Head.Next.Data.ShouldBe(15);
            sortedList.Head.Next.Next.Data.ShouldBe(15);
            sortedList.Head.Next.Next.Next.Data.ShouldBe(20);
        }

        static void Insert_Should_Correctly_Handle_Single_Element_List()
        {
            // Arrange
            SortedLinkedList sortedList = new SortedLinkedList();
            sortedList.Insert(50);

            // Act
            sortedList.Insert(30);

            // Assert
            sortedList.Length.ShouldBe(2);
            sortedList.Head.Data.ShouldBe(30);
            sortedList.Head.Next.Data.ShouldBe(50);
        }

        static void Insert_Should_Correctly_Handle_Inserting_At_End()
        {
            // Arrange
            SortedLinkedList sortedList = new SortedLinkedList();
            sortedList.Insert(10);
            sortedList.Insert(20);

            // Act
            sortedList.Insert(30);

            // Assert
            sortedList.Length.ShouldBe(3);
            sortedList.Head.Next.Next.Data.ShouldBe(30);
            sortedList.Head.Next.Next.Next.ShouldBeNull();
        }

        static void Insert_Should_Correctly_Handle_Inserting_At_Beginning()
        {
            // Arrange
            SortedLinkedList sortedList = new SortedLinkedList();
            sortedList.Insert(20);
            sortedList.Insert(30);

            // Act
            sortedList.Insert(10);

            // Assert
            sortedList.Length.ShouldBe(3);
            sortedList.Head.Data.ShouldBe(10);
            sortedList.Head.Next.Data.ShouldBe(20);
        }

        static void Insert_Should_Handle_Large_Numbers_Correctly()
        {
            // Arrange
            SortedLinkedList sortedList = new SortedLinkedList();

            // Act
            sortedList.Insert(100000);
            sortedList.Insert(500000);
            sortedList.Insert(300000);

            // Assert
            sortedList.Length.ShouldBe(3);
            sortedList.Head.Data.ShouldBe(100000);
            sortedList.Head.Next.Data.ShouldBe(300000);
            sortedList.Head.Next.Next.Data.ShouldBe(500000);
        }

        static void DoublyLinkedList_Insert_Should_Work_Correctly()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.Insert(10);
            list.Insert(20);
            list.Insert(30);

            list.InsertAt(15, 1);
            list.InsertAt(5, 0);  // Insert at head
            list.InsertAt(40, 5); // Insert at tail

            list.FindAt(0).ShouldBe(5);
            list.FindAt(1).ShouldBe(10);
            list.FindAt(2).ShouldBe(15);
            list.FindAt(3).ShouldBe(20);
            list.FindAt(4).ShouldBe(30);
            list.FindAt(5).ShouldBe(40);
        }

        static void DoublyLinkedList_Insert_Delete_Should_Work_Correctly()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.Insert(10);
            list.Insert(20);
            list.Insert(30);
            list.Insert(40);
            list.Insert(50);

            list.RemoveFromBeginning().ShouldBe(10);
            list.RemoveFromEnd().ShouldBe(50);
            list.RemoveAt(1).ShouldBe(30);

            list.FindAt(0).ShouldBe(20);
            list.FindAt(1).ShouldBe(40);
        }

        static void LinkedList_Operations_Should_Work_Correctly()
        {
            LinkedList linkedList = new LinkedList();

            // Insert and check length
            linkedList.Insert(1);
            linkedList.Length.ShouldBe(1);

            // Remove element and check length
            linkedList.Remove().ShouldBe(1);
            linkedList.Length.ShouldBe(0);

            // Insert multiple elements and check length
            linkedList.Insert(2);
            linkedList.Insert(3);
            linkedList.Insert(4);
            linkedList.Length.ShouldBe(3);

            // Peek last element
            linkedList.Peek().ShouldBe(4);

            // Insert one more element
            linkedList.Insert(5);

            // Remove last inserted element
            linkedList.Remove().ShouldBe(5);

            // Validate count and length
            linkedList.Count().ShouldBe(3);
            linkedList.Length.ShouldBe(3);

            // FindAt method validation
            linkedList.FindAt(-1).ShouldBe(-1);
            linkedList.FindAt(0).ShouldBe(2);
            linkedList.FindAt(1).ShouldBe(3);
        }

        static void InsertAt_Should_Insert_Correctly()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Insert(1);
            linkedList.Insert(3);
            linkedList.InsertAt(2, 1);

            linkedList.FindAt(0).ShouldBe(1);
            linkedList.FindAt(1).ShouldBe(2);
            linkedList.FindAt(2).ShouldBe(3);
            linkedList.Length.ShouldBe(3);
        }

        static void RemoveAt_Should_Remove_Correctly()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);

            linkedList.RemoveAt(1).ShouldBe(2);
            linkedList.Length.ShouldBe(2);

            linkedList.FindAt(0).ShouldBe(1);
            linkedList.FindAt(1).ShouldBe(3);
        }

        static void RemoveAll_Should_Clear_List()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);

            linkedList.RemoveAll();
            linkedList.Length.ShouldBe(0);
            Should.Throw<InvalidOperationException>(() => linkedList.Peek());
        }

        static void LinkedList_Should_Detect_Cycle()
        {
            LinkedList list = new LinkedList();
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            list.Insert(5);

            // Create a cycle: Point last node to second node
            list.CreateCycle(1);

            list.IsCyclic().ShouldBe(true);
        }

        static void LinkedList_Should_Not_Detect_Cycle()
        {
            LinkedList list = new LinkedList();
            list.Insert(10);
            list.Insert(20);
            list.Insert(30);

            list.IsCyclic().ShouldBe(false);
        }

        static void LinkedList_Should_Handle_Empty_List()
        {
            LinkedList list = new LinkedList();
            list.IsCyclic().ShouldBe(false);
        }

        static void LinkedList_Should_Handle_Single_Node()
        {
            LinkedList list = new LinkedList();
            list.Insert(100);

            list.IsCyclic().ShouldBe(false);

            // Create a cycle (point to itself)
            list.CreateCycle(0);
            list.IsCyclic().ShouldBe(true);
        }

        static void LinkedList_Should_Handle_Two_Node_Cycle()
        {
            LinkedList list = new LinkedList();
            list.Insert(1);
            list.Insert(2);

            // Create a cycle: Last node points to the first node
            list.CreateCycle(0);

            list.IsCyclic().ShouldBe(true);
        }

        static void LinkedList_Should_Detect_Cycle2()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            list.Insert(5);

            // Create a cycle: Point last node to second node
            list.CreateCycle(1);

            // Act & Assert
            list.IsCyclic().ShouldBe(true);
        }

        static void LinkedList_Should_Not_Detect_Cycle_When_List_Is_NullTerminated()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            list.Insert(5);

            // Act & Assert
            list.IsCyclic().ShouldBe(false);
        }

        static void LinkedList_Should_Detect_Cycle_At_Correct_Node()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);
            list.Insert(5);

            // Create a cycle: Point last node to third node (index 2)
            list.CreateCycle(2);

            // Act
            var cycleNode = list.DetectCyclc();

            // Assert
            cycleNode.ShouldNotBeNull();
            cycleNode.Data.ShouldBe(3);
        }

        static void LinkedList_Should_Handle_Empty_List_Cyclic()
        {
            // Arrange
            LinkedList list = new LinkedList();

            // Act & Assert
            list.IsCyclic().ShouldBe(false);
            list.DetectCyclc().ShouldBeNull();
        }

        static void LinkedList_Should_Handle_Single_Node_Cycle()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(1);
            list.CreateCycle(0); // Point node to itself

            // Act & Assert
            list.IsCyclic().ShouldBe(true);
            list.DetectCyclc().Data.ShouldBe(1);
        }
    }
}
