using System;

namespace Elevenses
{
    class Program
    {        
        static void Main(string[] args)
        {
            int playerScore = 0, aiScore = 0;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                Console.WriteLine($"Score: Player {playerScore} - AI {aiScore}");
                Console.WriteLine("Wanna play? (y/n)");
                bool won = false;
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    won = new Elevenses().Game();
                else Environment.Exit(0);
                if (won) playerScore++; else aiScore++;
            }
        }
    }
}
