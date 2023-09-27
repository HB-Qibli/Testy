using System.IO;
using System.Collections.Generic;


namespace System
{
    public class Storagehandler
    {
        private Displayer displayer; //this shits the bomb
        public Storagehandler(Displayer displayer, string password = "bananarama") //yeah, dont care
        {
            this.displayer = displayer;
            unlocked = false;
            passwd = password; //uh huh
            CiphKey = "";
        }

        private string passwd;
        private string CiphKey = "BananaramaIstheBEST";
        private bool unlocked;

        public int CheckPasswd() //basically encapsulation, the concept of keeping a variable private but checking it still, keeping it safe from being accessed and read by user
        {
            Console.WriteLine("Input password: ");
            if (Console.ReadLine() == passwd)
            {
                unlocked = true;
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public void ViewNotesChapters()
        {
            Console.WriteLine("Listing notes by chapter:");

            string[] noteFiles = Directory.GetFiles(".", "*.txt");

            foreach (string noteFile in noteFiles) //later add that saved notes with encryption will say if theyre encrypted or not
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
                string content = File.ReadAllText(fileName);  

                Console.WriteLine($"\nNote Content:\n");

                // Decrypt and display the note content
                string encryptedContent = File.ReadAllText(fileName);
                Displayer.DisplayEncryptedText(encryptedContent, CiphKey, 50); //testy testy testy tasty testy

            }
            else
            {
                Console.WriteLine($"Note '{title}' not found, check spelling.");
            }

            Console.WriteLine("\nPress any key to continue once you have finish reading");
            Console.ReadKey();
        }

        public void CreateNote() //		TODO: add *option* to encrypt or not to encrypt the message
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
            // here the writing notes step ends
            displayer.WriteLine("Would you like to add encryption?");

            string fileName = $"{title}.txt";  // $ indicated that string interpolation is being used, where {} is the indicator of a string being added, not text

            // Encrypt and save the note content
            string encryptedContent = Displayer.EncryptString(content, "SuperSecretKey");
            File.WriteAllText(fileName, encryptedContent);

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

        public void Bananarama()
        {
            if (unlocked == true)
            {
                string[] noteFiles = Directory.GetFiles(".", "*.txt"); //wipes all .txt files in working directory, maybe later make it all files ever >:3

                foreach (string noteFile in noteFiles)
                {
                    File.Delete(noteFile);
                }
            }
            else
            {
                Console.WriteLine("You dont have the priviladges to do this, or code fucked up, idk."); //shouldnt be reached bc isnt ran if passwd check failed
            }
        }

    }
}