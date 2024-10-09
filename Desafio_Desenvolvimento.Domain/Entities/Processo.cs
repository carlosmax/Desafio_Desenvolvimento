namespace Desafio_Desenvolvimento.Domain.Entities
{
    public class Processo
    {
        protected Processo() { }

        public Processo(string nome, string npu, string uf, string municipio, int municipioCodigo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Npu = npu;
            UF = uf;
            Municipio = municipio;
            MunicipioCodigo = municipioCodigo;
            DataCadastro = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Npu { get; private set; }        
        public string UF { get; private set; }
        public string Municipio { get; private set; }
        public int MunicipioCodigo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataVisualizacao { get; private set; }

        public void Atualizar(string nome, string npu, string uf, string municipio, int municipioCodigo)
        {
            Nome = nome;
            Npu = npu;
            UF = uf;
            Municipio = municipio;
            MunicipioCodigo = municipioCodigo;
        }

        public void ConfirmarVisualizacao()
        {
            DataVisualizacao = DateTime.Now;
        }
    }
}
