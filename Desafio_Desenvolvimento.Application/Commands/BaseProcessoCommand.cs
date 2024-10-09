using Desafio_Desenvolvimento.Core;
using Desafio_Desenvolvimento.Domain.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Desafio_Desenvolvimento.Application.Commands
{
    public abstract class BaseProcessoCommand : ICommand
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(255, ErrorMessage = "O nome pode ter no máximo 255 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O NPU é obrigatório")]
        [MaxLength(25, ErrorMessage = "O NPU pode ter no máximo 25 caracteres")]
        public string Npu { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório")]
        [StringLength(2, ErrorMessage = "O UF deve ter 2 caracteres")]
        [DisplayName("UF")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "O município é obrigatório")]
        [MaxLength(255, ErrorMessage = "O município pode ter no máximo 255 caracteres")]
        [DisplayName("Município")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "O município é obrigatório")]
        [DisplayName("Município")]
        public int MunicipioCodigo { get; set; }


        public virtual ICommandValidationResult Validate()
        {
            var validationResult = new CommandValidationResult();

            // Validação do Nome
            if (string.IsNullOrEmpty(Nome))
                validationResult.Errors.Add("O nome é obrigatório");
            else if (Nome.Length > 255)
                validationResult.Errors.Add("O nome pode ter no máximo 255 caracteres");

            // Validação do NPU
            if (string.IsNullOrEmpty(Npu))
                validationResult.Errors.Add("O NPU é obrigatório");
            else if (Npu.Length > 25)
                validationResult.Errors.Add("O NPU pode ter no máximo 25 caracteres");
            else if (!ValidatorHelper.IsValidNpu(Npu))
                validationResult.Errors.Add("O NPU informado é inválido");

            // Validação do UF
            if (string.IsNullOrEmpty(Uf))
                validationResult.Errors.Add("O UF é obrigatório");
            else if (Uf.Length != 2)
                validationResult.Errors.Add("O UF deve ter 2 caracteres");
            else if (!ValidatorHelper.IsValidUf(Uf))
                validationResult.Errors.Add("O UF informado é inválido");

            // Validação do Município
            if (string.IsNullOrEmpty(Municipio))
                validationResult.Errors.Add("O município é obrigatório");
            else if (Municipio.Length > 255)
                validationResult.Errors.Add("O município pode ter no máximo 255 caracteres");

            if (MunicipioCodigo <= 0)
                validationResult.Errors.Add("O código do município é obrigatório");

            return validationResult;
        }
    }
}
