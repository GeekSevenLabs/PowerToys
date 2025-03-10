namespace GeekSevenLabs.PowerToys.Terminal;

public class ProgressBar : IDisposable
{
    private static readonly Lock PadLock = new();
    
    public ProgressBar(string? label = null, ConsoleColor color = ConsoleColor.Yellow)
    {
        Console.WriteLine();
        Console.CursorVisible = false;
        
        Line = Console.CursorTop;
        Label = label ?? "Progress";
        Color = color;
    }
    
    private int Line { get; }
    private string Label { get; }
    private ConsoleColor Color { get; }

    public void Update(double progress)
    {
        lock (PadLock)
        {
            StartLine();
            ClearLine();
            StartLine();
        
            Console.Write($"{Label} [{new string('=', (int)(progress * 10))}{new string(' ', 10 - (int)(progress * 10))}] ");
            Console.ForegroundColor = Color;
            Console.Write($"{progress:P}");
            Console.ResetColor();
        }
    }

    private void StartLine() => Console.SetCursorPosition(0, Line);
    private static void ClearLine() => Console.Write(new string(' ', Console.WindowWidth));

    public void Dispose()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.CursorVisible = true;
        GC.SuppressFinalize(this);
    }
}