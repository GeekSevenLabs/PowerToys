using Cocona;

namespace GeekSevenLabs.PowerToys.Terminal.Validators.Documents;

internal static class CadastroPessoFisicaCommand
{
    public const string Name = "cpf";
    
    public static async Task ExecuteAsync(CadastroPessoaFisicaArgs args)
    {
        var isValid = Toys.Generators.Documents.Brazilian.IndividualRegistration.IsValid(args.Value);
        Printer.Print($"CPF: {args.Value}", isValid ? "Is Valid" : "Not Valid", isValid ? ConsoleColor.Green : ConsoleColor.Red);
        await Task.CompletedTask;
    }
}

internal record CadastroPessoaFisicaArgs : ICommandParameterSet
{
    [Option(name: "value", shortNames: ['v'], Description = "CPF value")]
    public required string Value { get; init; }
}