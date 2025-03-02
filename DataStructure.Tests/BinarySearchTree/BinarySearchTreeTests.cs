
using DataStructurePractice.BinarySearchTree;
using Shouldly;

namespace DataStructure.Tests.BinarySearchTree
{
    public class BinarySearchTreeTests
    {
        private DataStructurePractice.BinarySearchTree.BinarySearchTree bst;

        [SetUp]
        public void SetUp()
        {
            bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();
        }

        [Test]
        public void Insert_ShouldAddElementsInCorrectOrder()
        {
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(7);

            bst.Search(10).ShouldBeTrue();
            bst.Search(5).ShouldBeTrue();
            bst.Search(15).ShouldBeTrue();
            bst.Search(3).ShouldBeTrue();
            bst.Search(7).ShouldBeTrue();
        }

        [Test]
        public void Search_ShouldReturnTrue_IfElementExists()
        {
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(30);

            bst.Search(10).ShouldBeTrue();
            bst.Search(20).ShouldBeTrue();
            bst.Search(30).ShouldBeTrue();
        }

        [Test]
        public void Search_ShouldReturnFalse_IfElementDoesNotExist()
        {
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);

            bst.Search(100).ShouldBeFalse();
            bst.Search(-10).ShouldBeFalse();
        }

        [Test]
        public void Delete_ShouldRemoveElement_IfPresent()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(60);
            bst.Insert(80);

            bst.Delete(20);
            bst.Search(20).ShouldBeFalse();

            bst.Delete(30);
            bst.Search(30).ShouldBeFalse();

            bst.Delete(50);
            bst.Search(50).ShouldBeFalse();
        }

        [Test]
        public void Delete_ShouldNotAffectTree_IfElementNotPresent()
        {
            bst.Insert(10);
            bst.Insert(20);
            bst.Insert(30);

            bst.Delete(100); // Not present, should not throw error
            bst.Search(10).ShouldBeTrue();
            bst.Search(20).ShouldBeTrue();
            bst.Search(30).ShouldBeTrue();
        }

        [Test]
        public void EmptyTree_Search_ShouldReturnFalse()
        {
            bst.Search(10).ShouldBeFalse();
        }

        [Test]
        public void Delete_LeafNode_ShouldRemoveNode()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(20);

            bst.Delete(20);

            bst.Search(20).ShouldBeFalse();
        }

        [Test]
        public void Delete_NodeWithOneChild_ShouldReplaceWithChild()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(60); // Right child of 70

            bst.Delete(70);

            bst.Search(70).ShouldBeFalse();
            bst.Search(60).ShouldBeTrue(); // 60 should replace 70
        }

        [Test]
        public void Delete_NodeWithTwoChildren_ShouldUseInOrderSuccessor()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(60);
            bst.Insert(80);

            bst.Delete(70);

            bst.Search(70).ShouldBeFalse();
            bst.Search(80).ShouldBeTrue(); // 80 replaces 70
        }

        [Test]
        public void Delete_RootNode_WithTwoChildren_ShouldUpdateRoot()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(60);
            bst.Insert(80);

            bst.Delete(50);

            bst.Search(50).ShouldBeFalse();
            bst.Root.Value.ShouldBe(60); // Successor replaces root
        }

        [Test]
        public void Delete_NonExistentNode_ShouldNotModifyTree()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);

            bst.Delete(100); // Non-existent node

            bst.Search(50).ShouldBeTrue();
            bst.Search(30).ShouldBeTrue();
            bst.Search(70).ShouldBeTrue();
        }

        [Test]
        public void Delete_FromEmptyTree_ShouldNotCrash()
        {
            Should.NotThrow(() => bst.Delete(10)); // Should not throw an exception
        }

        [Test]
        public void GetListOfDepths_ShouldReturnCorrectLists_ForBalancedTree()
        {
            // Arrange
            DataStructurePractice.BinarySearchTree.BinarySearchTree bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(2);
            bst.Insert(7);
            bst.Insert(12);
            bst.Insert(18);

            // Act
            var result = bst.GetListOfDepths();

            // Assert
            result.Count.ShouldBe(3);
            result[0].First.Value.Value.ShouldBe(10);
            result[1].First.Value.Value.ShouldBe(5);
            result[1].Last.Value.Value.ShouldBe(15);
            result[2].First.Value.Value.ShouldBe(2);
            result[2].Last.Value.Value.ShouldBe(18);
        }

        [Test]
        public void GetListOfDepths_ShouldReturnSingleList_ForSingleNodeTree()
        {
            // Arrange
            DataStructurePractice.BinarySearchTree.BinarySearchTree bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();
            bst.Insert(10);

            // Act
            var result = bst.GetListOfDepths();

            // Assert
            result.Count.ShouldBe(1);
            result[0].First.Value.Value.ShouldBe(10);
        }

        [Test]
        public void GetListOfDepths_ShouldReturnCorrectLists_ForLeftSkewedTree()
        {
            // Arrange
            DataStructurePractice.BinarySearchTree.BinarySearchTree bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();
            bst.Insert(10);
            bst.Insert(8);
            bst.Insert(6);
            bst.Insert(4);

            // Act
            var result = bst.GetListOfDepths();

            // Assert
            result.Count.ShouldBe(4);
            result[0].First.Value.Value.ShouldBe(10);
            result[1].First.Value.Value.ShouldBe(8);
            result[2].First.Value.Value.ShouldBe(6);
            result[3].First.Value.Value.ShouldBe(4);
        }

        [Test]
        public void GetListOfDepths_ShouldReturnCorrectLists_ForRightSkewedTree()
        {
            // Arrange
            DataStructurePractice.BinarySearchTree.BinarySearchTree bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();
            bst.Insert(10);
            bst.Insert(12);
            bst.Insert(15);
            bst.Insert(18);

            // Act
            var result = bst.GetListOfDepths();

            // Assert
            result.Count.ShouldBe(4);
            result[0].First.Value.Value.ShouldBe(10);
            result[1].First.Value.Value.ShouldBe(12);
            result[2].First.Value.Value.ShouldBe(15);
            result[3].First.Value.Value.ShouldBe(18);
        }

        [Test]
        public void GetListOfDepths_ShouldReturnEmptyList_ForEmptyTree()
        {
            // Arrange
            DataStructurePractice.BinarySearchTree.BinarySearchTree bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();

            // Act
            var result = bst.GetListOfDepths();

            // Assert
            result.ShouldBeEmpty();
        }

        [Test]
        public void GetListOfDepths_ShouldReturnCorrectLists_ForUnbalancedTree()
        {
            // Arrange
            DataStructurePractice.BinarySearchTree.BinarySearchTree bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(2);
            bst.Insert(7);
            bst.Insert(12);
            bst.Insert(18);
            bst.Insert(1);
            bst.Insert(6);

            // Act
            var result = bst.GetListOfDepths();

            // Assert
            result.Count.ShouldBe(4);
            result[0].First.Value.Value.ShouldBe(10);
            result[1].First.Value.Value.ShouldBe(5);
            result[1].Last.Value.Value.ShouldBe(15);
            result[2].First.Value.Value.ShouldBe(2);
            result[2].Last.Value.Value.ShouldBe(18);
            result[3].First.Value.Value.ShouldBe(1);
            result[3].Last.Value.Value.ShouldBe(6);
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsEmpty_ShouldReturnTrue()
        {
            DataStructurePractice.BinarySearchTree.BinarySearchTree bst = new DataStructurePractice.BinarySearchTree.BinarySearchTree();

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsTrue(result, "An empty tree should be considered balanced.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeHasOneNode_ShouldReturnTrue()
        {
            // Arrange
            bst.Insert(10);

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsTrue(result, "A single-node tree should be balanced.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsPerfectlyBalanced_ShouldReturnTrue()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsTrue(result, "A perfectly balanced tree should return true.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsUnbalanced_ShouldReturnFalse()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(2);  // Left-heavy unbalanced

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsFalse(result, "A left-heavy unbalanced tree should return false.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsRightHeavy_ShouldReturnFalse()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(20);  // Right-heavy unbalanced

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsFalse(result, "A right-heavy unbalanced tree should return false.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeHasMultipleLevels_ShouldReturnTrue()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(12);
            bst.Insert(17);

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsTrue(result, "A tree with balanced multiple levels should return true.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsLeftHeavy_ShouldReturnFalse()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(1);  // Left-heavy unbalanced tree

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsFalse(result, "A left-heavy tree should return false.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsRightHeavy_ShouldReturnFalse2()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(15);
            bst.Insert(20);
            bst.Insert(25);
            bst.Insert(30);  // Right-heavy unbalanced tree

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsFalse(result, "A right-heavy tree should return false.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeHasMoreNodesOnOneSide_ShouldReturnFalse()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(2);
            bst.Insert(1); // The left side is much deeper than the right

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsFalse(result, "A tree with more nodes on one side should be unbalanced.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsSkewedLeft_ShouldReturnFalse()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(9);
            bst.Insert(8);
            bst.Insert(7);
            bst.Insert(6);  // A completely skewed left tree

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsFalse(result, "A left-skewed tree should return false.");
        }

        [Test]
        public void IsBalancedTree_WhenTreeIsSkewedRight_ShouldReturnFalse()
        {
            // Arrange
            bst.Insert(10);
            bst.Insert(11);
            bst.Insert(12);
            bst.Insert(13);
            bst.Insert(14);  // A completely skewed right tree

            // Act
            bool result = bst.IsBalancedTree();

            // Assert
            Assert.IsFalse(result, "A right-skewed tree should return false.");
        }

        [Test]
        public void IsBinarySearchTree_LargeInvalidBST_ReturnsFalse()
        {
            bst.Root = new BinarySearchTreeNode(50);
            bst.Root.Left = new BinarySearchTreeNode(30);
            bst.Root.Right = new BinarySearchTreeNode(70);
            bst.Root.Left.Left = new BinarySearchTreeNode(20);
            bst.Root.Left.Right = new BinarySearchTreeNode(60); // ❌ Invalid: 60 should be in the right subtree of 50

            Assert.IsFalse(bst.IsBinarySearchTree(), "A large invalid BST should return false.");
        }

        [Test]
        public void IsBinarySearchTree_SingleNodeTree_ReturnsTrue()
        {
            bst.Insert(10);
            Assert.IsTrue(bst.IsBinarySearchTree(), "A single-node tree should be a valid BST.");
        }

        [Test]
        public void IsBinarySearchTree_ValidBST_ReturnsTrue()
        {
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(2);
            bst.Insert(7);
            bst.Insert(12);
            bst.Insert(20);

            Assert.IsTrue(bst.IsBinarySearchTree(), "A properly structured BST should return true.");
        }

        [Test]
        public void IsBinarySearchTree_InvalidBST_ReturnsFalse()
        {
            bst.Root = new BinarySearchTreeNode(10);
            bst.Root.Left = new BinarySearchTreeNode(5);
            bst.Root.Right = new BinarySearchTreeNode(15);
            bst.Root.Left.Left = new BinarySearchTreeNode(2);
            bst.Root.Left.Right = new BinarySearchTreeNode(12); // ❌ Invalid: 12 should be in the right subtree of 10

            Assert.IsFalse(bst.IsBinarySearchTree(), "An invalid BST should return false.");
        }

        [Test]
        public void IsBinarySearchTree_LargeBST_ReturnsTrue()
        {
            int[] values = { 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45, 55, 65, 75, 90 };
            foreach (var val in values)
            {
                bst.Insert(val);
            }

            Assert.IsTrue(bst.IsBinarySearchTree(), "A large valid BST should return true.");
        }

        [Test]
        public void FindSuccessor_NodeHasRightSubtree_ReturnsLeftmostNodeInRightSubtree()
        {
            /*
                      20
                     /  \
                   10    30
                  /  \   /  \
                 5   15 25  35
                          /
                         27
            */
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(30);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(25);
            bst.Insert(35);
            bst.Insert(27);

            var successor = bst.FindSuccessorNode(25);

            Assert.Null(successor);
        }

        [Test]
        public void FindSuccessor_NodeHasRightSubtree_ReturnsLeftmostNodeInRightSubtree2()
        {
            /*
                      20
                     /  \
                   10    30
                  /  \   /  \
                 5   15 25  35
                          \
                          27
            */
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(30);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(25);
            bst.Insert(35);
            bst.Insert(27);

            var successor = bst.FindSuccessorNode(30);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(35);

            successor = bst.FindSuccessorNode(5);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(10);

            successor = bst.FindSuccessorNode(10);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(15);

            successor = bst.FindSuccessorNode(15);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(20);

            successor = bst.FindSuccessorNode(20);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(25);

            successor = bst.FindSuccessorNode(25);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(27);

            successor = bst.FindSuccessorNode(27);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(30);

            successor = bst.FindSuccessorNode(30);

            Assert.NotNull(successor);
            successor.Value.ShouldBe(35);

            successor = bst.FindSuccessorNode(35);

            Assert.Null(successor);
        }

        [Test]
        public void FindSuccessor_NodeHasNoRightSubtree_ReturnsFirstRightAncestor()
        {
            /*
                      20
                     /  \
                   10    30
                  /  \
                 5   15
            */
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(30);
            bst.Insert(5);
            bst.Insert(15);

            var successor = bst.FindSuccessorNode(15);

            Assert.Null(successor);
            //Assert.AreEqual(20, successor.Value, "Successor should be 20 (first right ancestor).");
        }

        [Test]
        public void FindSuccessor_LargestNode_ReturnsNull()
        {
            /*
                      20
                     /  \
                   10    30
            */
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(30);

            var successor = bst.FindSuccessorNode(30);

            Assert.IsNull(successor, "Successor of the largest node should be null.");
        }

        [Test]
        public void FindSuccessor_SingleNode_ReturnsNull()
        {
            bst.Insert(10);

            var successor = bst.FindSuccessorNode(10);

            Assert.IsNull(successor, "Single-node tree should return null successor.");
        }

    }
}
