using Cocona;
using Cocona.Builder;

namespace GeekSevenLabs.PowerToys.Terminal.Generators.SimpleValues;

internal static class SimpleValuesCommandsExtensions
{
    public static void AddSimpleValuesCommands(this ICoconaCommandsBuilder builder)
    {
        builder.AddCommand(GuidCommand.Name, GuidCommand.ExecuteAsync);
    }
}