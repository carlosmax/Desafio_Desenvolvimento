using AutoMapper;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;
using Desafio_Desenvolvimento.Application.Queries;
using Desafio_Desenvolvimento.Application.ViewModel;
using Desafio_Desenvolvimento.Core;


namespace Desafio_Desenvolvimento.Application.Handlers
{
    public class ObterProcessosHandler : IQueryHandler<ObterProcessosQuery, PaginatedList<ProcessoViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IObterProcessosRepository _obterProcessosRepository;

        public ObterProcessosHandler(IMapper mapper, IObterProcessosRepository obterProcessosRepository)
        {
            _mapper = mapper;
            _obterProcessosRepository = obterProcessosRepository;
        }

        public async Task<PaginatedList<ProcessoViewModel>> HandleAsync(ObterProcessosQuery query)
        {
            var pageIndex = query.PageIndex > 0 ? query.PageIndex : 1;
            var pageSize = query.PageSize > 0 ? query.PageSize : 10;

            var paginatedList = await _obterProcessosRepository.ObterProcessosAsync(pageIndex, pageSize);
            var viewModelList = _mapper.Map<List<ProcessoViewModel>>(paginatedList.Items);

            return new PaginatedList<ProcessoViewModel>(viewModelList, paginatedList.TotalCount, paginatedList.PageNumber, paginatedList.PageSize);
        }
    }
}
