using NUnit.Framework;
using TicTacToe.BLL;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeTest
    {
        [TestCase(new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"}, false)]
        [TestCase(new[] {"X", "X", "X", "X", "X", "X", "X", "X", "X"}, true)]
        public void CheckTieTest(string[] test, bool expected)
        {
            var logic = new Outcomes();

            var actual = logic.CheckTie(test);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"}, false)]
        [TestCase(new[] {"X", "X", "X", "4", "5", "6", "7", "8", "9"}, true)]
        public void CheckWinTest(string[] test, bool expected)
        {
            var logic = new Outcomes();

            var actual = logic.CheckWinner(test, "X");

            Assert.AreEqual(expected, actual);
        }
    }
}