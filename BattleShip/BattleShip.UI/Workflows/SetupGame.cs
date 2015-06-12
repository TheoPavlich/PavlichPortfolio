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
    public class SetupGame
    {
        public Board SetupBoard(Player player)
        {
            Board board = new Board();
           
            int i = 0;
            do
            {
                PrintShipSetupBoard(player);
                i = PlaceShips(player, board, i);
            } while (i < 5);
            return board;

        }

        public void UpdateShipSetupBoard(Player player, int length, int y, int x, string direction)
        {

            switch (direction)
            {
                case "UP":
                    for (int i = 0; i < length; i++)
                    {
                        player.ShipSetup[x, y] = "[S] ";
                        x--;
                    }
                    break;
                case "DOWN":
                    for (int i = 0; i < length; i++)
                    {
                        player.ShipSetup[x, y] = "[S] ";
                        x++;
                    }
                    break;
                case "LEFT":
                    for (int i = 0; i < length; i++)
                    {
                        player.ShipSetup[x, y] = "[S] ";
                        y--;
                    }
                    break;
                case "RIGHT":
                    for (int i = 0; i < length; i++)
                    {
                        player.ShipSetup[x, y] = "[S] ";
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

        private int PlaceShips(Player player, Board board, int type)
        {

            PlaceShipRequest shipRequest = new PlaceShipRequest();
            
            //int type determines ship type
            int shipIndex = type;
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
                        break;

                    case "2":
                        shipRequest.Direction = ShipDirection.Down;
                        dirSet = true;
                        break;

                    case "3":
                        shipRequest.Direction = ShipDirection.Left;
                        dirSet = true;
                        break;

                    case "4":
                        shipRequest.Direction = ShipDirection.Right;
                        dirSet = true;
                        break;

                    default:
                        dirSet = false;
                        Console.WriteLine("That wasn't a valid selection. Please try again.");
                        break;

                }
            } while (!dirSet);

            
            var result = board.PlaceShip(shipRequest);
            if (result == ShipPlacement.Ok)
            {
                UpdateShipSetupBoard(player, length, coordX, coordY, shipRequest.Direction.ToString().ToUpper());
                shipIndex++;
            }
            Console.WriteLine("{0}", result);
            return shipIndex;

        }
    }
}
