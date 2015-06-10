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
            newSetUp.SetupBoards(player1,player2);
            PlayerTurn turn = new PlayerTurn();
            Player currentPlayer = player1;

            bool gameOver = false;

            do
            {
                turn.PlayTurn(currentPlayer);
                currentPlayer = currentPlayer == player1 ? player2 : player1;

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
