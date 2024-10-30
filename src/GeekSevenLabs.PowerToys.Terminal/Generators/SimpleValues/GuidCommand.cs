namespace GeekSevenLabs.PowerToys.Terminal.Generators.SimpleValues;

internal static class GuidCommand
{
    public const string Name = "guid";
    
    public static async Task ExecuteAsync()
    {
        Printer.Print("GUID", Toys.Generators.Values.GenerateGuid().ToString(), ConsoleColor.Green);
        await Task.CompletedTask;
    }
}