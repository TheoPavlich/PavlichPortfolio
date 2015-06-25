using FlooringUI.Workflows;

namespace FlooringUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var order = new MainMenu();
            order.Execute();
        }
    }
}