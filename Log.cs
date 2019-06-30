using System;
using System.Collections.Generic;
using System.Text;

namespace Tlapohualli
{
    public static class Log
    {
        #region Public methods

        public static void Error(string message)
        {
            Print(ConsoleColor.Red, message);
        }

        public static void Info(string message)
        {
            Print(ConsoleColor.White, message);
        }

        public static void Success(string message)
        {
            Print(ConsoleColor.Green, message);
        }

        #endregion


        #region Private methods

        private static void Print(ConsoleColor color, string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }

        #endregion
    }
}
