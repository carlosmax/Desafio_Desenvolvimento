namespace Desafio_Desenvolvimento.Application.ViewModel
{
    public class ProcessoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Npu { get; set; } = String.Empty;        
        public string UF { get; set; } = String.Empty;
        public string Municipio { get; set; } = String.Empty;
        public int MunicipioCodigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataVisualizacao { get; set; }
    }
}
