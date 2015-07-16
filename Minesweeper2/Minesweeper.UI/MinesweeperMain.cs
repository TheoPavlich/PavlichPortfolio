using Minesweeper.UI.Workflow;

namespace Minesweeper.UI
{
    internal class MinesweeperMain
    {
        private static void Main(string[] args)
        {
            var newGame = new GameStart();
            newGame.Play();
        }
    }
}