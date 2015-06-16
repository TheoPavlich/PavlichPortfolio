using System;

namespace Minesweeper.BLL
{
    public class Mines
    {
        public int[] GenerateMines(int numMines, int gridSize)
        {
            int[] mines = new int[numMines];
            Random rand = new Random();

            for (int i = 0; i < numMines; i++)
            {
                mines[i] = rand.Next(0, gridSize);
                for (int j = 0; j < i; j++)
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