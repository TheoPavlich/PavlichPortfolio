using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Arrays.BLL;

namespace Warmups.Arrays.Tests
{
    [TestFixture]
    public class WarmupsArraysTests
    {
        [TestCase(new int[] {1, 2, 6}, true)]
        [TestCase(new int[] {6, 1, 2, 3}, true)]
        [TestCase(new int[] {13, 6, 1, 2, 3}, false)]
        public void FirstLast6Test(int[] num, bool expected)
        {
            WarmupArray array = new WarmupArray();

            bool actual = array.FirstLast6(num);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, false)]
        [TestCase(new int[] { 1, 2, 3, 1}, true)]
        [TestCase(new int[] { 1, 2, 1 }, true)]
        public void SameFirstLastTest(int[] num, bool expected)
        {
            WarmupArray array = new WarmupArray();

            bool actual = array.SameFirstLast(num);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 3,1,4 })]
        [TestCase(2, new int[] { 3, 1 })]
        [TestCase(6, new int[] {3,1,4,1,5,9})]
        public void MakePiTest(int num, int[] expected)
        {
            WarmupArray array = new WarmupArray();

            int[] actual = array.MakePi(num);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[]{7,3}, true)]
        [TestCase(new int[] { 1, 2, 3, 1 }, new int[] { 1, 2, 3, 2},false)]
        [TestCase(new int[] { 1, 2, 1 },new int[] { 1, 2, 3, 1 }, true)]
        public void CommonEndTest(int[] a, int[]b, bool expected)
        {
            WarmupArray array = new WarmupArray();

            bool actual = array.CommonEnd(a,b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 6)]
        [TestCase(new int[] { 5,11,2 }, 18)]
        [TestCase(new int[] { 74,0,0}, 74)]
        public void SumTest(int[] a, int expected)
        {
            WarmupArray array = new WarmupArray();

            int actual = array.Sum(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[]{3,2,1})]
        [TestCase(new int[] { 5, 11,15, 2 }, new int[]{2,15,11,5})]
        [TestCase(new int[] { 74, 15,22,12, 0 }, new int[]{0,12,22,15,74})]
        public void ReverseTest(int[] a, int[] expected)
        {
            WarmupArray array = new WarmupArray();

            int[] actual = array.Reverse(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 3, 3 })]
        [TestCase(new int[] { 5, 11, 15, 2 }, new int[] { 15, 15, 15, 15 })]
        [TestCase(new int[] { 74, 15, 22, 12, 0 }, new int[] { 74, 74, 74, 74, 74 })]
        public void HigherWinsTest(int[] a, int[] expected)
        {
            WarmupArray array = new WarmupArray();

            int[] actual = array.HigherWins(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 5, 2, 4, 76, 3 }, new int[] { 3, 3, 3 }, new int[]{2, 3})]
        [TestCase(new int[] { 5, 11, 18, 2,5 }, new int[] { 12, 15, 2}, new int[]{18, 15})]
        [TestCase(new int[] { 74, 15, 12 }, new int[] { 74, 0, 4 }, new int[]{15, 0})]
        public void GetMiddleTest(int[] a, int[]b, int[] expected)
        {
            WarmupArray array = new WarmupArray();

            int[] actual = array.GetMiddle(a,b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { 5, 11, 18, 2, 5 }, true)]
        [TestCase(new int[] { 1, 5, 77, 3 }, false)]
        public void HasEvenTest(int[] num, bool expected)
        {
            WarmupArray array = new WarmupArray();

            bool actual = array.HasEven(num);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 0,0,0,0,0,3 })]
        [TestCase(new int[] { 5, 11, 15, 2 }, new int[] { 0,0,0,0,0,0,0,2 })]
        [TestCase(new int[] { 74, 15, 22, 0, 12 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0,0, 12 })]
        public void KeepLastTest(int[] a, int[] expected)
        {
            WarmupArray array = new WarmupArray();

            int[] actual = array.KeepLast(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 2, 6 }, true)]
        [TestCase(new int[] { 3, 1, 2, 3 }, true)]
        [TestCase(new int[] { 13, 2, 2, 2, 3 }, false)]
        public void Double23Test(int[] a, bool expected)
        {
            WarmupArray array = new WarmupArray();

            bool actual = array.Double23(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 3, 15,12,18 }, true)]
        [TestCase(new int[] { 5, 11, 2, 1,1,1 }, false)]
        [TestCase(new int[] { 74, 15, 22, 1, 3 }, true)]
        public void Unlucky1Test(int[] a, bool expected)
        {
            WarmupArray array = new WarmupArray();

            bool actual = array.Unlucky1(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 28 }, new int[] { 3, 3, 3 }, new int[] { 1,28 })]
        [TestCase(new int[] { 52 }, new int[] { 12, 15, 2 }, new int[] { 52,12})]
        [TestCase(new int[] {}, new int[] { 74, 0, 4 }, new int[] { 74, 0 })]
        public void Make2Test(int[] a, int[] b, int[] expected)
        {
            WarmupArray array = new WarmupArray();

            int[] actual = array.Make2(a, b);

            Assert.AreEqual(expected, actual);
        }

    }
}

