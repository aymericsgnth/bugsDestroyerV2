using System;

namespace BugsDestroyer
{
    /*
     * Thibaud Hegelbach, Aymeric Siegenthaler, Yoann Meier, Alexandre Babich
     * Program.cs
     * Main file of program
     * Version 2.0
     * Original game has been taken here : https://github.com/AlecInfo/BugsDestroyer
     */
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
