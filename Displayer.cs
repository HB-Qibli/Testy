using System;
using System.Text;

namespace System
{

    public class Displayer
    {
        public void WriteLine(string message, int speed = 80, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            string[] lines = message.Split('\n'); // Split text into lines

            foreach (string line in lines)
            {
                foreach (char character in line)
                {
                    Console.Write(character);
                    System.Threading.Thread.Sleep(speed);
                }

                // Move to the next line
                Console.WriteLine();
            }

            Console.ForegroundColor = originalColor;
            Console.WriteLine();
        }


    }
}
