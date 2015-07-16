using System;
using BattleShip.BLL;
using BattleShip.UI.Workflows;

namespace BattleShip.UI
{
    public class GameStart
    {
        public void Execute()
        {
            string userInput="";
            do
            {
                DisplayMenu();
                var readLine = Console.ReadLine();
                if (readLine != null) userInput = readLine.ToUpper();
                ProcessUserChoice(userInput);
            } while (userInput != "Q");
        }

        private void ProcessUserChoice(string userInput)
        {
            switch (userInput)
            {
                case "S":
                    StartGame();
                    break;
                case "Q":
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("That is not a valid selection. Please press enter and try again.");
                    Console.ReadLine();
                    break;
            }
        }

        public void StartGame()
        {
            var player1 = new Player();
            CreateNewPlayer(player1, 1);
            var player2 = new Player();
            CreateNewPlayer(player2, 2);
            var newGame = new PlayGame();
            newGame.Play(player1, player2);
        }

        public void CreateNewPlayer(Player player, int n)
        {
            string[] alpha = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
            player.PlayerNum = n;
            Console.WriteLine("Player {0} enter your name:", player.PlayerNum);
            player.Name = Console.ReadLine();
            player.DisplayBoard = new string[11, 11];
            player.ShipSetup = new string[11, 11];

            for (var i = 0; i < 11; i++)
            {
                for (var j = 0; j < 11; j++)
                {
                    if (i == 0 && j > 0)
                    {
                        player.DisplayBoard[i, j] = "   " + alpha[j - 1];
                    }
                    else if (i == 10 && j == 0)
                    {
                        player.DisplayBoard[i, j] = "\n\n" + i + " ";
                    }
                    else if (j == 0 && i > 0)
                    {
                        player.DisplayBoard[i, j] = "\n\n " + i + " ";
                    }
                    else if (i == 0 && j == 0)
                    {
                        player.DisplayBoard[i, j] = " ";
                    }
                    else
                    {
                        player.DisplayBoard[i, j] = "[ ] ";
                    }
                }
            }

            for (var i = 0; i < 11; i++)
            {
                for (var j = 0; j < 11; j++)
                {
                    if (i == 0 && j > 0)
                    {
                        player.ShipSetup[i, j] = "   " + alpha[j - 1];
                    }
                    else if (i == 10 && j == 0)
                    {
                        player.ShipSetup[i, j] = "\n\n" + i + " ";
                    }
                    else if (j == 0 && i > 0)
                    {
                        player.ShipSetup[i, j] = "\n\n " + i + " ";
                    }
                    else if (i == 0 && j == 0)
                    {
                        player.ShipSetup[i, j] = " ";
                    }
                    else
                    {
                        player.ShipSetup[i, j] = "[ ] ";
                    }
                }
            }
            //player.ShipSetup = player.DisplayBoard;
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("*******BattleShip*******");
            Console.WriteLine("(S)tart new game.\n(Q)uit.");
        }
    }
}