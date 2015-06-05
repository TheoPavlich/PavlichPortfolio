using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Loops.BLL;

namespace Warmups.Loops.Tests
{
    [TestFixture]
    public class LoopTests
    {
        [TestCase("Hi", 2, "HiHi")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("Hi", 1, "Hi")]
        [TestCase("Hi", 5, "HiHiHiHiHi")]
        public void StringTimesTest(string str, int n, string expectedResult)
        {
            //Arrange
            LoopWarmups loops = new LoopWarmups();
            //Act
            string actualResult = loops.StringTimes(str, n);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        
        [TestCase("Chocolate", 2, "ChoCho")]
        [TestCase("Chocolate", 5, "ChoChoChoChoCho")]
        [TestCase("Abc", 3, "AbcAbcAbc")]
        public void FrontTimesTest(string str, int num, string expectedResults)
        {
            //Arrange, Act, Assert

            LoopWarmups loops = new LoopWarmups();

            string actualResults = loops.FrontTimes(str, num);

            Assert.AreEqual(actualResults, expectedResults);

        }

        [TestCase("abcxx", 1)]
        [TestCase("xxx", 2)]
        [TestCase("abxxxcdxxxx", 5)]
        public void CountXXTest(string str, int expected)
        {
            LoopWarmups loops = new LoopWarmups();

            int actual = loops.CountXX(str);

            Assert.AreEqual(actual, expected);

        }

        [TestCase("axxbb", true)]
        [TestCase("axaxxax", false)]
        [TestCase("xxxx",true)]
        [TestCase("abc", false)]
        public void DoubleXTest(string str, bool expected)
        {
            LoopWarmups loops = new LoopWarmups();

            bool actual = loops.DoubleX(str);

            Assert.AreEqual(actual, expected);   
        }

        [TestCase("Hello", "Hlo")]
        [TestCase("Hi", "H")]
        [TestCase("Heeololeo", "Hello")]
        public void EveryOtherTest(string str, string expected)
        {
            LoopWarmups loops = new LoopWarmups();

            string actual = loops.EveryOther(str);

            Assert.AreEqual(actual, expected);

        }

        [TestCase("Code", "CCoCodCode")]
        [TestCase("abc", "aababc")]
        [TestCase("ab", "aab")]
        public void StringSplosionTest(string str, string expected)
        {
            LoopWarmups loops = new LoopWarmups();

            string actual = loops.StringSplosion(str);

            Assert.AreEqual(expected,actual);
        }

        [TestCase("hixxhi", 1)]
        [TestCase("xaxxaxaxx",1)]
        [TestCase("axxxaaxx",2)]
        public void CountLast2Test(string str, int expected)
        {
            LoopWarmups loops = new LoopWarmups();

            int actual = loops.CountLast2(str);

            Assert.AreEqual(expected, actual);
        }
       
 
        [TestCase(new int []{1, 9, 9}, 2)]
        [TestCase(new int []{1,9,9,3,2,9}, 3)]
        [TestCase(new int[] { 1, 3, 9 }, 1)]
        public void Count9Test(int[] num, int expected)
        {
            LoopWarmups loops = new LoopWarmups();

            int actual = loops.Count9(num);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 9, 3,4 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 9 }, false)]
        [TestCase(new int[] { 1, 3, 5}, false)]
        public void ArrayFront9Test(int[] numArray, bool expected)
        {
            LoopWarmups loops = new LoopWarmups();

            bool actual = loops.ArrayFront9(numArray);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[]{1, 2, 3, 2, 3}, true)]
        [TestCase(new int[]{1, 3, 3, 2, 3}, false)]
        [TestCase(new int[]{1, 2, 1, 2, 3}, true)]
        public void Array123Test(int[] numArray, bool expected)
        {
            LoopWarmups loops = new LoopWarmups();

            bool actual = loops.Array123(numArray);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("xxcaazz", "xxbaaz",3)]
        [TestCase("abc", "abc",2)]
        [TestCase("abc", "axc", 0)]
        public void SubStringMatchTest(string strA, string strB, int expected)
        {
            LoopWarmups loops = new LoopWarmups();

            int actual = loops.SubStringMatch(strA, strB);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("xxHxix","xHix")]
        [TestCase("abxxxcd","abcd")]
        [TestCase("xabxxxcdx", "xabcdx")]
        public void StringXTest(string str, string expected)
        {
            LoopWarmups loops = new LoopWarmups();

            string actual = loops.StringX(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("kitten", "kien")]
        [TestCase("Chocolate","Chole")]
        [TestCase("CodingHorror","Congrr")]
        public void AltPairsTest(string str, string expected)
        {
            LoopWarmups loops = new LoopWarmups();

            string actual = loops.AltPairs(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("yakpak", "pak")]
        [TestCase("pakyak", "pak")]
        [TestCase("yak123ya", "123ya")]
        public void DoNotYakTest(string str, string expected)
        {
            LoopWarmups loops = new LoopWarmups();

            string actual = loops.DoNotYak(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 6, 2 }, 1)]
        [TestCase(new int[] { 6, 6, 2, 6 }, 1)]
        [TestCase(new int[] { 6, 7, 2 }, 1)]
        public void Array667Test(int[] nums, int expected)
        {
            LoopWarmups loops = new LoopWarmups();

            int actual = loops.Array667(nums);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 1, 2, 2, 1 }, true)]
        [TestCase(new int[] { 1,1,2,2,2,1 }, false)]
        [TestCase(new int[] { 1,1,1,2,2,2,1 }, false)]
        public void NoTriplesTest(int[] nums, bool expected)
        {
            LoopWarmups loops = new LoopWarmups();

            bool actual = loops.NoTriples(nums);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 7, 1 }, true)]
        [TestCase(new int[] { 1, 2, 8, 1 }, false)]
        [TestCase(new int[] { 5, 10, 4, 4 }, true)]
        public void Pattern51Test(int[] nums, bool expected)
        {
            LoopWarmups loops = new LoopWarmups();

            bool actual = loops.Pattern51(nums);

            Assert.AreEqual(expected, actual);
        }


    }
}
