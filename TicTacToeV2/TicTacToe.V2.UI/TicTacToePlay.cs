using System;
using TicTacToe.V2.UI.Workflow;

/*
 * ***** Tic-Tac-Toe *****

Create a Tic-Tac-Toe game that the user can play in the console.
The game should be turn based so that two players can compete against one another.

Requirements
	
	- Player 1 will be prompted by name to select a location to place their mark.
	- The board will be re-drawn and show the location they selected marked with an X  (O for player 2).
	- At the end of each turn you will need to check for a winner or tie.
	- If a winner is found, display a victory message.
	- If a tie is found, indicate that to the user.
	
*This should be built with a Console project to serve as our UI, a Class Library to serve as the game logic,
and a Class Library to serve as our unit tests for the game logic.*/

namespace TicTacToe.V2.UI
{
    public class TicTacToePlay
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to Tic Tac Toe with the SWC Guild!\n");
            var game = new GameStart();

            game.StartPlay();
        }
    }
}