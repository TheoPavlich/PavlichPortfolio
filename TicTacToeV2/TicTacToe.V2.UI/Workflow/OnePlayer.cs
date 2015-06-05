using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using TicTacToe.BLL;

namespace TicTacToe.V2.UI.Workflow
{
    public class OnePlayer
    {
        public void Play()
        {
          /*  Person player = GetPlayerName();
            Console.WriteLine("Your computer overlord decided to let you go first.");
            Console.WriteLine("Enter a number 1 through 9 corresponding with your choice as shown on the board.");

            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Board.GameArray[0], Board.GameArray[1], Board.GameArray[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Board.GameArray[3], Board.GameArray[4], Board.GameArray[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Board.GameArray[6], Board.GameArray[7], Board.GameArray[8]);
            Console.WriteLine("     |     |      ");

            Console.WriteLine("What is your choice, {0}", player.Name);
            Console.ReadLine();*/
            
        }

        private Person GetPlayerName()
        {
            Person newPlayer = new Person();

            Console.WriteLine("What is your fightin' name, Player 1?");
            newPlayer.Name = Console.ReadLine();
            newPlayer.Symbol = "X";

            return newPlayer;
        }


    }
}