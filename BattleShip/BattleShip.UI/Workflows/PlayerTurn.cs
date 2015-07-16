using System;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI.Workflows
{
    internal class PlayerTurn
    {
        public bool PlayTurn(Player player, Board board)
        {
            PrintDisplayBoard(player);
            var endGame = PlayerShot(player, board);
            Console.Clear();
            return endGame;
        }

        private void PrintDisplayBoard(Player player)
        {
            foreach (var s in player.DisplayBoard)
            {
                if (s == "[M] ")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (s == "[H] ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(s);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n\n");
        }

        private void UpdateDisplayBoard(Player player, ShotStatus shotStatus, int y, int x)
        {
            //Updates display board, does not reprint before end of turn
            //Shows yellow M for miss and red H for hit
            //Also needs shot response input
            //can add logic for sunk ship

            if (shotStatus == ShotStatus.Miss)
            {
                player.DisplayBoard[x, y] = "[M] ";
            }
            else if (shotStatus == ShotStatus.Hit || shotStatus == ShotStatus.HitAndSunk)
            {
                player.DisplayBoard[x, y] = "[H] ";
            }
        }

        private bool PlayerShot(Player player, Board board)
        {
            bool validResponse;
            int inputX;
            int inputY;
            ShotStatus response;

            do
            {
                Console.WriteLine("{0}, enter coordinates for your shot (ie A2): ", player.Name);
                var coords = Console.ReadLine();
                var xLetter = new TranslateLetter();

                inputX = xLetter.ConvertLetters[coords.Substring(0, 1).ToUpper()];
                //if (int.Parse(coords.Substring(1)) < 11 || int.Parse(coords.Substring(1)) > 0)
                //{
                inputY = int.Parse(coords.Substring(1));
                //}

                var coordinate = new Coordinate(inputX, inputY);

                var shotFire = board.FireShot(coordinate);
                response = shotFire.ShotStatus;
                var responseText = response.ToString();
                Console.WriteLine(response);


                switch (responseText)
                {
                    case "Duplicate":
                        Console.WriteLine("You have already fired at that coordinate. Enter new coordinate.");
                        validResponse = false;
                        break;
                    case "Invalid":
                        Console.WriteLine("That is an invalid coordinate. Enter new coordinate.");
                        validResponse = false;
                        break;
                    case "Hit":
                        Console.WriteLine("You hit something!");
                        validResponse = true;
                        break;

                    case "HitAndSunk":
                        Console.WriteLine("You sank your opponent's {0}", shotFire.ShipImpacted);
                        validResponse = true;
                        break;
                    case "Miss":
                        Console.WriteLine("Your projectile splashes into the ocean, you missed!");
                        validResponse = true;
                        break;

                    default:
                        validResponse = true;
                        break;
                }
            } while (validResponse == false);

            UpdateDisplayBoard(player, response, inputX, inputY);
            Console.ReadLine();

            if (response == ShotStatus.Victory)
            {
                return true;
            }
            return false;
        }
    }
}