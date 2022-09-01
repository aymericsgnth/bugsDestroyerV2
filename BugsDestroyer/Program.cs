using System;

namespace BugsDestroyer
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Game1 game = null;
            do
            {
                if (game != null)
                {
                    game.Dispose();
                }
                Globals.gameShouldRestart = false;
                game = new Game1();
                game.Run();
               
            }
            while (Globals.gameShouldRestart);
        }
    }
}
