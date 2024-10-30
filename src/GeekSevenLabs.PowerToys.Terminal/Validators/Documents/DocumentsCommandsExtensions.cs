using Cocona;
using Cocona.Builder;

namespace GeekSevenLabs.PowerToys.Terminal.Validators.Documents;

internal static class DocumentsCommandsExtensions
{
    public static void AddGeneratorDocumentCommands(this ICoconaCommandsBuilder builder)
    {
        builder.AddCommand(CadastroNacionalPessoaJuridicaCommand.Name, CadastroNacionalPessoaJuridicaCommand.ExecuteAsync);
        builder.AddCommand(CadastroPessoFisicaCommand.Name, CadastroPessoFisicaCommand.ExecuteAsync);
    }
    
}