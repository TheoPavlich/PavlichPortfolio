using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Loops.BLL;

namespace Warmup.Loops.Tests
{
    [TestFixture]
    public class LoopTests
    {
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
    }
}
