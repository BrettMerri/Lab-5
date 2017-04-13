using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Grand Circus Casino!";

            Random rnd = new Random();
            bool run = true;

            Console.WriteLine("Welcome to the Grand Circus Casino!");

            while (run)
            {
                Console.Write("Enter the number of sides for a pair of dice (from 3 to 12): ");

                string input = Console.ReadLine(); //Prompts user for integer input

                int sides = isValidInteger(input); //Validates if input is an integer and its between 3 and 12
                if (sides == -1) //Restarts application if an error has occurred
                {
                    Console.WriteLine();
                    continue;
                }

                int dye1 = randomNumber(sides, rnd);
                int dye2 = randomNumber(sides, rnd);

                Console.WriteLine(dye1);
                Console.WriteLine(dye2);
                Console.WriteLine();

                if (continueApp())
                {
                    continue;
                }
                else
                {
                    run = false;
                }
            }
        }
        public static int isValidInteger(string input)
        {
            int x;
            if (!int.TryParse(input, out x)) //Validates if user input is an integer
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Input not a number"); //Prompts error if input is not a number
                Console.ForegroundColor = ConsoleColor.Gray;
                return -1;
            }
            if (x < 3 || x > 12) //Validates if user input is between 3 and 12
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Input not between 3 and 12"); //Prompts error if input is not between 3 and 12
                Console.ForegroundColor = ConsoleColor.Gray;
                return -1;
            }
            return x;
        }
        public static int randomNumber(int sides, Random rnd)
        {
            int random = rnd.Next(1, ++sides); //Increment sides so that the max value is correct (its max value plus 1)
            return random;
        }
        public static bool continueApp()
        {
            while (true)
            {
                Console.Write("Continue? (y/n): "); //Prompts user if he wants to continue

                string continueString = Console.ReadLine().ToLower();

                if (continueString == "y")
                {
                    Console.WriteLine();
                    return true; //Continues application
                }
                else if (continueString == "n")
                {
                    return false; //Ends application
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not y or n."); //Prompts error if input is not Y or N
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
            }
        }
    }
}
