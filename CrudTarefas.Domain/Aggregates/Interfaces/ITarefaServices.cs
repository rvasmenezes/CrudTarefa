using CrudTarefas.Domain.Aggregates.Resquests;
using CrudTarefas.Domain.Aggregates.TarefaAgg.Entities;

namespace CrudTarefas.Domain.Aggregates.Interfaces
{
    public interface ITarefaServices
    {
        Task<List<Tarefa>> GetListAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task<Tarefa> AddAsync(CriarOuAtualizarTarefaRequest request);
        Task<Tarefa> Update(int id, CriarOuAtualizarTarefaRequest request);
        Task Delete(int id);
    }
}
