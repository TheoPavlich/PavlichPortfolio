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
        public void SetupBoards(Player player1,Player player2)
        {
            Board p1Board = new Board();
            Board p2Board = new Board();


            for(int i = 0; i<5; i++)
            {
                PrintShipSetupBoard(player1);
                PlaceShips(player1, p1Board, i);
                UpdateShipSetupBoard();
            }

            for (int i = 0; i < 5; i++)
            {
                PrintShipSetupBoard(player2);
                PlaceShips(player2, p2Board, i);
                UpdateShipSetupBoard();
            }
        }

        private void UpdateShipSetupBoard()
        {
            throw new NotImplementedException();
        }

        private void PrintShipSetupBoard(Player player)
        {
            foreach (string s in player.ShipSetup)
            {
                Console.Write(s);
            }
            Console.WriteLine("\n\n");
        }

        private void PlaceShips(Player player, Board board, int type)
        {

            PlaceShipRequest shipRequest = new PlaceShipRequest();
            //int type determines ship type
            switch (type)
            {
                case 0:
                    shipRequest.ShipType = ShipType.Submarine;
                    break;
                case 1:
                    shipRequest.ShipType = ShipType.Destroyer;
                    break;
                case 2:
                    shipRequest.ShipType = ShipType.Cruiser;
                    break;
                case 3:
                    shipRequest.ShipType = ShipType.Carrier;
                    break;
                default:
                    shipRequest.ShipType = ShipType.Battleship;
                    break;

            }
            Console.WriteLine("{1}, please enter coordinates for your {0}: ",shipRequest.ShipType,player.Name);

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
                        Console.WriteLine("That wasn't a valid suggestion. Please try again.");
                        break;

                }
            } while (!dirSet);
            
            board.PlaceShip(shipRequest);
        }

    }
}
