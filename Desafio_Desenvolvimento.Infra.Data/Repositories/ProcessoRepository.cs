using Desafio_Desenvolvimento.Core;
using Desafio_Desenvolvimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;

namespace Desafio_Desenvolvimento.Infra.Data.Repositories
{
    public class ProcessoRepository : ICriarProcessoRepository, IAtualizarProcessoRepository, IExcluirProcessoRepository, 
        IObterProcessoPorIdRepository, IObterProcessosRepository, IObterProcessoPorNpuRepository
    {
        private readonly DesafioDbContext _context;

        public ProcessoRepository(DesafioDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Processo>> ObterProcessosAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Processos.CountAsync();

            var processos = await _context.Processos
                .OrderByDescending(p => p.DataCadastro)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<Processo>(processos, totalCount, pageNumber, pageSize);
        }

        public async Task<Processo?> ObterProcessoPorIdAsync(Guid id)
        {
            return await _context.Processos.FindAsync(id);
        }

        public async Task<Processo?> ObterProcessoPorNpuAsync(string npu)
        {
            return await _context.Processos.FirstOrDefaultAsync(p => p.Npu == npu);
        }

        public async Task<Processo> CriarProcessoAsync(Processo processo)
        {
            await _context.Processos.AddAsync(processo);
            await _context.SaveChangesAsync();

            return processo;
        }

        public async Task AtualizarProcessoAsync(Processo processo)
        {
            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirProcessoAsync(Processo processo)
        {
            _context.Processos.Remove(processo);
            await _context.SaveChangesAsync();
        }
    }
}
