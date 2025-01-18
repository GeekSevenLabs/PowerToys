namespace GeekSevenLabs.PowerToys.Documents.Personal;

public static class CadastroPessoaFisicaDocument
{
    public static string Generate(int? region = null, bool formatted = false) => CadastroPessoaFisica.Generate(region, formatted);

    public static bool IsValid(string value) => CadastroPessoaFisica.IsValid(value);
}
