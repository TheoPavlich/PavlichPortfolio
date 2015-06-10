﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Responses;

namespace BattleShip.UI.Workflows
{
    class PlayerTurn
    {
        private void PrintDisplayBoard(Player currentPlayer)
        {
            foreach (string s in currentPlayer.DisplayBoard)
            {
                Console.Write(s);
            }
            Console.WriteLine("\n\n");
        }

        private void CurrentPlayerTurn(Player currentPlayer)
        {
            //Console.WriteLine("");
        }
    }
}