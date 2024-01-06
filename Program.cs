
class Ccwc
{
    public static void Main(string[] args)
    {
        string file = "";
        var filePath = args[0];

        if (args.Length > 1)
        {
            filePath = args[1];
        }

        if (File.Exists(filePath))
        {
            file = File.ReadAllText(filePath);
        }

        switch (args[0])
        {
            case "-d": //Print count of bytes in textfile - Should be -c. But this is not possible since it is an option for dotnet run command.
                Console.WriteLine(File.ReadAllBytes(filePath).Length + " " + filePath);
                break;

            case "-l": //Print count of lines in textfile.
                Console.WriteLine(File.ReadAllLines(filePath).Count() + " " + filePath);
                break;

            case "-w": // Count the number of words in the textfile.
                int numberOfWords = CountWords(file);
                Console.WriteLine(numberOfWords);
                break;

            case "-m": //Count the number of Characters in the textfile.
                Console.WriteLine(file.Length + " " + filePath);
                break;

            default: // Default is blank and should be a combination of -re -l and -w
                Console.WriteLine(File.ReadAllBytes(filePath).Length + " " + File.ReadAllLines(filePath).Count() + " " + CountWords(file) + " " + filePath);
                break;
        }
    }
    public static int CountWords(string file)
    {
        int wordCount = 0, index = 0;
        while (index < file.Length && char.IsWhiteSpace(file[index]))
            index++;

        while (index < file.Length)
        {
            // check if current char is part of a word
            while (index < file.Length && !char.IsWhiteSpace(file[index]))
                index++;

            wordCount++;

            // skip whitespace until next word
            while (index < file.Length && char.IsWhiteSpace(file[index]))
                index++;
        }
        return wordCount;
    }
}