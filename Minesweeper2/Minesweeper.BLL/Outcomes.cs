using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.BLL
{
    public class Outcomes
    {
        public void CheckGrid(int choice, int[] gameBoard)
        {
            
        }

        public bool IsGameOver(string[] displayBoard)
        {
            foreach (string isHidden in displayBoard)
            {
                if(isHidden==" []")
                    return false;
            }
            return true;
        }

    }
}
