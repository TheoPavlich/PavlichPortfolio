using System;
using System.Collections.Generic;
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
            //Player opponent = player2;

            bool gameOver = false;

            do
            {
                turn.PlayTurn(currentPlayer, currentBoard);
                currentPlayer = currentPlayer == player1 ? player2 : player1;
                currentBoard = currentBoard == p2Board ? p1Board : p2Board;
                //opponent = opponent == player2 ? player1 : player2;

            } while (!gameOver);
        }

        private bool IsGameOver(FireShotResponse response)
        {
            if (response.ShotStatus == ShotStatus.Victory)
            {
                return true;
            }
            return false;
        }

        

        



        


    }
}
