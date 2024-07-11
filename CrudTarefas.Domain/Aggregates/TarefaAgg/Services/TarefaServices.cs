using CrudTarefas.Domain.Aggregates.Interfaces;
using CrudTarefas.Domain.Aggregates.Resquests;
using CrudTarefas.Domain.Aggregates.TarefaAgg.Entities;
using CrudTarefas.Domain.Common;
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

        public async Task<ResponseCreateDto<bool>> Delete(int id)
        {
            var response = new ResponseCreateDto<bool>();

            var tarefa = await _unitOfWork.TarefaRepository.GetEntityByIdAsync(id);

            if (tarefa == null)
            {
                response.AddWarningValidation("Tarefa inexistente!");
                return response;
            }

            _unitOfWork.TarefaRepository.Delete(tarefa);
            await _unitOfWork.Commit();

            response.Entity = true;
            return response;
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
            => await _unitOfWork.TarefaRepository.GetEntityByIdAsync(id);         

        public async Task<List<Tarefa>> GetListAsync()
            => await _unitOfWork.TarefaRepository.GetAll().ToListAsync();

        public async Task<ResponseCreateDto<Tarefa>> Update(int id, CriarOuAtualizarTarefaRequest request)
        {
            var response = new ResponseCreateDto<Tarefa>();

            var tarefa = await _unitOfWork.TarefaRepository.GetEntityByIdAsync(id);

            if (tarefa == null)
            {
                response.AddWarningValidation("Tarefa inexistente!");
                return response;
            }

            tarefa.Atualizar(request.Titulo, request.DataEntrega);

            _unitOfWork.TarefaRepository.Update(tarefa);
            await _unitOfWork.Commit();

            response.Entity = tarefa;
            return response;
        }
    }
}
