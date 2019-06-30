using System;

namespace Tlapohualli
{
    /// <summary>
    /// This C# program allows you to convert integer number names (base 10) to their Nahuatl translation (base 20).
    /// </summary>
    class Program
    {
        #region Private members

        private static readonly string Quit = "quit";
        private static readonly string Instructions = $"Must be a number between {Translator.MinNumber} and {Translator.MaxNumber}.";

        #endregion


        #region Public methods

        public static void Main()
        {
            Log.Info("-----------------");
            Log.Info("-- TLAPOHUALLI --");
            Log.Info("-----------------");
            Log.Info("Type an number to get its Nahuatl name.");
            Log.Info($"Type '{Quit}' to exit program.");
            Log.Info(Instructions);

            string selection = string.Empty;
            int number = 0;
            while (selection.ToLowerInvariant() != Quit)
            {
                Console.Write("Number: ");
                selection = Console.ReadLine();
                if (!int.TryParse(selection, out number))
                {
                    Log.Error($"{Instructions}");
                    number = -1;
                }
                else if (number >= Translator.MinNumber && number <= Translator.MaxNumber)
                {
                    string translation = Translator.Translate(number);
                    Log.Success($"Nahuatl: {translation}");
                }
                else
                {
                    Log.Error($"{Instructions}");
                    number = -1;
                }
            }

            Log.Info("Goodbye!");
        }

        #endregion
    }
}

