using System;

namespace Tlapohualli
{
    public static class Log
    {
        public static void Error(string message) => Print(ConsoleColor.Red, message);

        public static void Info(string message) => Print(ConsoleColor.White, message);

        public static void Success(string message) => Print(ConsoleColor.Green, message);

        private static void Print(ConsoleColor color, string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
