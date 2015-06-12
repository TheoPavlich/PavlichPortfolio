using System;
using System.Collections.Generic;
using System.Globalization;
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
            PrintDisplayBoard(player);
            PlayerShot(player, board);
            Console.Clear();
        }

        private void PrintDisplayBoard(Player player)
        {

            foreach (string s in player.DisplayBoard)
            {
                if (s == "[M] ")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (s == "[H] ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (s == "[X] ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                Console.Write(s);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\n\n");
        }

        private void UpdateDisplayBoard(Player player, ShotStatus shotStatus, int y, int x)
        {   //Updates display board, does not reprint before end of turn
            //Shows yellow M for miss and red H for hit
            //Also needs shot response input
            //can add logic for sunk ship

            if (shotStatus == ShotStatus.Miss)
            {
                player.DisplayBoard[x, y] = "[M] ";
            }
            else if (shotStatus == ShotStatus.Hit||shotStatus == ShotStatus.HitAndSunk)
            {
                player.DisplayBoard[x, y] = "[H] ";
            }
            //else if (shotStatus == ShotStatus.HitAndSunk)
            //{
            //    player.DisplayBoard[x, y] = "[X] ";
            //}
        }


        private void PlayerShot(Player player, Board board )
        {
            Console.WriteLine("{0}, enter coordinates for your shot (ie A2): ", player.Name);
            string coords = Console.ReadLine();
            TranslateLetter xLetter = new TranslateLetter();

            int inputX = xLetter.ConvertLetters[coords.Substring(0, 1).ToUpper()];
            int inputY = int.Parse(coords.Substring(1));

            var coordinate = new Coordinate(inputX, inputY);

            //board.FireShot(coordinate);
            var shotFire = board.FireShot(coordinate);
            var response = shotFire.ShotStatus;
            Console.WriteLine(response);

            UpdateDisplayBoard(player, response, inputX, inputY);

            if (response == ShotStatus.Victory)
            {
                //EndGame end = new EndGame();
                //end.gameOver;
            }

            else

            Console.ReadLine();


        }

       
    }
}
