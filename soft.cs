// Testy
using System;


namespace System
{
    class Testy
    {
        static void Main(string[] args)
        {
            string answer; // first few lines here are prep
            bool run = true;
            int typespeed = 40;
            //honestly unnecesary, making it static would have been just fine as multiple instances wont ever be needed
            // but ig to show teacher that the student is able to do this and understand what it does ig
            Displayer display = new Displayer();
            Storagehandler handl = new Storagehandler(display); //s 16:50 on 6th september in atu class

            //do stuff here like welcome to this application and shit, maybe fancy with coloured text too
            display.WriteLine("Welcome to a application for notes, it is amazingly bad!", typespeed, ConsoleColor.Blue);

            do
            {
                display.WriteLine("Select a option by number: ", typespeed);
                display.WriteLine("1. Create a note", typespeed, ConsoleColor.Green);
                display.WriteLine("2. Read saved notes", typespeed, ConsoleColor.Cyan);
                display.WriteLine("3. Delete notes", typespeed, ConsoleColor.Red);
                display.WriteLine("4. Help", typespeed, ConsoleColor.Yellow);
                display.WriteLine("5. Exit ", typespeed, ConsoleColor.Red);
                display.WriteLine("6. Wipe all saved notes", typespeed, ConsoleColor.DarkRed);
                display.WriteLine("Select option: ", typespeed);

                answer = Console.ReadLine();
                // Fix bug: pressing enter while options are written does trigger the readline and skips switch, then reads options again
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
                        handl.ViewNotesChapters();
                        display.WriteLine("Which chapter would you like to delete: ", typespeed);
                        answer = Console.ReadLine();
                        handl.DeleteNote(answer);
                        display.WriteLine("press enter to continue", typespeed);
                        Console.ReadLine();
                        break;

                    case "4":
                        //insert help stuff, like explain things
                        display.WriteLine("Basics of programming are in a saved note that comes with the code, otherwise idk, this is too simple to explain", typespeed);
                        break;

                    case "5":
                        run = false;
                        break;

                    case "6":
                        if (handl.CheckPasswd() == 1)
                        {
                            display.WriteLine("Correct password, deleting...");
                            handl.Bananarama();
                        }
                        else
                        {
                            display.WriteLine("Incorrect password.");
                        }
                        break;

                    default:
                        display.WriteLine("You wrote something wrong, or you pressed enter while options were writing still, be patient", typespeed);
                        break;
                }


                System.Threading.Thread.Sleep(500);
                Console.Clear();
            } while (run == true);

        }

    }

}