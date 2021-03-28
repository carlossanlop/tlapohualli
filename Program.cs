using System;

namespace Tlapohualli
{
    /// <summary>
    /// This program converts integer number names (base 10) to their Nahuatl translation (base 20).
    /// </summary>
    class Program
    {
        private static readonly string Quit = "quit";
        private static readonly string Instructions = $"Must be a number between {Translator.MinNumber} and {Translator.MaxNumber}.";

        public static void Main()
        {
            Log.Info("-----------------");
            Log.Info("-- TLAPOHUALLI --");
            Log.Info("-----------------");
            Log.Info("Type an number to get its Nahuatl name.");
            Log.Info($"Type '{Quit}' to exit program.");
            Log.Info(Instructions);

            string selection = string.Empty;
            while (selection.ToLowerInvariant() != Quit)
            {
                Console.Write("Number: ");
                selection = Console.ReadLine();
                if (!int.TryParse(selection, out int number))
                {
                    Log.Error($"{Instructions}");
                }
                else if (number >= Translator.MinNumber && number <= Translator.MaxNumber)
                {
                    string translation = Translator.Translate(number);
                    Log.Success($"Nahuatl: {translation}");
                }
                else
                {
                    Log.Error($"{Instructions}");
                }
            }

            Log.Info("Goodbye!");
        }
    }
}
