using System;

namespace GameDevProject_2021
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = Game1.getInstance())
                game.Run();
        }
    }
}
