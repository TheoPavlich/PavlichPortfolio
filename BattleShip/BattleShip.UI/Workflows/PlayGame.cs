using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI.Workflows
{
    class PlayGame
    {
        public void Play(Player player1, Player player2)
        {
            SetupGame newSetUp = new SetupGame();

            Board p1Board = newSetUp.SetupBoard(player1);
            newSetUp.PrintShipSetupBoard(player1);
            Console.WriteLine("Press enter to clear the screen and continue for {0}'s setup", player2.Name);
            Console.ReadLine();
            Console.Clear();

            Board p2Board = newSetUp.SetupBoard(player2);
            newSetUp.PrintShipSetupBoard(player2);
            Console.WriteLine("Press enter to clear the screen and start playing!");
            Console.ReadLine();
            Console.Clear();

            PlayerTurn turn = new PlayerTurn();
            Player currentPlayer = player1;
            Board currentBoard = p2Board;
            Player opponent = player2;

            bool gameOver = false;

            do
            {
                gameOver = turn.PlayTurn(currentPlayer, currentBoard);
                currentPlayer = currentPlayer == player1 ? player2 : player1;
                currentBoard = currentBoard == p2Board ? p1Board : p2Board;
                opponent = opponent == player2 ? player1 : player2;

            } while (!gameOver);

            GameOver(opponent, currentPlayer);
        }

        public void GameOver(Player winner, Player loser)
        {
            Console.WriteLine("Congratulations {0}, you beat {1}! How about a rematch? ", winner.Name, loser.Name);
            Console.WriteLine("\"P\"lay again \n \"Q\"uit");
            string response = Console.ReadLine().ToUpper();
            switch (response)
            {
                case "P":
                    GameStart newGame = new GameStart();
                    newGame.StartGame();
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


        

        



        


    }
}
