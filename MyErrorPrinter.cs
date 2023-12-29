public class MyErrorPrinter
{
    public static void PrintUserError(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: " + errorMessage);
        Console.ResetColor();
    }
}