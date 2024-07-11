using CrudTarefas.Domain.Aggregates.Interfaces;
using CrudTarefas.Domain.Aggregates.Resquests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CrudTarefas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaServices _tarefaServices;

        public TarefasController(ITarefaServices tarefaServices)
        {
            _tarefaServices = tarefaServices;
        }

        /// <summary>
        /// Adiciona tarefa
        /// </summary>
        /// <returns>Status code 201</returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CriarOuAtualizarTarefaRequest request)
        {
            await _tarefaServices.AddAsync(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        /// <summary>
        /// Atualiza a tarefa
        /// </summary>
        /// <returns>Tarefa atualizada</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CriarOuAtualizarTarefaRequest request)
        {
            var response = await _tarefaServices.Update(id, request);

            if (!response.ValidationResult.IsValid)
                return BadRequest(response.ValidationResult);

            return Ok(response.Entity);
        }

        /// <summary>
        /// Obtém a tarefa
        /// </summary>
        /// <returns>Tarefa</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _tarefaServices.GetByIdAsync(id);

            if(response == null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtém todas as tarefas
        /// </summary>
        /// <returns>Uma lista de tarefas</returns>
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _tarefaServices.GetListAsync();

            if(!response.Any())
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Deleta a tarefa por Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _tarefaServices.Delete(id);

            if (!response.ValidationResult.IsValid)
                return BadRequest(response.ValidationResult);

            return Ok();
        }
    }
}
