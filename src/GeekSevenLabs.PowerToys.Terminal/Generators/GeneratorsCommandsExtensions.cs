using Cocona;
using GeekSevenLabs.PowerToys.Terminal.Generators.Documents;
using GeekSevenLabs.PowerToys.Terminal.Generators.SimpleValues;

namespace GeekSevenLabs.PowerToys.Terminal.Generators;

internal static class GeneratorsCommandsExtensions
{
    public static void AddGeneratorsCommands(this CoconaApp app)
    {
        app.AddSubCommand("g", builder =>
            {
                builder.AddGeneratorDocumentCommands();
                builder.AddSimpleValuesCommands();
            })
            .WithDescription("Generators commands");
    }
}