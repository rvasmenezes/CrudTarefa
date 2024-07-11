using CrudTarefas.Domain.Aggregates.Resquests;
using CrudTarefas.Domain.Aggregates.TarefaAgg.Entities;
using CrudTarefas.Domain.Common;

namespace CrudTarefas.Domain.Aggregates.Interfaces
{
    public interface ITarefaServices
    {
        Task<List<Tarefa>> GetListAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task<Tarefa> AddAsync(CriarOuAtualizarTarefaRequest request);
        Task<ResponseCreateDto<Tarefa>> Update(int id, CriarOuAtualizarTarefaRequest request);
        Task<ResponseCreateDto<bool>> Delete(int id);
    }
}
