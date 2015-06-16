using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.BLL;

namespace Minesweeper.UI.Workflow
{
    class GameStart
    {
        public void Play()
        {
            Console.WriteLine("1, 2, 3 or Q");
            string userInput = Console.ReadLine();
            ProcessUserInput(userInput);
        }

        public void ProcessUserInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    EasyGame easyGame = new EasyGame();
                    easyGame.PlayGame();
                    break;

                case "2":
                    MediumGame medGame= new MediumGame();
                    medGame.PlayGame();
                    break;

                case "3":
                    DifficultGame hardGame = new DifficultGame();
                    hardGame.PlayGame();
                    break;

                case "Q":
                    Console.WriteLine("Goodbye!\n");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Not a valid selection. Please try again.\n");
                    return;
            }
        }
    }
}
