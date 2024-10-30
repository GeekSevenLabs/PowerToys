using Cocona;
using Cocona.Builder;

namespace GeekSevenLabs.PowerToys.Terminal.Generators.Documents;

internal static class DocumentsCommandsExtensions
{
    public static void AddGeneratorDocumentCommands(this ICoconaCommandsBuilder builder)
    {
        builder.AddCommand(CadastroPessoFisicaCommand.Name, CadastroPessoFisicaCommand.ExecuteAsync);
        builder.AddCommand(CadastroNacionalPessoaJuridicaCommand.Name, CadastroNacionalPessoaJuridicaCommand.ExecuteAsync);
    }
    
}