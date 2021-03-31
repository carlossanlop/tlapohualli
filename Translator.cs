using System.Text;

namespace Tlapohualli
{
    public static class Translator
    {
        private static readonly int MaxDivider = 160000;

        private static StringBuilder translation = new StringBuilder();

        public static readonly int MinNumber = 0;
        public static readonly int MaxNumber = (MaxDivider * 20) - 1;

        /// <summary>
        /// Translates an integer to its nahuatl name.
        /// </summary>
        /// <param name="number">An integer between MinNumber and MaxNumber.</param>
        /// <returns>The translation of the number.</returns>
        public static string Translate(int number)
        {
            translation.Clear();
            return Translate(number, MaxDivider).ToString();
        }

        /// <summary>
        /// Translates an integer to its nahuatl name.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <param name="divider">The largest known possible divider.</param>
        /// <returns>A string with the translated number.</returns>
        private static StringBuilder Translate(int number, int divider)
        {
            // If it's a basic number, a valid string will be returned
            var basicNumber = GetName(number);
            if (basicNumber != string.Empty)
                translation.Append(basicNumber);
            else
            {
                switch (number)
                {
                    case > 20:
                        {
                            int multiples = number / divider;
                            int residue = number % divider;

                            // Avoid prepending the multiplier "ce <number>"
                            // do the whole process if there are multiples left to analyze
                            if (multiples > 1)
                                Translate(multiples, divider / 20);
                            // Print the actual number if it is a multiple of the divider
                            if (multiples > 0)
                            {
                                translation.Append(GetSpacedName(divider));
                                // Only print huan if the current multiplier could be printed and there is a residue
                                if (residue > 0)
                                    translation.Append("huan ");
                            }
                            // Process the rest of the number
                            if (residue > 0)
                                Translate(residue, divider / 20);
                        }
                        break;
                    case >= 15 and <= 19:
                        {
                            int residue = number % 15;
                            translation.Append(GetSpacedName(15));
                            if (residue > 0)
                                translation.Append(GetSpacedName(residue));
                        }
                        break;
                    case >= 10 and <= 14:
                        {
                            int residue = number % 10;
                            translation.Append(GetSpacedName(10));
                            if (residue > 0)
                                translation.Append(GetSpacedName(residue));
                        }
                        break;
                    case > 0 and < 10:
                        translation.Append(GetSpacedName(number));
                        break;

                }
            }
            return translation;
        }

        /// <summary>
        /// Returns the nahuatl string name of the passed number.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <returns>A string with the translated number.</returns>
        private static string GetName(int number) =>
            number switch
            {
                160000 => "xochiti",
                8000 => "xiquipilli",
                400 => "cenzontli",
                20 => "cempohualli",
                15 => "caxtollin",
                10 => "mahtlahtli",
                9 => "chicnahui",
                8 => "chicuei",
                7 => "chicome",
                6 => "chicuace",
                5 => "macuilli",
                4 => "nahui",
                3 => "yei",
                2 => "ome",
                1 => "ce",
                0 => "amitla",
                _ => string.Empty,
            };

        /// <summary>
        /// Returns the translation of the number with a space at the end.
        /// </summary>
        /// <param name="number">A number in the acceptable range.</param>
        /// <returns>A string with the translation and a space.</returns>
        private static string GetSpacedName(int number) => GetName(number) + " ";
    }
}
