using Cocona;
using GeekSevenLabs.PowerToys.Documents.Personal;

namespace GeekSevenLabs.PowerToys.Terminal.Generators.Documents;

internal static class CadastroNacionalPessoaJuridicaCommand
{
    public const string Name = "cnpj";
    
    public static async Task ExecuteAsync(CadastroNacionalPessoaJuridicaArgs args)
    {
        var cnpj = CadastroNacionalPessoaJuridicaDocument.Generate(args.Formatted, args.UseLetters);
        Printer.Print("CNPJ", cnpj, ConsoleColor.Green);
        await Task.CompletedTask;
    }
}

internal record CadastroNacionalPessoaJuridicaArgs : ICommandParameterSet
{
    [Option(name: "letters", shortNames: ['l'], Description = "Use letters in the CNPJ (New CNPJ version)")]
    [HasDefaultValue]
    public bool UseLetters { get; init; }

    [Option(name: "formatted", shortNames: ['f'], Description = "Formatted CNPJ")]
    [HasDefaultValue]
    public bool Formatted { get; init; }
}