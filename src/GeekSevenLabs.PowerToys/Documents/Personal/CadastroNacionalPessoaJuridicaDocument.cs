namespace GeekSevenLabs.PowerToys.Documents.Personal;

public static class CadastroNacionalPessoaJuridicaDocument
{
    public static string Generate(bool formatted, bool useLetters) => CadastroNacionalPessoaJuridica.Generate(formatted, useLetters);
    public static bool IsValid(string value) => CadastroNacionalPessoaJuridica.IsValid(value);
}