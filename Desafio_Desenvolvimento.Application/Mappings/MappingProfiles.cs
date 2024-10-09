using AutoMapper;
using Desafio_Desenvolvimento.Domain.Entities;
using Desafio_Desenvolvimento.Application.ViewModel;

namespace Desafio_Desenvolvimento.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Processo, ProcessoViewModel>().ReverseMap();
        }
    }
}
