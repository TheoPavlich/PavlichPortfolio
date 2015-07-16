using System.Linq;

namespace Minesweeper.BLL
{
    public class Outcomes
    {
        public void CheckGrid(int choice, int[] gameBoard)
        {
        }

        public bool IsGameOver(string[] displayBoard)
        {
            return displayBoard.All(isHidden => isHidden != " []");
        }
    }
}