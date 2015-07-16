using System;

namespace SGBank.UI.Utilities
{
    public class UserInteractions
    {
        public static void PressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}