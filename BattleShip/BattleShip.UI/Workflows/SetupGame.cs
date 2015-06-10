using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI.Workflows
{
    public class SetupGame
    {
        public Board SetupBoard(Player player1)
        {
            Board board = new Board();
           // Board p2Board = new Board();


            for(int i = 0; i<5; i++)
            {
                PrintShipSetupBoard(player1);
                PlaceShips(player1, board, i);
            }
            return board;

        }

        public void UpdateShipSetupBoard(Player player, int length, int x, int y, string direction)
        {

            switch (direction)
            {
                case "UP":
                    for (int i = 0; i < length; i++)
                    {
                        player.DisplayBoard[x, y] = "[S] ";
                        x--;
                    }
                    break;
                case "DOWN":
                    for (int i = 0; i < length; i++)
                    {
                        player.DisplayBoard[x, y] = "[S] ";
                        x++;
                    }
                    break;
                case "LEFT":
                    for (int i = 0; i < length; i++)
                    {
                        player.DisplayBoard[x, y] = "[S] ";
                        y--;
                    }
                    break;
                case "RIGHT":
                    for (int i = 0; i < length; i++)
                    {
                        player.DisplayBoard[x, y] = "[S] ";
                        y++;
                    }
                    break;
            }

        }

        public void PrintShipSetupBoard(Player player)
        {
            foreach (string s in player.ShipSetup)
            {
                Console.Write(s);
                if (s == "[S] ")
                {
                    Console.BackgroundColor=ConsoleColor.Blue;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\n\n");
        }

        private void PlaceShips(Player player, Board board, int type)
        {

            PlaceShipRequest shipRequest = new PlaceShipRequest();
            //int type determines ship type
            int length = 0;
            switch (type)
            {
                case 0:
                    shipRequest.ShipType = ShipType.Submarine;
                    length = 3;
                    break;
                case 1:
                    shipRequest.ShipType = ShipType.Destroyer;
                    length = 2;
                    break;
                case 2:
                    shipRequest.ShipType = ShipType.Cruiser;
                    length = 3;
                    break;
                case 3:
                    shipRequest.ShipType = ShipType.Carrier;
                    length = 5;
                    break;
                default:
                    shipRequest.ShipType = ShipType.Battleship;
                    length = 4;
                    break;

            }

            Console.WriteLine("{1}, please enter coordinates for your {0} of length {2} (ie. A1): ",shipRequest.ShipType,player.Name, length);

            //Set Coordinates
            string coords = Console.ReadLine();
            TranslateLetter xLetter = new TranslateLetter();

            int coordX = xLetter.ConvertLetters[coords.Substring(0, 1).ToUpper()];
            int coordY = Int32.Parse(coords.Substring(1));
            shipRequest.Coordinate = new Coordinate(coordX, coordY);

            //Set direction;
            bool dirSet;
            do
            {
                Console.WriteLine("Select direction:\n1.Up\t2.Down\t3.Left\t4.Right");
                string dir = Console.ReadLine();
                switch (dir)
                {
                    case "1":
                        shipRequest.Direction = ShipDirection.Up;
                        dirSet = true;
                        UpdateShipSetupBoard(player, length, coordX, coordY, "UP");
                        break;

                    case "2":
                        shipRequest.Direction = ShipDirection.Down;
                        dirSet = true;
                        UpdateShipSetupBoard(player, length, coordX, coordY, "DOWN");
                        break;

                    case "3":
                        shipRequest.Direction = ShipDirection.Left;
                        dirSet = true;
                        UpdateShipSetupBoard(player, length, coordX, coordY, "LEFT");
                        break;

                    case "4":
                        shipRequest.Direction = ShipDirection.Right;
                        dirSet = true;
                        UpdateShipSetupBoard(player, length, coordX, coordY, "RIGHT");
                        break;

                    default:
                        dirSet = false;
                        Console.WriteLine("That wasn't a valid suggestion. Please try again.");
                        break;

                }
            } while (!dirSet);
            
            board.PlaceShip(shipRequest);
        }

    }
}
