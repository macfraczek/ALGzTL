using ALGzTL.Logger;
using System;
using System.Linq;

namespace ALGzTL
{
    class Program
    {
        static void Main(string[] args)
        {
           new Program().CongruenceCalculation();

        }

        string[] positiveAnswer = { "y", "yes", "t", "tak" };

        void CongruenceCalculation()
        {
            Console.Write("Czy chcesz otrzymac dodatkowe informacje o obliczeniach? ");
            string userInput = Console.ReadLine().ToLower();
            bool isAdditionalInfo = positiveAnswer.Any(s => s == userInput); 

            
            ModularArithmetic ma = new ModularArithmetic(isAdditionalInfo ? new ConsoleLogger() : null);

            while (true)
            {
                Console.WriteLine("Podaj kongruencje. Przykład: '49x = 1 mod 55'");
                userInput = Console.ReadLine().ToLower();
                try
                {
                    Console.WriteLine("RESULT: x = " + ma.ComputeCongruenceMinimalResult(userInput));
                } catch (Exception ex) {
                    Console.WriteLine($"ERROR. {ex.Message}");
                }

                Console.WriteLine("Czy chcesz obliczyc kolejne? ");
                userInput = Console.ReadLine().ToLower();
                bool doExit = !positiveAnswer.Any(s => s == userInput);
                if (doExit) break;
            }
        }

    }
}
