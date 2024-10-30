using Cocona;
using GeekSevenLabs.PowerToys.Terminal.Validators.Documents;

namespace GeekSevenLabs.PowerToys.Terminal.Validators;

internal static class ValidatorsCommandsExtensions
{
    public static void AddValidatorsCommands(this CoconaApp app)
    {
        app.AddSubCommand("v", builder =>
            {
                builder.AddGeneratorDocumentCommands();
            })
            .WithDescription("Validators commands");
    }
}