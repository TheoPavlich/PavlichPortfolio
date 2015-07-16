using System;
using TicTacToe.BLL;

namespace TicTacToe.V2.UI.Workflow
{
    public class TwoPlayers
    {
        public void SetupPlay()
        {
            Console.WriteLine("You have a friend!\n");
            Console.WriteLine("Welcome to TicTacToe Two Player Mode!!\n");

            var player1 = CreateNewPlayer("Player 1", "X");
            var player2 = CreateNewPlayer("Player 2", "O");

            PlayGame(player1, player2);

            Console.ReadLine();
        }

        private Board CreateNewBoardArray(string owner, string[] bArray)
        {
            var newBoard = new Board
            {
                BoardArray = bArray,
                BoardName = owner
            };

            return newBoard;
        }

        public void PlayGame(Person one, Person two)
        {
            var gameBoard = CreateNewBoardArray("Game", new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"});
            var pOneBoard = CreateNewBoardArray(one.Name, new string[9]);
            var pTwoBoard = CreateNewBoardArray(two.Name, new string[9]);

            Console.WriteLine("{0}, let's start with you!\n", one.Name);
            Console.Clear();

            var currentPlayer = one;
            var currentBoard = pOneBoard;
            var win = false;
            var tie = false;

            while (!win && !tie)
            {
                Console.WriteLine("\nOkay, {0}, it's your turn.\n", currentPlayer.Name);
                Console.WriteLine("Enter a number 1 through 9 corresponding with your choice as shown on the board.");

                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", gameBoard.BoardArray[0], gameBoard.BoardArray[1],
                    gameBoard.BoardArray[2]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", gameBoard.BoardArray[3], gameBoard.BoardArray[4],
                    gameBoard.BoardArray[5]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", gameBoard.BoardArray[6], gameBoard.BoardArray[7],
                    gameBoard.BoardArray[8]);
                Console.WriteLine("     |     |      ");

                var playerChoice = Console.ReadLine();

                var valid = CheckForValidChoice(playerChoice, gameBoard, currentPlayer);
                if (!valid)
                {
                    Console.WriteLine("That isn't a valid choice, {0}. How about you try again?", currentPlayer.Name);
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                win = IsWinner(gameBoard, currentPlayer);
                tie = IsDraw(gameBoard);
                currentPlayer = currentPlayer == one ? two : one;
                currentBoard = currentBoard == pOneBoard ? pTwoBoard : pOneBoard;
                Console.Clear();
            }

            if (tie)
            {
                Console.WriteLine("Oh no! It's a tie! (Press enter to return to menu) ");
                Console.ReadLine();
            }

            if (win)
            {
                Console.WriteLine("We have a winner!");
                Console.WriteLine(" {0} won this time. Sorry, {1}, better luck next time!", one.Name, two.Name);
                Console.WriteLine("(Press enter to return to menu) ");
            }
        }

        private bool CheckForValidChoice(string playerChoice, Board gameBoard, Person currentPlayer)
        {
            var validChoice = false;
            for (var i = 0; i < 9; i++)
            {
                if (gameBoard.BoardArray[i] == playerChoice)
                {
                    gameBoard.BoardArray[i] = currentPlayer.Symbol;
                    validChoice = true;
                }
            }
            return validChoice;
        }

        public Person CreateNewPlayer(string playerNum, string xOrO)
        {
            var newPlayer = new Person();

            Console.WriteLine("\nWhat is your fightin' name, {0}?", playerNum);
            newPlayer.Name = Console.ReadLine();
            newPlayer.Symbol = xOrO;
            newPlayer.Choices = new int[9];

            return newPlayer;
        }

        public bool IsWinner(Board game, Person current)
        {
            var win = new Outcomes();
            var isWin = win.CheckWinner(game.BoardArray, current.Symbol);
            return isWin;
        }

        public bool IsDraw(Board gameBoard)
        {
            var tie = new Outcomes();
            var isDraw = tie.CheckTie(gameBoard.BoardArray);
            return isDraw;
        }
    }
}