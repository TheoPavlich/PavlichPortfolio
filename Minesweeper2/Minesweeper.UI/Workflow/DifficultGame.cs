using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.BLL;

namespace Minesweeper.UI.Workflow
{
    class DifficultGame
    {
        public void PlayGame()
        {
            Outcomes checkOutcomes = new Outcomes();
            Board hardGame = new Board();
            bool gameOver = false;
            int[] boardArray = hardGame.DifficultBoard();
            string[] displayArray = hardGame.DifficultDisplay();
            string result = "You found them all!";
            while (!gameOver)
            {
                Console.Clear();
                PrintBoard(displayArray);
                gameOver = checkOutcomes.IsGameOver(displayArray);
                int choice = TakeUserChoice();
                if (boardArray[choice] == 9)
                {
                    gameOver = true;
                    result = "You blew yourself up!";
                }
                else //if (boardArray[choice]>0 && boardArray[choice]<9)
                {
                    displayArray[choice] = "  " + boardArray[choice].ToString();
                }
            }
            if (gameOver)
            {
                Console.WriteLine("The game is over! " + result);
                Console.ReadLine();
            }
        }

        public int TakeUserChoice()
        {
            Console.Write("Enter your cell choice by cooridinates. \nX: ");
            string xStr = Console.ReadLine();
            Console.Write("Y: ");
            string yStr = Console.ReadLine();
            Console.WriteLine();

            int x = Int32.Parse(xStr);
            int y = Int32.Parse(yStr);

            int coord = (16 * y) + x;
            return coord;
        }
        public void PrintBoard(string[] displayArray)
        {
            Console.WriteLine("\nY");
            for (int i = 0; i < 256; i++)
            {
                if (i % 16 == 0)
                {
                    if (i / 16 < 10)
                    {
                        Console.Write("\n{0} ", (i / 16));
                    }
                    else
                    {
                        Console.Write("\n{0}", (i / 16));
                    }
                }
                Console.Write("{0}", displayArray[i]);
            }
            Console.WriteLine("\n    0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15  X");
            Console.ReadLine();
        }
    }
}
