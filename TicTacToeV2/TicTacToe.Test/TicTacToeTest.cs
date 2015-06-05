using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe.BLL;


namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeTest
    {

        [TestCase(new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9"}, false)]
        [TestCase(new string[]{"X", "X", "X", "X", "X", "X", "X", "X", "X"}, true)]
        public void CheckTieTest(string[] test, bool expected)
        {
            Outcomes logic = new Outcomes();

            bool actual = logic.CheckTie(test);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }, false)]
        [TestCase(new string[] { "X", "X", "X", "4", "5", "6", "7", "8", "9" }, true)]
        public void CheckWinTest(string[] test, bool expected)
        {
            Outcomes logic = new Outcomes();

            bool actual = logic.CheckWinner(test, "X");

            Assert.AreEqual(expected, actual);
        }
    }
}
