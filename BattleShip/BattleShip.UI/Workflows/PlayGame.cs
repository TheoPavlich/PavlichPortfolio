using System;
using BattleShip.BLL;

namespace BattleShip.UI.Workflows
{
    internal class PlayGame
    {
        public void Play(Player player1, Player player2)
        {
            var newSetUp = new SetupGame();

            var p1Board = newSetUp.SetupBoard(player1);
            newSetUp.PrintShipSetupBoard(player1);
            Console.WriteLine("Press enter to clear the screen and continue for {0}'s setup", player2.Name);
            Console.ReadLine();
            Console.Clear();

            var p2Board = newSetUp.SetupBoard(player2);
            newSetUp.PrintShipSetupBoard(player2);
            Console.WriteLine("Press enter to clear the screen and start playing!");
            Console.ReadLine();
            Console.Clear();

            var turn = new PlayerTurn();
            var currentPlayer = player1;
            var currentBoard = p2Board;
            var opponent = player2;

            bool gameOver;

            do
            {
                gameOver = turn.PlayTurn(currentPlayer, currentBoard);
                currentPlayer = currentPlayer == player1 ? player2 : player1;
                currentBoard = currentBoard == p2Board ? p1Board : p2Board;
                opponent = opponent == player2 ? player1 : player2;
            } while (!gameOver);

            GameOver(opponent, currentPlayer);
        }

        public void GameOver(Player winner, Player loser)
        {
            Console.WriteLine("Congratulations {0}, you beat {1}! How about a rematch? ", winner.Name, loser.Name);
            Console.WriteLine("\"P\"lay again \n \"Q\"uit");
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                var response = readLine.ToUpper();
                switch (response)
                {
                    case "P":
                        var newGame = new GameStart();
                        newGame.StartGame();
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("That is not a valid selection. Please press enter and try again.");
                        break;
                }
            }
        }
    }
}