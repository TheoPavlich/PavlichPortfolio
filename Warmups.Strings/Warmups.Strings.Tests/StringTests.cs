using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Strings.BLL;

namespace Warmups.Strings.Tests
{
    [TestFixture]
    public class StringTests
    {

        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void SayHiTest(string name, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.SayHi(name);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Yo", "Alice", "YoAliceAliceYo")]
        [TestCase("Wut", "up", "WutupupWut")]
        public void AbbaTest(string a, string b, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.Abba(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]
        public void MakeTagsTest(string a, string b, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.MakeTags(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("<<>>", "Yay", "<<Yay>>")]
        [TestCase("<<>>", "WooHoo", "<<WooHoo>>")]
        [TestCase("[[]]", "word", "[[word]]")]
        public void InsertWordTest(string a, string b, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.InsertWord(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello","lololo")]
        [TestCase("ab","ababab")]
        [TestCase("aHi", "HiHiHi")]
        public void MultipleEndingsTest(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.MultipleEndings(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("HelloThere", "Hello")]
        [TestCase("WooHoo", "Woo")]
        [TestCase("abccba", "abc")]
        public void FirstHalfTest(string a, string expected)
        {
            StringWarmups strings = new StringWarmups();

            string actual = strings.FirstHalf(a);

            Assert.AreEqual(expected,actual);
        }

        [TestCase("Hello", "ell")]
        [TestCase("Java", "av")]
        [TestCase("coding", "odin")]
        public void TrimOneTest(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.TrimOne(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "Hi","HiHelloHi")]
        [TestCase("Hi", "Hello", "HiHelloHi")]
        [TestCase("aaa","b", "baaab")]
        public void LongInMiddleTest(string a, string b, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.LongInMiddle(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateLeft2Test(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.RotateLeft2(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateRight2Test(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.RotateRight2(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]
        public void TakeOneTest(string a, bool front, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.TakeOne(a,front);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("practice", "ct")]
        public void MiddleTwoTest(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.MiddleTwo(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]
        public void EndsWithLyTest(string a, bool expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            bool actual = strings.EndsWithLy(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]
        public void FrontAndBackTest(string a, int n, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.FrontAndBack(a,n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3,"ja")]
        public void TakeTwoFromPositionTest(string a, int n, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.TakeTwoFromPosition(a, n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        [TestCase("",false)]
        [TestCase("ba", false)]
        public void HasBadTest(string a, bool expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            bool actual = strings.HasBad(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("hello", "he")]
        [TestCase("hi", "hi")]
        [TestCase("h", "h@")]
        public void AtFirstTest(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.AtFirst(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("last", "chars", "ls")]
        [TestCase("yo","mama" , "ya")]
        [TestCase("hi", "", "h@")]
        [TestCase("","","@@")]
        [TestCase("","hi","@i")]
        public void LastCharsTest(string a, string b, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.LastChars(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc" ,"", "abc")]
        public void ConCatTest(string a, string b, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.ConCat(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("coding", "codign")]
        [TestCase("cat", "cta")]
        [TestCase("ab", "ba")]
        [TestCase("a","a")]
        [TestCase("","")]
        public void SwapLastTest(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.SwapLast(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("edited", true)]
        [TestCase("edit", false)]
        [TestCase("ed", true)]
        [TestCase("", true)]
        public void FrontAgainTest(string a, bool expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            bool actual = strings.FrontAgain(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("hello", "hi", "lohi")]
        [TestCase("hello", "java", "ellojava")]
        [TestCase("java", "hello","javaello")]
        [TestCase("hi","ho", "hiho")]  
        public void MinCatTest(string a, string b, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.MinCat(a,b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "llo")]
        [TestCase("away", "aay")]
        [TestCase("abed", "abed")]
        [TestCase("tbed", "ted")]
        public void TweakFrontTest(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.TweakFront(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("xHix", "Hi")]
        [TestCase("xHi", "Hi")]
        [TestCase("Hxix", "Hxi")]
        [TestCase("Hia","Hia")]
        [TestCase("Hix","Hi")]
        public void StripXTest(string a, string expected)
        {
            // Arrange, Act, Assert
            StringWarmups strings = new StringWarmups();

            string actual = strings.StripX(a);

            Assert.AreEqual(expected, actual);
        }

        
      
    }

}