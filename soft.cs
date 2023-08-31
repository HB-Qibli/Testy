// Testy
using System;
using System.IO;
using System.Collections.Generic;


namespace System
{
class Testy
{
 static void Main(string[] args)
        {
            string answer; // first few lines here are prep
            bool run = true;
            int typespeed = 60;
            Storagehandler handl = new Storagehandler(); //honestly unnecesary, making it static would have been just fine as multiple instances wont ever be needed
			Displayer display = new Displayer(); // but ig to show teacher that the student is able to do this and understand what it does ig


            //do stuff here like welcome to this application and shit, maybe fancy with coloured text too

            do
            {
                display.WriteLine("Select a option by number: ", typespeed);
                display.WriteLine("1. Create a note", typespeed);
                display.WriteLine("2. Read saved notes", typespeed);
                display.WriteLine("3. delete notes", typespeed);
                display.WriteLine("4. help", typespeed);
                display.WriteLine("5. exit ", typespeed);
                display.WriteLine("Select option: ", typespeed);

                answer = Console.ReadLine();

                switch (answer) 
                {
                    case "1":
                    handl.CreateNote();
                    break;
                    
                    case "2":
                    handl.ViewNotesChapters();
                    display.WriteLine("Select chapter to read (case-senstive input): ", typespeed);
                    answer = Console.ReadLine(); // no need to make a second variable, saves mem, unless compiler re-uses a variable even when you write 2, dunno.
                    handl.ReadNote(answer);
                    break;

                    case "3":
                    /*
                    TODO: include option to wipe all files with for each function later, then can add a private string as password for it and show how to safely get it
                    */
                    handl.ViewNotesChapters();
                    display.WriteLine("Which chapter would you like to delete: ", typespeed); 
                    answer = Console.ReadLine();
                    handl.DeleteNote(answer);
                    display.WriteLine("press enter to continue", typespeed);
                    Console.ReadLine();
                    break;

                    case "4":
                    //insert help stuff, like explain things
                    break;

                    case "5":
                    run = false;
                    break;
                }


                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }  while (run == true);

        }

}


public class Displayer
{
	public void WriteLine(string message, int speed)
	{
		for (int i = 0; i < message.Length; i++)
      {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(speed);
      }
      Console.WriteLine(); //add a new line at the end
	}
}



public class Storagehandler 
{

	public void ViewNotesChapters()
    {
        Console.WriteLine("Listing notes by chapter:");

        string[] noteFiles = Directory.GetFiles(".", "*.txt");

        foreach (string noteFile in noteFiles)
        {
            Console.WriteLine(Path.GetFileNameWithoutExtension(noteFile)); //Microsofts naming scheme is so vanilla it makes missionary look spicy
        }

        Console.WriteLine("\n");
    }

    public void ReadNote(string title)
    {
        string fileName = $"{title}.txt";

        if (File.Exists(fileName))
        {
            string content = File.ReadAllText(fileName);  //		TODO: obscure it so notes app cant read it
            Console.WriteLine($"\nNote Content:\n{content}");
        }
        else
        {
            Console.WriteLine($"Note '{title}' not found, check spelling.");
        }

        Console.WriteLine("\nPress any key to continue once you have finish reading");
        Console.ReadKey();
    }

	public void CreateNote()	
    {
        Console.Write("Enter note chapter title: ");
        string title = Console.ReadLine();

		Console.WriteLine("Enter your note content (enter an empty line without spaces to finish):");
        
        List<string> lines = new List<string>(); //probably a stupid way to go about this but whatever
        string line;
        
        while ((line = Console.ReadLine()) != "") // is nice though becouse you can add a space so this doesnt get triggered, so you can make spacings ez
        {
            lines.Add(line);
        }

        string content = string.Join(Environment.NewLine, lines);

        string fileName = $"{title}.txt";  // $ indicated that string interpolation is being used, where {} is the indicator of a string being added, not text

        File.WriteAllText(fileName, content);  //		TODO: obscure it so notes app cant read it

        Console.WriteLine("Note saved successfully!");
		
    }

    public void DeleteNote(string title)
    {
         string fileName = $"{title}.txt";

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
            Console.WriteLine($"{fileName} is deleted now.");
        }
        else
        {
            Console.WriteLine($"Note '{title}' not found, check spelling.");
        }

    }
}
}