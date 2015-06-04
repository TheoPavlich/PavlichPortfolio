using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Conditionals.BLL;

namespace Warmups.Conditionals.Tests
{
    [TestFixture]
    public class ConditionalTests
    {
        [TestCase( true,true,true)]
        [TestCase(false,false,true)]
        [TestCase(true,false,false)]
        public void MischeviousChildrenTest(bool kidA, bool kidB, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.MischeviousChildren(kidA, kidB);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, true)]
        public void SleepInTest(bool isWeekday, bool isVaca, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.CanSleepIn(isWeekday, isVaca);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(1, 2, 3)]
        [TestCase(3, 2, 5)]
        [TestCase(2, 2, 8)]
        public void SumDoubleTest(int a, int b, int expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            int actual = conditional.SumDouble(a, b);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(23, 4)]
        [TestCase(10, 11)]
        [TestCase(21, 0)]
        public void Diff21Test(int a, int expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            int actual = conditional.Diff21(a);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(true, 6, true)]
        [TestCase(true, 7, false)]
        [TestCase(false, 6, false)]
        public void ParrotTroubleTest(bool isTalking, int hour, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.ParrotTrouble(isTalking, hour);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(9, 10, true)]
        [TestCase(9, 9, false)]
        [TestCase(1, 9, true)]
        public void Makes10Test(int a, int b, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.Makes10(a, b);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(103, true)]
        [TestCase(90, true)]
        [TestCase(89, false)]
        public void NearHundredTest(int n, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.NearHundred(n);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(1, -1, false, true)]
        [TestCase(-1, 1, false, true)]
        [TestCase(-4, -5, true, true)]
        public void PosNegTest(int a, int b, bool neg, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.PosNeg(a, b, neg);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("candy", "not candy")]
        [TestCase("x", "not x")]
        [TestCase("not bad", "not bad")]
        public void NotStringTest(string str, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.NotString(str);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("kitten",1, "ktten")]
        [TestCase("kitten",0, "itten")]
        [TestCase("kitten",4, "kittn")]
        public void MissingCharTest(string str, int n, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.MissingChar(str, n);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("code", "eodc")]
        [TestCase("a", "a")]
        [TestCase("ab", "ba")]
        [TestCase("banana","aananb")]
        public void FrontBackTest(string str, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.FrontBack(str);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("Microsoft", "MicMicMic")]
        [TestCase("Chocolate", "ChoChoCho")]
        [TestCase("at", "atatat")]
        public void Front3Test(string str, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.Front3(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("cat", "tcatt")]
        [TestCase("Hello", "oHelloo")]
        [TestCase("a", "aaa")]
        public void BackAroundTest(string str, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.BackAround(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, true)]
        [TestCase(10, true)]
        [TestCase(8, false)]
        public void Multiple3Or5Test(int n, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.Multiple3Or5(n);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("hi there", true)]
        [TestCase("hi", true)]
        [TestCase("high up", false)]
        [TestCase("h", false)]
        public void StartHiTest(string str, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.StartHi(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(120, -1, true)]
        [TestCase(-1, 120, true)]
        [TestCase(2, 120, false)]
        public void IcyHotTest(int a, int b, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.IcyHot(a, b);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(12, 99, true)]
        [TestCase(21, 12, true)]
        [TestCase(9, 120, false)]
        public void Between10And20Test(int a, int b, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.Between10And20(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(13, 20, 10, true)]
        [TestCase(20, 19, 10, true)]
        [TestCase(20,10, 12, false)]
        public void HasTeenTest(int a, int b, int c, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.HasTeen(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(13, 20, true)]
        [TestCase(20, 19, true)]
        [TestCase(13, 14, false)]
        public void SoAloneTest(int a, int b, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.SoAlone(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("adelbc", "abc")]
        [TestCase("adelHello", "aHello")]
        [TestCase("adedbc", "adedbc")]
        [TestCase("adel","a")]
        [TestCase("de","de")]
        [TestCase("del","")]
        public void RemoveDelTest(string s, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.RemoveDel(s);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("mix snacks", true)]
        [TestCase("pix snacks", true)]
        [TestCase("piz snacks", false)]
        [TestCase("9ix", true)]
        public void IxStartTest(string str, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.IxStart(str);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("ozymandias", "oz")]
        [TestCase("bzoo", "z")]
        [TestCase("oxx", "o")]
        public void StartOzTest(string s, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.StartOz(s);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1,2,3,3)]
        [TestCase(1,3,2,3)]
        [TestCase(3,4,1,4)]
        public void MaxTest(int a,int b, int c, int expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            int actual = conditional.Max(a,b,c);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(13,8,8)]
        [TestCase(8, 13,8)]
        [TestCase(13, 7, 0)]
        public void CloserTest(int a, int b, int expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            int actual = conditional.Closer(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", true)]
        [TestCase("Heelle", true)]
        [TestCase("Heelele", false)]
        public void GotETest(string s, bool expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            bool actual = conditional.GotE(s);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "HeLLO")]
        [TestCase("hi there", "hi thERE")]
        [TestCase("hi", "HI")]
        public void EndUpTest(string s, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.EndUp(s);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Miracle", 2, "Mrce")]
        [TestCase("abcdefg",2, "aceg")]
        [TestCase("abcdefg", 3,"adg")]
        public void EveryNthTest(string s, int n, string expected)
        {
            // Arrange, Act, Assert
            ConditionalWarmups conditional = new ConditionalWarmups();

            string actual = conditional.EveryNth(s,n);

            Assert.AreEqual(expected, actual);
        }
    }
}
