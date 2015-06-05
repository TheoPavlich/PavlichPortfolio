using System.Linq;

namespace TicTacToe.BLL
{
    public class Outcomes
     {
        public bool CheckWinner(string[] board, string playerSymbol)
        {
           
            bool won = false;

            int[] win1 = { 0, 1, 2 };
            int[] win2 = { 3, 4, 5 };
            int[] win3 = { 6, 7, 8 };
            int[] win4 = { 0, 3, 6 };
            int[] win5 = { 1, 4, 7 };
            int[] win6 = { 2, 5, 8 };
            int[] win7 = { 0, 4, 8 };
            int[] win8 = { 2, 4, 6 };

            int[][] winners = { win1, win2, win3, win4, win5, win6, win7, win8 };



            for (int i = 0; i < winners.Length; i++)
            {
                int[] a = winners[i];
                int winCount = 0;
                for (int j = 0; j < 3; j++)
                {
                    
                    int b = a[j];
                    if (board[b] == playerSymbol)
                    {
                        winCount++;
                    }
                    if (winCount == 3)
                    {
                        won = true;
                        return won;
                    }
                }
            }
            return won;


        }

        public bool CheckTie(string[] board)
        {
            return board.All(t => t == "X" || t == "O");
        }
     }
}

//bool won = false;
//int wonCount = 0;
//string[] checkWin = new string[3];
//string[] win1 = { "1", "2", "3" };
//string[] win2 = { "4", "5", "6" };
//string[] win3 = { "7", "8", "9" };
//string[] win4 = { "1", "4", "7" };
//string[] win5 = { "2", "5", "8" };
//string[] win6 = { "3", "6", "9" };
//string[] win7 = { "1", "5", "9" };
//string[] win8 = { "3", "5", "7" };
//string[][] winners = { win1, win2, win3, win4, win5, win6, win7, win8 };

//for (int i = 0; i < winners.Length; i++)
//{
//    for (int j = 0; j < 3; j++)
//    {
//        checkWin = winners[i];
//        for (int k = 0; k < ; k++)
//        {
//            if (checkWin[j] == playerBoard.BoardArray[k])
//            {
//                wonCount++;
//                if (wonCount > 3)
//                {
//                    won = true;
//                }
//            }
//        }
//    }
//}
//return won;