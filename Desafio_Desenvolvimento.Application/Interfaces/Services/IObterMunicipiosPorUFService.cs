using Desafio_Desenvolvimento.Application.ViewModel;

namespace Desafio_Desenvolvimento.Application.Interfaces.Services
{
    public interface IObterMunicipiosPorUFService
    {
        Task<List<MunicipioViewModel>> ObterMunicipiosPorUF(string uf);
    }
}
