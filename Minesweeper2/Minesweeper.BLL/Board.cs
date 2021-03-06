﻿using System;

namespace Minesweeper.BLL
{
    public class Board
    {
        public int[] EasyBoard()
        {
            var mines = new Mines();
            var mineArray = mines.GenerateMines(10, 64);
            var boardArray = new int[64];

            for (var i = 0; i < 10; i++)
            {
                var bomb = mineArray[i];
                boardArray[bomb] = 9;
            }
            for (var i = 0; i < 64; i++)
            {
                var count = 0;
                if (boardArray[i] == 9)
                {
                    continue;
                }
                if (i < 8)
                {
                    if (i == 0)
                    {
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i + 8] == 9)
                            count++;
                        if (boardArray[i + 9] == 9)
                            count++;
                    }
                    else if (i == 7)
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 7] == 9)
                            count++;
                        if (boardArray[i + 8] == 9)
                            count++;
                    }
                    else
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i + 7] == 9)
                            count++;
                        if (boardArray[i + 8] == 9)
                            count++;
                        if (boardArray[i + 9] == 9)
                            count++;
                    }
                }
                else if (i > 55)
                {
                    if (i == 56)
                    {
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i - 8] == 9)
                            count++;
                        if (boardArray[i - 7] == 9)
                            count++;
                    }
                    else if (i == 63)
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i - 8] == 9)
                            count++;
                        if (boardArray[i - 9] == 9)
                            count++;
                    }
                    else
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i - 7] == 9)
                            count++;
                        if (boardArray[i - 8] == 9)
                            count++;
                        if (boardArray[i - 9] == 9)
                            count++;
                    }
                }
                else if (i%8 == 0)
                {
                    if (boardArray[i - 8] == 9)
                        count++;
                    if (boardArray[i + 1] == 9)
                        count++;
                    if (boardArray[i - 7] == 9)
                        count++;
                    if (boardArray[i + 8] == 9)
                        count++;
                    if (boardArray[i + 9] == 9)
                        count++;
                }
                else if (i%8 == 7)
                {
                    if (boardArray[i - 1] == 9)
                        count++;
                    if (boardArray[i - 8] == 9)
                        count++;
                    if (boardArray[i - 9] == 9)
                        count++;
                    if (boardArray[i + 7] == 9)
                        count++;
                    if (boardArray[i + 8] == 9)
                        count++;
                }

                else
                {
                    if (boardArray[i - 1] == 9)
                        count++;
                    if (boardArray[i + 1] == 9)
                        count++;
                    if (boardArray[i + 7] == 9)
                        count++;
                    if (boardArray[i + 8] == 9)
                        count++;
                    if (boardArray[i + 9] == 9)
                        count++;
                    if (boardArray[i - 7] == 9)
                        count++;
                    if (boardArray[i - 8] == 9)
                        count++;
                    if (boardArray[i - 9] == 9)
                        count++;
                }
                boardArray[i] = count;
            }

            //Console.WriteLine("Board array looks like:\n");
            //for (int i = 0; i < 64; i++)
            //{

            //    Console.Write("{0} ", boardArray[i]);
            //    if((i+1)%8 ==0&&i!=0)
            //        Console.WriteLine();
            //}

            return boardArray;
        }

        public string[] EasyDisplay()
        {
            var displayArray = new string[64];

            for (var i = 0; i < 64; i++)
            {
                displayArray[i] = " []";
            }
            return displayArray;
        }

        public int[] MediumBoard()
        {
            var mines = new Mines();
            var mineArray = mines.GenerateMines(15, 144);
            var boardArray = new int[144];

            for (var i = 0; i < 15; i++)
            {
                var bomb = mineArray[i];
                boardArray[bomb] = 9;
            }
            for (var i = 0; i < 144; i++)
            {
                var count = 0;
                if (boardArray[i] == 9)
                {
                    continue;
                }
                if (i < 12)
                {
                    if (i == 0)
                    {
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i + 12] == 9)
                            count++;
                        if (boardArray[i + 13] == 9)
                            count++;
                    }
                    else if (i == 11)
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 11] == 9)
                            count++;
                        if (boardArray[i + 12] == 9)
                            count++;
                    }
                    else
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i + 11] == 9)
                            count++;
                        if (boardArray[i + 12] == 9)
                            count++;
                        if (boardArray[i + 13] == 9)
                            count++;
                    }
                }
                else if (i > 131)
                {
                    if (i == 132)
                    {
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i - 12] == 9)
                            count++;
                        if (boardArray[i - 11] == 9)
                            count++;
                    }
                    else if (i == 143)
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i - 12] == 9)
                            count++;
                        if (boardArray[i - 13] == 9)
                            count++;
                    }
                    else
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i - 11] == 9)
                            count++;
                        if (boardArray[i - 12] == 9)
                            count++;
                        if (boardArray[i - 13] == 9)
                            count++;
                    }
                }
                else if (i%12 == 0)
                {
                    if (boardArray[i - 12] == 9)
                        count++;
                    if (boardArray[i + 1] == 9)
                        count++;
                    if (boardArray[i - 11] == 9)
                        count++;
                    if (boardArray[i + 12] == 9)
                        count++;
                    if (boardArray[i + 13] == 9)
                        count++;
                }
                else if (i%12 == 11)
                {
                    if (boardArray[i - 1] == 9)
                        count++;
                    if (boardArray[i - 12] == 9)
                        count++;
                    if (boardArray[i - 13] == 9)
                        count++;
                    if (boardArray[i + 11] == 9)
                        count++;
                    if (boardArray[i + 12] == 9)
                        count++;
                }

                else
                {
                    if (boardArray[i - 1] == 9)
                        count++;
                    if (boardArray[i + 1] == 9)
                        count++;
                    if (boardArray[i + 11] == 9)
                        count++;
                    if (boardArray[i + 12] == 9)
                        count++;
                    if (boardArray[i + 13] == 9)
                        count++;
                    if (boardArray[i - 11] == 9)
                        count++;
                    if (boardArray[i - 12] == 9)
                        count++;
                    if (boardArray[i - 13] == 9)
                        count++;
                }
                boardArray[i] = count;
            }
            //Console.WriteLine("Board array looks like:\n");
            //for (int i = 0; i < 144; i++)
            //{

            //    Console.Write("{0} ", boardArray[i]);
            //    if ((i + 1) % 12 == 0 && i != 0)
            //        Console.WriteLine();
            //}
            //Console.ReadLine();
            return boardArray;
        }

        public string[] MediumDisplay()
        {
            var displayArray = new string[144];

            for (var i = 0; i < 144; i++)
            {
                displayArray[i] = " []";
            }

            return displayArray;
        }

        public int[] DifficultBoard()
        {
            var mines = new Mines();
            var mineArray = mines.GenerateMines(40, 256);
            var boardArray = new int[256];

            for (var i = 0; i < 40; i++)
            {
                var bomb = mineArray[i];
                boardArray[bomb] = 9;
            }
            for (var i = 0; i < 256; i++)
            {
                var count = 0;
                if (boardArray[i] == 9)
                {
                    continue;
                }
                if (i < 16)
                {
                    if (i == 0)
                    {
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i + 16] == 9)
                            count++;
                        if (boardArray[i + 17] == 9)
                            count++;
                    }
                    else if (i == 11)
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 15] == 9)
                            count++;
                        if (boardArray[i + 16] == 9)
                            count++;
                    }
                    else
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i + 15] == 9)
                            count++;
                        if (boardArray[i + 16] == 9)
                            count++;
                        if (boardArray[i + 17] == 9)
                            count++;
                    }
                }
                else if (i > 239)
                {
                    if (i == 140)
                    {
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i - 16] == 9)
                            count++;
                        if (boardArray[i - 15] == 9)
                            count++;
                    }
                    else if (i == 255)
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i - 16] == 9)
                            count++;
                        if (boardArray[i - 17] == 9)
                            count++;
                    }
                    else
                    {
                        if (boardArray[i - 1] == 9)
                            count++;
                        if (boardArray[i + 1] == 9)
                            count++;
                        if (boardArray[i - 15] == 9)
                            count++;
                        if (boardArray[i - 16] == 9)
                            count++;
                        if (boardArray[i - 17] == 9)
                            count++;
                    }
                }
                else if (i%16 == 0)
                {
                    if (boardArray[i - 16] == 9)
                        count++;
                    if (boardArray[i + 1] == 9)
                        count++;
                    if (boardArray[i - 15] == 9)
                        count++;
                    if (boardArray[i + 16] == 9)
                        count++;
                    if (boardArray[i + 17] == 9)
                        count++;
                }
                else if (i%16 == 15)
                {
                    if (boardArray[i - 1] == 9)
                        count++;
                    if (boardArray[i - 16] == 9)
                        count++;
                    if (boardArray[i - 17] == 9)
                        count++;
                    if (boardArray[i + 15] == 9)
                        count++;
                    if (boardArray[i + 16] == 9)
                        count++;
                }

                else
                {
                    if (boardArray[i - 1] == 9)
                        count++;
                    if (boardArray[i + 1] == 9)
                        count++;
                    if (boardArray[i + 15] == 9)
                        count++;
                    if (boardArray[i + 16] == 9)
                        count++;
                    if (boardArray[i + 17] == 9)
                        count++;
                    if (boardArray[i - 15] == 9)
                        count++;
                    if (boardArray[i - 16] == 9)
                        count++;
                    if (boardArray[i - 17] == 9)
                        count++;
                }
                boardArray[i] = count;
            }

            //Console.WriteLine("Board array looks like:\n");
            //for (int i = 0; i < 256; i++)
            //{

            //    Console.Write("{0} ", boardArray[i]);
            //    if ((i + 1) % 16 == 0 && i != 0)
            //        Console.WriteLine();
            //}
            //Console.ReadLine();
            return boardArray;
        }

        public string[] DifficultDisplay()
        {
            var displayArray = new string[256];
            Console.WriteLine("\nY");
            for (var i = 0; i < 256; i++)
            {
                displayArray[i] = " []";

                if (i%16 == 0)
                {
                    Console.Write(i/16 < 10 ? "\n{0} " : "\n{0}", (i/16));
                }
                Console.Write("{0}", displayArray[i]);
            }
            Console.WriteLine("\n    0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15  X");
            Console.ReadLine();
            return displayArray;
        }
    }
}