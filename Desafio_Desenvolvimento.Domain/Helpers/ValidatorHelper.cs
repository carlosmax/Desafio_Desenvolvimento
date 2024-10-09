using System.Text.RegularExpressions;

namespace Desafio_Desenvolvimento.Domain.Helpers
{
    public static class ValidatorHelper
    {
        private static readonly Regex NpuRegex = new Regex(@"^\d{7}-\d{2}\.\d{4}\.\d{1}\.\d{2}\.\d{4}$");

        public static bool IsValidNpu(string npu)
        {
            return NpuRegex.IsMatch(npu);
        }

        public static bool IsValidUf(string uf)
        {
            var ufs = new[]
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES",
                "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR",
                "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC",
                "SP", "SE", "TO"
            };

            return ufs.Contains(uf.ToUpper());
        }
    }
}
