using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.V2.UI.Workflow
{
    public class GameStart
    {

        public void StartPlay()
        {
            string userInput;
            do
            {
                DisplayMenu();

                userInput = Console.ReadLine().ToUpper();

                ProcessUserChoice(userInput);

            } while (userInput != "Q");
        }

        public void DisplayMenu()
        {
 	        Console.WriteLine("Please make your selection:\n");
            Console.WriteLine("1. Start new game with one player.");
            Console.WriteLine("2. Start new game with two players.");
            Console.WriteLine("Q to quit.\n");
        }

        public void ProcessUserChoice(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    //OnePlayer playAlone = new OnePlayer();
                    //playAlone.Play();
                    Console.WriteLine("Why don't you try to find a friend and come back later?\n");
                    break;

                case "2":
                    TwoPlayers playTogether = new TwoPlayers();
                    playTogether.SetupPlay();
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