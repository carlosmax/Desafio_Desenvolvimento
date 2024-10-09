using Desafio_Desenvolvimento.Application.Interfaces.Services;
using Desafio_Desenvolvimento.Application.ViewModel;
using Newtonsoft.Json;

namespace Desafio_Desenvolvimento.Data.Services
{
    public class IBGEService : IObterMunicipiosPorUFService
    {
        private readonly HttpClient _httpClient;
        private readonly string _ibgeApiUrl = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";

        public IBGEService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MunicipioViewModel>> ObterMunicipiosPorUF(string uf)
        {
            if (string.IsNullOrWhiteSpace(uf))
                throw new ArgumentException("UF não pode ser vazia.");

            var url = string.Format(_ibgeApiUrl, uf);

            // Faz a requisição HTTP para a API do IBGE
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao buscar municípios na API do IBGE.");

            // Converte para lista de Municipio
            var json = await response.Content.ReadAsStringAsync();
            var municipios = JsonConvert.DeserializeObject<List<MunicipioViewModel>>(json);

            return municipios ?? [];
        }
    }
}
