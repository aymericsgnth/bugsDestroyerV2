using System;

namespace BugsDestroyer
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Game1 game = null;
            while (Globals.gameIsRunning)
            {
                if (game != null)
                {
                    game.Dispose();
                }
                game = new Game1();
                game.Run();
            }
        }
    }
}
