using DataStructurePractice.Arrays.Problems;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Tests.Arrays
{
    public class CheckIsArrayRotatedAndSortedTests
    {
        CheckIsArrayRotatedAndSorted obj;
        
        [SetUp]
        public void SetUp()
        {
            obj = new CheckIsArrayRotatedAndSorted();
        }

        [Test]
        public void Test_Sorted_Ascending_Array()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeFalse();
        }

        [Test]
        public void Test_Sorted_Descending_Array()
        {
            int[] arr = { 5, 4, 3, 2, 1 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeFalse();
        }

        [Test]
        public void Test_Rotated_Ascending_Array()
        {
            int[] arr = { 3, 4, 5, 1, 2 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeTrue();
        }

        [Test]
        public void Test_Rotated_Ascending_Array2()
        {
            int[] arr = { 5, 1, 2, 3, 4 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeTrue();
        }

        [Test]
        public void Test_Rotated_Descending_Array()
        {
            int[] arr = { 3, 2, 1, 5, 4 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeTrue();
        }

        [Test]
        public void Test_Rotated_Descending_Array2()
        {
            int[] arr = { 1, 5, 4, 3, 2 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeTrue();
        }

        [Test]
        public void Test_Rotated_Descending_Array3()
        {
            int[] arr = { 2, 1, 5, 4, 3 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeTrue();
        }

        [Test]
        public void Test_Unsorted_Array()
        {
            int[] arr = { 1, 3, 2, 4, 5 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeFalse();
        }

        [Test]
        public void Test_Single_Element_Array()
        {
            int[] arr = { 42 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeFalse();
        }

        [Test]
        public void Test_Empty_Array()
        {
            int[] arr = { };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeFalse();
        }

        [Test]
        public void Test_Reversed_Rotated_Array()
        {
            int[] arr = { 4, 5, 1, 2, 3 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeTrue();
        }

        [Test]
        public void Test_Multiple_Rotations_False()
        {
            int[] arr = { 4, 1, 3, 2, 5 };
            obj.CheckArrayIsRotatedAndSorted(arr).ShouldBeFalse();
        }
    }
}

