using Cocona;

namespace GeekSevenLabs.PowerToys.Terminal.Validators.Documents;

internal static class CadastroNacionalPessoaJuridicaCommand
{
    public const string Name = "cnpj";
    
    public static async Task ExecuteAsync(CadastroNacionalPessoaJuridicaArgs args)
    {
        var isValid = Toys.Generators.Documents.Brazilian.NationalRegistryLegalEntities.IsValid(args.Value);
        Printer.Print($"CNPJ: {args.Value}", isValid ? "Is Valid" : "Not Valid", isValid ? ConsoleColor.Green : ConsoleColor.Red);
        await Task.CompletedTask;
    }
}

internal record CadastroNacionalPessoaJuridicaArgs : ICommandParameterSet
{
    [Option(name: "value", shortNames: ['v'], Description = "CNPJ value")]
    public required string Value { get; init; }
}