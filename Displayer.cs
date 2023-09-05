using System;

namespace System
{
    
public class Displayer
{
	public void WriteLine(string message, int speed = 80, ConsoleColor color = ConsoleColor.White)
	{
        ConsoleColor originalColor = Console.ForegroundColor;

        Console.ForegroundColor = color;

		for (int i = 0; i < message.Length; i++)
      {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(speed);
      }
      Console.ForegroundColor = originalColor;
      Console.WriteLine(); //add a new line at the end
	}
    	// In future add more stuff for help to render or visualise this shit
        // but what, hmmm :thonk:
}
}