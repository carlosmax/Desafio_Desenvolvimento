using AutoMapper;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;
using Desafio_Desenvolvimento.Application.Queries;
using Desafio_Desenvolvimento.Application.ViewModel;
using Desafio_Desenvolvimento.Core;


namespace Desafio_Desenvolvimento.Application.Handlers
{
    public class ObterProcessoPorIdHandler : IQueryHandler<ObterProcessoPorIdQuery, ProcessoViewModel?>
    {
        private readonly IMapper _mapper;
        private readonly IObterProcessoPorIdRepository _repository;

        public ObterProcessoPorIdHandler(IMapper mapper, IObterProcessoPorIdRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProcessoViewModel?> HandleAsync(ObterProcessoPorIdQuery query)
        {
            var processo = await _repository.ObterProcessoPorIdAsync(query.Id);

            if (processo == null)
                return null;

            return _mapper.Map<ProcessoViewModel>(processo);
        }
    }
}
