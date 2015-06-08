using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RollTheDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int[] sumCount = new int[11];

            for (int i = 0; i < 100; i++)
            {
                int die1 = rand.Next(1, 7);
                int die2 = rand.Next(1, 7);
                //Console.Write("{0} ",die1+die2);
                for (int j = 2; j < 13; j++)
                {
                    if((die1+die2) == j)
                    {
                        sumCount[j - 2]++;
                    }
                }
            }

            for(int i = 0; i<11;i++)
            {
                int num = i + 2;
                Console.WriteLine("\nThe sum {0} appeared {1} time(s).",num,sumCount[i]);
            }
            Console.ReadLine();
        }
    }
}
