namespace BattleshipVersusTown
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Battleship v Town";
            const int MANTICORE_MAX_HEALTH = 10;
            const int CONSOLAS_MAX_HEALTH = 15;
            int manticoreHealth = MANTICORE_MAX_HEALTH;
            int consolasHealth = CONSOLAS_MAX_HEALTH;
            int round = 1;
            Console.Write("Player 1, how far from the city do you want to station the Manticore? ");
            int manticoreRange = ReadInput();
            int cannonRange = 0;
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Player 2, it is your turn");
            Console.WriteLine("-------------------------------------------");
            while (manticoreHealth > 0 && consolasHealth > 0)
            {
                Console.WriteLine($"STATUS: Round: {round} City: {consolasHealth}/{CONSOLAS_MAX_HEALTH} Manticore: {manticoreHealth}/{MANTICORE_MAX_HEALTH}");
                int currentDamage = CurrentRoundDamage(round);
                Console.WriteLine($"The cannon is expected to deal {currentDamage} damage this round.");
                Console.Write("Enter desired cannon range: ");
                cannonRange = ReadInput();
                EvaluateHit(manticoreRange, cannonRange, ref manticoreHealth, ref consolasHealth, currentDamage);
                Console.WriteLine("-------------------------------------------");
                round++;
            }
            if (manticoreHealth <= 0)
            {
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            }
            else if (consolasHealth <= 0)
            {
                Console.WriteLine("The town of Consolas has been destroyed! You have dishonored the entire unit!");
            }
        }
        /// <summary>
        /// This method evaluates wether the enemy ship has been hit or not, at the same time it decreases the HP of either ship and town according to the turn damage.
        /// </summary>
        /// <param name="manticoreRange"></param>
        /// <param name="cannonRange"></param>
        /// <param name="manticoreHealth"></param>
        /// <param name="consolasHealth"></param>
        /// <param name="currentDamage"></param>
        static void EvaluateHit(int manticoreRange, int cannonRange, ref int manticoreHealth, ref int consolasHealth, int currentDamage)
        {
            if (cannonRange == manticoreRange)
            {
                manticoreHealth -= currentDamage;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That round was a DIRECT HIT!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (cannonRange < manticoreRange)
            {
                consolasHealth -= 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("That round FELL SHORT of the target");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                consolasHealth -= 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("That round OVERSHOT the target");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// This method calculate the modulus to evaluate wether the current cannon damage is 1, 3, 5 or 15.
        /// </summary>
        /// <param name="Round"></param>
        /// <returns></returns>
        private static int CurrentRoundDamage(int round)
        {
            if (round % 3 == 0 && round % 5 == 0) return 15;
            else if (round % 3 == 0) return 3;
            else if (round % 5 == 0) return 5;
            else return 1;
        }
        private static int ReadInput()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
    }
}