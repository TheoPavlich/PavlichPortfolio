using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringUI.Workflows;

namespace FlooringUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu order = new MainMenu();
            order.Execute();
        }
    }
}
