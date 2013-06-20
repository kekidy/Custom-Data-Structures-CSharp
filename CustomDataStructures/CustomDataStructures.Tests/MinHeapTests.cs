﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CustomDataStructures.Tests
{
    [TestClass]
    public class MinHeapTests
    {
        [TestMethod]
        public void TestAdd_OneItem()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Add(1);

            Assert.AreEqual(1, minHeap.Count);
        }

        [TestMethod]
        public void TestAdd_100Item()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 100;
            for (int i = 0; i < items; i++)
            {
                minHeap.Add(i);
            }

            Assert.AreEqual(100, minHeap.Count);
        }

        [TestMethod]
        [Timeout(2000)]
        public void TestAdd_Performace_WorstCase()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 500000;
            for (int i = items; i >= 1; i--)
            {
                minHeap.Add(i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemove_EmptyHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Remove();
        }

        [TestMethod]
        public void TestRemove_TenItems()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 10;
            minHeap.Add(10);
            minHeap.Add(1);
            minHeap.Add(9);
            minHeap.Add(2);
            minHeap.Add(8);
            minHeap.Add(3);
            minHeap.Add(7);
            minHeap.Add(4);
            minHeap.Add(6);
            minHeap.Add(5);

            StringBuilder actual = new StringBuilder();
            for (int i = 0; i < items; i++)
            {
                actual.Append(minHeap.Remove());
            }

            string expected = "12345678910";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestRemove_Performace()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            int items = 500000;
            for (int i = 0; i < items; i++)
            {
                minHeap.Add(i);
            }

            for (int i = 0; i < items; i++)
            {
                minHeap.Remove();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek_EmptyHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Peek();
        }

        [TestMethod]
        public void TestPeek_NonEmptyHeap()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Add(90);
            minHeap.Add(5);
            minHeap.Add(15);
            minHeap.Add(89);

            Assert.AreEqual(5, minHeap.Peek());
        }
    }
}
