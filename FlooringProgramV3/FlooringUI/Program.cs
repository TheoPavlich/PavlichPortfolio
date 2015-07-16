using FlooringUI.Workflows;

namespace FlooringUI
{
    internal class Program
    {
        private static void Main()
        {
            var order = new MainMenu();
            order.Execute();
        }
    }
}