using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.UI.Workflow;

namespace Minesweeper.UI
{
    class MinesweeperMain
    {
        static void Main(string[] args)
        {
            GameStart newGame = new GameStart();
            newGame.Play();
        }
    }
}
