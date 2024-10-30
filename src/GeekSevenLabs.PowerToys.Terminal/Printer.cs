namespace GeekSevenLabs.PowerToys.Terminal;

internal static class Printer
{
    public static void Print(string message)
    {
        Console.WriteLine(message);
    }
    
    public static void Print(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void Print(string label, string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.WriteLine();
        Console.Write($"\t{label.ToUpper()}: ");
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}