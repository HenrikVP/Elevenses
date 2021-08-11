using System;

namespace Elevenses
{
    class Elevenses
    {
        const int AI_DECIDER = 3;
        private Random rnd = new Random();
        private int hiddenDice = 0, playerTotal = 0, aiTotal = 0;
        private bool playerStops, aiStops;

        public bool Game()
        {
            Console.WriteLine(
                "This is a game of chance. In order to win you \n" +
                "have to come closest to 11 against an AI.\n" +
                "(Sort of like Blackjack, with a 6-sided dice)\n" +
                "The first die is hidden from the AI.\n");

            Console.Write("Your hidden dice was ");
            hiddenDice = Dice();
            playerTotal += hiddenDice;

            while (playerTotal < 12 && !playerStops) PlayerTurn();

            if (playerTotal > 11)
            {
                Console.WriteLine(". Your total was above 11, and you lost.");
                Console.ReadKey(true);
                return false;
            }

            Console.WriteLine("Now it's the AIs turn");
            while (aiTotal < 12 && !aiStops) AITurn();

            return WhosWinning();
        }

        private void PlayerTurn()
        {
            Console.WriteLine(". Hit again? (y/n)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                Console.Write("You hit a ");
                playerTotal += Dice();
                Console.Write(". Your total is " + playerTotal);
            }
            else playerStops = true;
        }

        private void AITurn()
        {
            Console.Write("AI hits ");
            //int dice = ;
            aiTotal += Dice();
            Console.Write(". AIs total is " + aiTotal);
            int possible = playerTotal - hiddenDice + AI_DECIDER;

            if (possible > aiTotal && possible < 12)
            {
                Console.WriteLine(". AI continues.");
                Console.ReadKey(true);
            }
            //if (aiTotal > 9 && playerVisible < 9) aiStops = true;
            else aiStops = true;
        }
        private int Dice()
        {
            int dice = rnd.Next(1, 6);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(dice);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            return dice;
        }
        private bool WhosWinning()
        {
            if (aiTotal > 11)
            {
                Console.WriteLine(". AI total was above 11, and lost");
                Console.ReadKey(true);
                return true;
            }
            else if (playerTotal > aiTotal)
            {
                Console.Write(". AI stops at " + aiTotal);
                Console.WriteLine(". You had " + playerTotal);
                Console.WriteLine("You win!!!");
                Console.ReadKey(true);
                return true;
            }
            else
            {
                Console.Write(". AI stops at " + aiTotal);
                Console.WriteLine(". You had " + playerTotal);
                Console.WriteLine("AI win!");
                Console.ReadKey(true);
                return false;
            }
        }
    }
}
