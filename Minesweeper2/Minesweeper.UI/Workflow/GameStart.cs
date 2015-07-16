using System;

namespace Minesweeper.UI.Workflow
{
    internal class GameStart
    {
        public void Play()
        {
            Console.WriteLine("1, 2, 3 or Q");
            var userInput = Console.ReadLine();
            ProcessUserInput(userInput);
        }

        public void ProcessUserInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    var easyGame = new EasyGame();
                    easyGame.PlayGame();
                    break;

                case "2":
                    var medGame = new MediumGame();
                    medGame.PlayGame();
                    break;

                case "3":
                    var hardGame = new DifficultGame();
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