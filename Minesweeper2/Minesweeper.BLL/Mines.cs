using System;

namespace Minesweeper.BLL
{
    public class Mines
    {
        public int[] GenerateMines(int numMines, int gridSize)
        {
            var mines = new int[numMines];
            var rand = new Random();

            for (var i = 0; i < numMines; i++)
            {
                mines[i] = rand.Next(0, gridSize);
                for (var j = 0; j < i; j++)
                {
                    if (mines[i] == mines[j])
                    {
                        mines[i] = rand.Next(0, gridSize);
                    }
                }
            }

            return mines;
        }
    }
}