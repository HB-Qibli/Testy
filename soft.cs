// Testy
namespace System
{
class Testy
{
 static void Main(string[] args)
        {
                bool run = true;
                Storagehandler handl = new Storagehandler(); //honestly unnecesary, making it static would have been just fine as multiple instances wont ever be needed
				Displayer display = new Displayer(); // but ig to show teacher that the student is able to do this and understand what it does ig


            Console.WriteLine("hello cock");
            while (run == true)
            {
                


            }       

        }

}



public class Storagehandler 
{

	public void ViewNotesChapters()
    {
        Console.WriteLine("Listing notes:");

        string[] noteFiles = Directory.GetFiles(".", "*.txt");

        foreach (string noteFile in noteFiles)
        {
            Console.WriteLine(Path.GetFileNameWithoutExtension(noteFile)); //Microsofts naming scheme is so vanilla it makes missionary look spicy
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
	public void CreateNote()	
    {
        Console.Write("Enter note title: ");
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

        File.WriteAllText(fileName, content);

        Console.WriteLine("Note saved successfully!");
		
		
    }
}