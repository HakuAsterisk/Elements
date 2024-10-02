using System.IO;
using System.Collections.Generic;
using System.Linq;
public class Program 
{
    public static void Main(string[] args)
    {
        var currentDirectory = Directory.GetCurrentDirectory();   
        var elementDir = Path.Combine(currentDirectory, "alkuaineet.txt");
        while(true) {
        Console.WriteLine("Play a new game? = P");
        Console.WriteLine("Check the scores? = S");
        Console.WriteLine("Quit? = Q");
        //List<string> questionElements = 
        pullElements(elementDir);
        string choose = Console.ReadLine();
        if (choose == "P") {

            Console.WriteLine("\r\n" + "Playing..." + "\r\n");

        } else if (choose == "S") {

            Console.WriteLine("\r\n" + "Scores..." + "\r\n");

        } else if (choose == "Q") 
        {
            Console.WriteLine("\r\n" + "Thanks for playing!" + "\r\n");
            break;

        } else {

            Console.WriteLine("\r\n" + "Wrong input!" + "\r\n");

        }

        }
    }
    public static void pullElements(string fileDir)
    {
        Dictionary<string, string> elements = new Dictionary<string, string>();
        string text = File.ReadAllText(fileDir);

        string[] pieces = text.Split(" ");

        string[] newPieces = rndElements(pieces);

        string[] rndPieces = text.Split(",");

        int number = 0;
        while(number < rndPieces.Length)
        {
            elements.Add(rndPieces[number], rndPieces[number + 1]);
            number = number + 2;
        }

        /*foreach (KeyValuePair<string, string> kvp in elements)
        {
            Console.WriteLine("Key = {0}, Value = {1}",
            kvp.Key, kvp.Value);
        }*/

        //List<string> questionElements = rndElements(elements);
        return;
    }

    public static string[] rndElements(string[] elements)
    {
        string[] newrng = new string[5];
        Random rnd = new Random();
        for(int i = 0; i <= 5; i++)
        {
            int r = rnd.Next(elements.Length);
            newrng[i] = elements[r];
        }
        return newrng;
    }
}