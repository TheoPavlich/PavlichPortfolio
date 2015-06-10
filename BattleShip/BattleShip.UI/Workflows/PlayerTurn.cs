using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI.Workflows
{
    class PlayerTurn
    {
        public void PlayTurn(Player player, Player opponent, Board board)
        {
            PlayerShot(board);
            //PrintDisplayBoard(opponent);
        }

  /*      private void PrintDisplayBoard(Player opponent)
        {

            foreach (string s in opponent.DisplayBoard)
            {
                Console.Write(s);
            }
            Console.WriteLine("\n\n");
        }
        */
        private void PlayerShot(Board board )
        {
            Console.WriteLine("Enter coordinates for your shot (ie A2): ");
            string coords = Console.ReadLine();
            TranslateLetter xLetter = new TranslateLetter();

            int inputX = xLetter.ConvertLetters[coords.Substring(0, 1).ToUpper()];
            int inputY = int.Parse(coords.Substring(1));

            var coordinate = new Coordinate(inputX, inputY);

            board.FireShot(coordinate);

        }
    }
}
