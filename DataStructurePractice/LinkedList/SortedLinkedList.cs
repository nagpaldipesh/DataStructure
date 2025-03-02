
namespace DataStructurePractice.LinkedList
{
    public class SortedLinkedList
    {
        private LinkedList linkedList;

        public Node Head
        {
            get
            {
                return linkedList.Head;
            }
        }

        public int Length { get { return linkedList.Length; } }

        public SortedLinkedList()
        {
            linkedList = new LinkedList();
        }

        public void Insert(int data)
        {
            if (Length == 0)
            {
                linkedList.Insert(data);
                return;
            }

            int index = FindIndexToAdd(data);

            linkedList.InsertAt(data, index);
        }

        private int FindIndexToAdd(int data)
        {
            int index = 0;

            Node node = Head;

            while (node != null && node.Data < data)
            {
                index++;
                node = node.Next;
            }

            return index;
        }
    }
}
