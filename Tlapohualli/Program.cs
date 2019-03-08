#region Using directives

using System;
using System.Linq;

#endregion

namespace Tlapohualli
{
    /// <summary>
    /// This C# program allows you to convert integer number names (base 10) to their Nahuatl translation (base 20).
    /// </summary>
    class Program
    {
        #region Private members

        private static readonly int MaxDivider = 160000;
        private static readonly int MinNumber  = 0;
        private static readonly int MaxNumber  = (MaxDivider * 20) - 1;
        private static readonly string And = "huan ";

        #endregion

        #region Private methods

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
                    return "xochiti ";
                case 8000:
                    return "xiquipilli ";
                case 400:
                    return "cenzontli ";
                case 20:
                    return "cempohualli ";
                case 15:
                    return "caxtollin ";
                case 10:
                    return "mahtlahtli ";
                case 9:
                    return "chicnahui ";
                case 8:
                    return "chicuei ";
                case 7:
                    return "chicome ";
                case 6:
                    return "chicuace ";
                case 5:
                    return "macuilli ";
                case 4:
                    return "nahui ";
                case 3:
                    return "yei ";
                case 2:
                    return "ome ";
                case 1:
                    return "ce ";
                case 0:
                    return "amitla ";
                default:
                    break;
            }

            return string.Empty;
        }

        /// <summary>
        /// Translates an integer to its nahuatl name.
        /// </summary>
        /// <param name="number">The number to translate.</param>
        /// <param name="divider">The largest known possible divider.</param>
        /// <returns>A string with the translated number.</returns>
        private static string Translate(int number, int divider)
        {
            if (number == 0)
            {
                return GetName(0);
            }

            string name = string.Empty;
            int multiples;
            int residue;
            if (number >= 20 && number <= MaxNumber)
            {
                multiples = number / divider;
                residue = number % divider;

                // avoid prepending the multiplier "ce <number>"
                if (multiples > 1)
                {
                    name += Translate(multiples, divider / 20);
                }
                // Print the actual number if it is a multiple of the divider
                if (multiples > 0)
                {
                    name += GetName(divider);
                    // Only print huan if the current multiplier could be printed and there is a residue
                    if (residue > 0)
                    {
                        name += And;
                    }
                }
                // Process the rest of the number
                if (residue > 0)
                {
                    name += Translate(residue, divider / 20);
                }
            }
            // Special case for 15 - 19
            else if (number >= 15)
            {
                residue = number % 15;
                name += GetName(15);
                if (residue > 0)
                {
                    name += GetName(residue);
                }
            }
            // Special case for 10 - 14
            else if (number >= 10)
            {
                residue = number % 10;
                name += GetName(10);
                if (residue > 0)
                {
                    name += GetName(residue);
                }
            }
            // 1 - 9 can be printed directly
            else if (number > 0 && number < 10)
            {
                name += GetName(number);
            }

            return name;
        }

        #endregion

        #region Public methods

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("-- TLAPOHUALLI --");
            Console.WriteLine("-----------------");
            Console.WriteLine("Type an integer ({0} >= 0 <= {1}) to get its Nahuatl name. Type anything else to exit.", MinNumber, MaxNumber);
            int number;
            do
            {
                Console.Write("Number:  ");
                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
                Console.WriteLine("Nahuatl: {1}", number, Translate(number, MaxDivider));
            }
            while (number >= MinNumber && number <= MaxNumber);
            Console.WriteLine("Goodbye!");
        }

        #endregion
    }
}

