using CrudTarefas.Domain.Aggregates.Interfaces;
using CrudTarefas.Domain.Aggregates.Resquests;
using CrudTarefas.Domain.Aggregates.TarefaAgg.Entities;
using CrudTarefas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudTarefas.Domain.Aggregates.TarefaAgg.Services
{
    public class TarefaServices : ITarefaServices
    {
        protected readonly IUnitOfWork _unitOfWork;

        public TarefaServices(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tarefa> AddAsync(CriarOuAtualizarTarefaRequest request)
        {
            var add = await _unitOfWork.TarefaRepository.AddAsync(
                        new Tarefa(request.Titulo, request.DataEntrega));

            await _unitOfWork.Commit();

            return add.Entity;
        }

        public async Task Delete(int id)
        {
            var tarefa = await _unitOfWork.TarefaRepository.GetEntityByIdAsync(id);
            _unitOfWork.TarefaRepository.Delete(tarefa);
            await _unitOfWork.Commit();
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
            => await _unitOfWork.TarefaRepository.GetEntityByIdAsync(id);         

        public async Task<List<Tarefa>> GetListAsync()
            => await _unitOfWork.TarefaRepository.GetAll().ToListAsync();

        public async Task<Tarefa> Update(int id, CriarOuAtualizarTarefaRequest request)
        {
            var tarefa = await _unitOfWork.TarefaRepository.GetEntityByIdAsync(id);

            tarefa.Atualizar(request.Titulo, request.DataEntrega);

            _unitOfWork.TarefaRepository.Update(tarefa);
            await _unitOfWork.Commit();

            return tarefa;
        }
    }
}
