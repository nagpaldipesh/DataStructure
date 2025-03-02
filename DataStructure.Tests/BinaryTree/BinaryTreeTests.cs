using System;
using NUnit.Framework;
using DataStructurePractice.BinaryTree;
using Shouldly;
using DataStructurePractice.BinarySearchTree;

namespace DataStructurePractice.Tests.BinaryTree
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void AddNode_ShouldAddRootNode_WhenTreeIsEmpty()
        {
            // Arrange
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();
            int rootValue = 10;

            // Act
            tree.AddNode(rootValue);

            // Assert
            tree.Node.ShouldNotBeNull();
            tree.Node.Data.ShouldBe(rootValue);
        }

        [Test]
        public void AddNode_ShouldAddNodeToLeft_WhenValueIsLessThanRoot()
        {
            // Arrange
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();
            tree.AddNode(10);
            int leftValue = 5;

            // Act
            tree.AddNode(leftValue);

            // Assert
            tree.Node.Left.ShouldNotBeNull();
            tree.Node.Left.Data.ShouldBe(leftValue);
        }

        [Test]
        public void AddNode_ShouldAddNodeToRight_WhenValueIsGreaterThanRoot()
        {
            // Arrange
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();
            tree.AddNode(10);
            int rightValue = 15;

            // Act
            tree.AddNode(rightValue);

            // Assert
            tree.Node.Right.ShouldNotBeNull();
            tree.Node.Right.Data.ShouldBe(rightValue);
        }

        [Test]
        public void AddNode_ShouldNotCreateDuplicateNodes_WhenDuplicateValueIsAdded()
        {
            // Arrange
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();
            tree.AddNode(10);

            // Act
            tree.AddNode(10);

            // Assert
            tree.Node.Left.ShouldBeNull();
            tree.Node.Right.ShouldBeNull();
        }

        [Test]
        public void AddNode_ShouldAddMultipleNodes_Correctly()
        {
            // Arrange
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();
            int[] values = { 10, 5, 15, 3, 7, 12, 18 };

            // Act
            foreach (int value in values)
            {
                tree.AddNode(value);
            }

            // Assert
            tree.Node.Data.ShouldBe(10);
            tree.Node.Left.Data.ShouldBe(5);
            tree.Node.Right.Data.ShouldBe(15);
            tree.Node.Left.Left.Data.ShouldBe(3);
            tree.Node.Left.Right.Data.ShouldBe(7);
            tree.Node.Right.Left.Data.ShouldBe(12);
            tree.Node.Right.Right.Data.ShouldBe(18);
        }

        [Test]
        public void InOrderTraversal_ShouldReturnCorrectOrder()
        {
            // Arrange
            var expectedOutput = "3 5 7 10 15 18 ";
            var tree = GetBinaryTree();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                tree.InOrderTraversal();

                // Assert
                sw.ToString().ShouldBe(expectedOutput);
            }
        }

        [Test]
        public void PreOrderTraversal_ShouldReturnCorrectOrder()
        {
            // Arrange
            var expectedOutput = "10 5 3 7 15 18 ";
            var tree = GetBinaryTree();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                tree.PreOrderTraversal();

                // Assert
                sw.ToString().ShouldBe(expectedOutput);
            }
        }

        [Test]
        public void PostOrderTraversal_ShouldReturnCorrectOrder()
        {
            // Arrange
            var expectedOutput = "3 7 5 18 15 10 "; // Correct post-order: Left, Right, Root
            var tree = GetBinaryTree();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                tree.PostOrderTraversal();

                // Assert
                sw.ToString().ShouldBe(expectedOutput);
            }
        }

        [Test]
        public void AddNode_ShouldAddNodeCorrectly()
        {
            // Arrange
            var newTree = new DataStructurePractice.BinaryTree.BinaryTree();
            int[] values = { 10, 5, 15, 3, 7, 18 };

            // Act
            foreach (var value in values)
            {
                newTree.AddNode(value);
            }

            // Assert that the tree root and its children are correctly added
            newTree.Node.Data.ShouldBe(10);
            newTree.Node.Left.Data.ShouldBe(5);
            newTree.Node.Right.Data.ShouldBe(15);
            newTree.Node.Left.Left.Data.ShouldBe(3);
            newTree.Node.Left.Right.Data.ShouldBe(7);
            newTree.Node.Right.Right.Data.ShouldBe(18);
        }

        [Test]
        public void LevelOrderTraversalBFS_ShouldReturnCorrectOrder()
        {
            // Arrange
            var expectedOutput = "10 5 15 3 7 18 ";
            var tree = GetBinaryTree();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                tree.LevelOrderTraversalBFS();  // Calling the BFS method

                // Assert
                sw.ToString().ShouldBe(expectedOutput);
            }
        }

        // Additional tests for edge cases
        [Test]
        public void LevelOrderTraversalBFS_EmptyTree_ShouldReturnEmpty()
        {
            // Arrange
            var emptyTree = new DataStructurePractice.BinaryTree.BinaryTree();
            var expectedOutput = "";  // No nodes to traverse

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                emptyTree.LevelOrderTraversalBFS();

                // Assert
                sw.ToString().ShouldBe(expectedOutput);
            }
        }

        [Test]
        public void LevelOrderTraversalBFS_SingleNodeTree_ShouldReturnRootOnly()
        {
            // Arrange
            var singleNodeTree = new DataStructurePractice.BinaryTree.BinaryTree();
            singleNodeTree.AddNode(10);
            var expectedOutput = "10 ";  // Only the root node should be printed

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                singleNodeTree.LevelOrderTraversalBFS();

                // Assert
                sw.ToString().ShouldBe(expectedOutput);
            }
        }

        public DataStructurePractice.BinaryTree.BinaryTree GetBinaryTree()
        {
            // Setup a simple tree for testing
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();
            tree.AddNode(10);
            tree.AddNode(5);
            tree.AddNode(15);
            tree.AddNode(3);
            tree.AddNode(7);
            tree.AddNode(18);

            return tree;
        }

        [Test]
        public void IsBinarySearchTree_EmptyTree_ReturnsTrue()
        {
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();

            Assert.IsTrue(tree.IsBinarySearchTree(), "An empty tree should be a valid tree.");
        }

        [Test]
        public void IsBinarySearchTree_SingleNodeTree_ReturnsTrue()
        {
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();

            tree.AddNode(10);
            Assert.IsTrue(tree.IsBinarySearchTree(), "A single-node tree should be a valid tree.");
        }

        [Test]
        public void IsBinarySearchTree_ValidBST_ReturnsTrue()
        {
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();

            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(12);
            tree.Insert(20);

            Assert.IsTrue(tree.IsBinarySearchTree(), "A properly structured BST should return true.");
        }

        [Test]
        public void IsBinarySearchTree_LargeBST_ReturnsTrue()
        {
            var tree = new DataStructurePractice.BinaryTree.BinaryTree();

            int[] values = { 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45, 55, 65, 75, 90 };
            foreach (var val in values)
            {
                tree.Insert(val);
            }

            Assert.IsTrue(tree.IsBinarySearchTree(), "A large valid BST should return true.");
        }
    }
}
