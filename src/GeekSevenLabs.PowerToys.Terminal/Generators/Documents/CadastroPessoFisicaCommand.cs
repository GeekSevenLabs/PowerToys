using Cocona;
using GeekSevenLabs.PowerToys.Documents.Personal;

namespace GeekSevenLabs.PowerToys.Terminal.Generators.Documents;

internal static class CadastroPessoFisicaCommand
{
    public const string Name = "cpf";
    
    public static async Task ExecuteAsync(CadastroPessoaFisicaArgs args)
    {
        var cpf = CadastroPessoaFisicaDocument.Generate(args.Region, args.Formatted);
        Printer.Print("CPF", cpf, ConsoleColor.Green);
        await Task.CompletedTask;
    }
}

internal record CadastroPessoaFisicaArgs : ICommandParameterSet
{
    [Option(name: "region", shortNames: ['r'], Description = "Region of the CPF")]
    [HasDefaultValue]
    public ushort? Region { get; init; }

    [Option(name: "formatted", shortNames: ['f'], Description = "Formatted CPF")]
    [HasDefaultValue]
    public bool Formatted { get; init; }
}