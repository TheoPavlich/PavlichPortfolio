using System;
using Minesweeper.BLL;

namespace Minesweeper.UI.Workflow
{
    internal class MediumGame
    {
        public void PlayGame()
        {
            var checkOutcomes = new Outcomes();
            var medGame = new Board();
            var gameOver = false;
            var boardArray = medGame.MediumBoard();
            var displayArray = medGame.MediumDisplay();
            var result = "You found them all!";
            while (!gameOver)
            {
                Console.Clear();
                PrintBoard(displayArray);
                gameOver = checkOutcomes.IsGameOver(displayArray);
                var choice = TakeUserChoice();
                if (boardArray[choice] == 9)
                {
                    gameOver = true;
                    result = "You blew yourself up!";
                }
                else //if (boardArray[choice]>0 && boardArray[choice]<9)
                {
                    displayArray[choice] = "  " + boardArray[choice];
                }
            }
            Console.WriteLine("The game is over! " + result);
            Console.ReadLine();
  
        }

        public int TakeUserChoice()
        {
            string xStr = null;
            string yStr = null;
            while (xStr == null && yStr == null)
            {
                Console.Write("Enter your cell choice by cooridinates. \nX: ");
                xStr = Console.ReadLine();
                Console.Write("Y: ");
                yStr = Console.ReadLine();
                Console.WriteLine();
            }

            var x = int.Parse(xStr);
            var y = int.Parse(yStr);

            var coord = (12 * y) + x;
            return coord;

        }

        public void PrintBoard(string[] displayArray)
        {
            Console.WriteLine("\nY");
            for (var i = 0; i < 144; i++)
            {
                if (i%12 == 0)
                {
                    Console.Write(i/12 < 10 ? "\n{0} " : "\n{0}", (i/12));
                }
                Console.Write("{0}", displayArray[i]);
            }
            Console.WriteLine("\n    0  1  2  3  4  5  6  7  8  9 10 11  X");
            Console.ReadLine();
        }
    }
}