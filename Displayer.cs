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

/*
Now that this place is so empty i can write notes and reminders for me to make this release 1.1
add question whether to or not encrypt the file youre making, and maybe add encrypting a file on its own later.
for decrypting, the files should have hashes so can confirm whether they have correct passwords or not
add options for selecting what encyrption type youd like
make current stuff work aswell
*/