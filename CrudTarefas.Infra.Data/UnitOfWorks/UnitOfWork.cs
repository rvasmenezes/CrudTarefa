using CrudTarefas.Domain.Aggregates.TarefaAgg.Entities;
using CrudTarefas.Domain.Interfaces;
using CrudTarefas.Infra.Data.Context;
using CrudTarefas.Infra.Data.EntityFramework;

namespace CrudTarefas.Infra.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public CrudTarefasEFContext _context { get; }

        private BaseEFRepository<Tarefa>? _tarefaRepository;
       
        public UnitOfWork(CrudTarefasEFContext context) => _context = context;

        public IBaseEFRepository<Tarefa> TarefaRepository
            => _tarefaRepository ??= new BaseEFRepository<Tarefa>(_context);

        public Task<int> Commit() => _context.SaveChangesAsync();

        public void Rollback() { }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
