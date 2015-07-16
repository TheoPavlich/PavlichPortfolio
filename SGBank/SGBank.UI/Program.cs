using SGBank.UI.Workflows;

namespace SGBank.UI
{
    internal class Program
    {
        private static void Main()
        {
            var mainMenu = new MainMenu();
            mainMenu.Execute();
        }
    }
}