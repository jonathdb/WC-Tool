
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
                Console.WriteLine(numberOfWords + " " + filePath);
                break;

            case "-m": //Count the number of Characters in the textfile.
                Console.WriteLine(file.Length + " " + filePath);
                break;

            case "-help":
                Console.WriteLine(" -d - Print the bytecount of the file\n -l - Print the linecount of the file\n -w - Print the wordcount of the file\n -m - Print thecharactercount of the file\n -help - Print this help menu\n - If no arguments are added the program will use -d -l and -w arguments");
                break;

            default: // Default is blank and should be a combination of -d -l and -w
                Console.WriteLine(File.ReadAllBytes(filePath).Length + " " + File.ReadAllLines(filePath).Count() + " " + CountWords(file) + " " + filePath);
                Console.WriteLine("For help, add -help");
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