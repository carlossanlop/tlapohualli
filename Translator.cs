namespace Tlapohualli
{
    public static class Translator
    {
        private static readonly int MaxDivider = 160000;

        public static readonly int MinNumber = 0;
        public static readonly int MaxNumber = (MaxDivider * 20) - 1;

        /// <summary>
        /// Translates an integer to its nahuatl name.
        /// </summary>
        /// <param name="number">An integer between MinNumber and MaxNumber.</param>
        /// <returns>The translation of the number.</returns>
        public static string Translate(int number) => Translate(number, MaxDivider);

        /// <summary>
        /// Translates an integer to its nahuatl name.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <param name="divider">The largest known possible divider.</param>
        /// <returns>A string with the translated number.</returns>
        private static string Translate(int number, int divider)
        {
            // If it's a basic number, a valid string will be returned
            string name = GetName(number);

            // If it's not a base number, do the whole process
            if (string.IsNullOrWhiteSpace(name))
            {
                // Basic algorithm if the number is above or equal to 20
                name += TranslateIfTwentyAndAbove(number, divider);
                // Special case if between 15 - 19
                name += TranslateIfInHigherTeens(number);
                // Special case if between 10 - 14
                name += TranslateIfInLowerTeens(number);
                // Special case if non-zero single digit
                name += TranslateIfSingleDigit(number);
            }

            return name;
        }

        /// <summary>
        /// Returns the nahuatl string name of the passed number.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <returns>A string with the translated number.</returns>
        private static string GetName(int number)
        {
            switch (number)
            {
                case 160000:
                    return "xochiti";
                case 8000:
                    return "xiquipilli";
                case 400:
                    return "cenzontli";
                case 20:
                    return "cempohualli";
                case 15:
                    return "caxtollin";
                case 10:
                    return "mahtlahtli";
                case 9:
                    return "chicnahui";
                case 8:
                    return "chicuei";
                case 7:
                    return "chicome";
                case 6:
                    return "chicuace";
                case 5:
                    return "macuilli";
                case 4:
                    return "nahui";
                case 3:
                    return "yei";
                case 2:
                    return "ome";
                case 1:
                    return "ce";
                case 0:
                    return "amitla";
                default:
                    break;
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns the translation of the number with a space at the end.
        /// </summary>
        /// <param name="number">A number in the acceptable range.</param>
        /// <returns>A string with the translation and a space.</returns>
        private static string GetSpacedName(int number) => GetName(number) + " ";

        /// <summary>
        /// If the passed number is between twenty and MaxNumber, translates it.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <param name="divider">The divider currently being analyzed.</param>
        /// <returns>The translated number if in the range, otherwise empty string.</returns>
        private static string TranslateIfTwentyAndAbove(int number, int divider)
        {
            string name = string.Empty;

            if (number >= 20 && number <= MaxNumber)
            {
                int multiples = number / divider;
                int residue = number % divider;

                // avoid prepending the multiplier "ce <number>"
                // do the whole process if there are multiples left to analyze
                if (multiples > 1)
                {
                    name += Translate(multiples, divider / 20);
                }

                // Print the actual number if it is a multiple of the divider
                if (multiples > 0)
                {
                    name += GetSpacedName(divider);

                    // Only print huan if the current multiplier could be printed and there is a residue
                    if (residue > 0)
                    {
                        name += "huan ";
                    }
                }

                // Process the rest of the number
                if (residue > 0)
                {
                    name += Translate(residue, divider / 20);
                }
            }

            return name;
        }

        /// <summary>
        /// Gets the translation of the passed number if it's between 15 and 19.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <returns>The translated number if in the range, otherwise empty string.</returns>
        private static string TranslateIfInHigherTeens(int number)
        {
            string name = string.Empty;

            if (number >= 15 && number <= 19)
            {
                int residue = number % 15;
                name = GetSpacedName(15);
                if (residue > 0)
                {
                    name += GetSpacedName(residue);
                }
            }

            return name;
        }

        /// <summary>
        /// Gets the translation of the number if it's between 10 and 14.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <returns>The translated number if in the range, otherwise empty string.</returns>
        private static string TranslateIfInLowerTeens(int number)
        {
            string name = string.Empty;

            if (number >= 10 && number <= 14)
            {
                int residue = number % 10;
                name = GetSpacedName(10);
                if (residue > 0)
                {
                    name += GetSpacedName(residue);
                }
            }

            return name;
        }

        /// <summary>
        /// Gets the translation of the number if it's between 1 and 9.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <returns>The translated number if in the range, otherwise empty string.</returns>
        private static string TranslateIfSingleDigit(int number)
        {
            string name = string.Empty;

            if (number > 0 && number < 10)
            {
                name = GetSpacedName(number);
            }

            return name;
        }
    }
}
