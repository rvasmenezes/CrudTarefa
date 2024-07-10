using CrudTarefas.Domain.Aggregates.TarefaAgg.Entities;

namespace CrudTarefas.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseEFRepository<Tarefa> TarefaRepository { get; }

        Task<int> Commit();
        void Rollback();
    }
}
