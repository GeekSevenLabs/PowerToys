using CNPJ = GeekSevenLabs.Utilities.Documents.NationalRegistryLegalEntities;
using CPF = GeekSevenLabs.Utilities.Documents.BrazilianIndividualRegistration;

namespace GeekSevenLabs.PowerToys;

public static partial class Toys
{
    public static class Generators
    {
        public static class Documents
        {
            public static class Brazilian
            {
                /// <summary>
                /// CPF - Brazilian Individual Registration
                /// </summary>
                public static class IndividualRegistration
                {
                    public static string Generate(int? region = null, bool formatted = false) => CPF.Generate(region, formatted);

                    public static bool IsValid(string value) => CPF.IsValid(value);
                }
                
                /// <summary>
                /// CNPJ - Brazilian National Registry of Legal Entities
                /// </summary>
                public static class NationalRegistryLegalEntities
                {
                    public static string Generate(bool formatted, bool useLetters) => CNPJ.Generate(formatted, useLetters);
                    public static bool IsValid(string value) => CNPJ.IsValid(value);
                }
            }
        }
        
        public static class Values
        {
            public static Guid GenerateGuid() => Guid.NewGuid();
        }
    }
}