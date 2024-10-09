using Desafio_Desenvolvimento.Application.Commands;
using Desafio_Desenvolvimento.Application.Handlers;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;
using Desafio_Desenvolvimento.Application.Interfaces.Services;
using Desafio_Desenvolvimento.Application.Queries;
using Desafio_Desenvolvimento.Application.ViewModel;
using Desafio_Desenvolvimento.Core;
using Desafio_Desenvolvimento.Data.Services;
using Desafio_Desenvolvimento.Infra.Data.Repositories;

namespace Desafio_Desenvolvimento.Web.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            // Http
            services.AddHttpClient();

            // Repositórios
            services.AddScoped<ICriarProcessoRepository, ProcessoRepository>();
            services.AddScoped<IAtualizarProcessoRepository, ProcessoRepository>();
            services.AddScoped<IExcluirProcessoRepository, ProcessoRepository>();
            services.AddScoped<IObterProcessosRepository, ProcessoRepository>();
            services.AddScoped<IObterProcessoPorIdRepository, ProcessoRepository>();
            services.AddScoped<IObterProcessoPorNpuRepository, ProcessoRepository>();

            // Services
            services.AddScoped<IObterMunicipiosPorUFService, IBGEService>();

            // Handlers
            services.AddScoped<IHandler<CadastrarProcessoCommand>, CadastrarProcessoHandler>();
            services.AddScoped<IHandler<AlterarProcessoCommand>, AlterarProcessoHandler>();
            services.AddScoped<IHandler<ExcluirProcessoCommand>, ExcluirProcessoHandler>();
            services.AddScoped<IHandler<ConfirmarVisualizacaoCommand>, ConfirmarVisualizacaoHandler>();
            services.AddScoped<IQueryHandler<ObterProcessosQuery, PaginatedList<ProcessoViewModel>>, ObterProcessosHandler>();
            services.AddScoped<IQueryHandler<ObterProcessoPorIdQuery, ProcessoViewModel?>, ObterProcessoPorIdHandler>();
        }
    }
}
