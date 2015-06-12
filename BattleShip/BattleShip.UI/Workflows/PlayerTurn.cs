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
        public void PlayTurn(Player player, Board board)
        {
            PlayerShot(player, board);
            PrintDisplayBoard(player);
        }

        private void PrintDisplayBoard(Player player)
        {

            foreach (string s in player.DisplayBoard)
            {
                Console.Write(s);
            }
            Console.WriteLine("\n\n");
        }
        
        private void PlayerShot(Player player, Board board )
        {
            Console.WriteLine("{0}, enter coordinates for your shot (ie A2): ", player.Name);
            string coords = Console.ReadLine();
            TranslateLetter xLetter = new TranslateLetter();

            int inputX = xLetter.ConvertLetters[coords.Substring(0, 1).ToUpper()];
            int inputY = int.Parse(coords.Substring(1));

            var coordinate = new Coordinate(inputY, inputX);

            board.FireShot(coordinate);

        }
    }
}
