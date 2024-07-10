using CrudTarefas.Domain.Aggregates.Interfaces;
using CrudTarefas.Domain.Aggregates.Resquests;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CriarOuAtualizarTarefaRequest request)
        {
            var response = await _tarefaServices.AddAsync(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CriarOuAtualizarTarefaRequest request)
        {
            var response = await _tarefaServices.Update(id, request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _tarefaServices.GetByIdAsync(id);

            if(response == null)
                return NoContent();

            return Ok(response);
        }

        [HttpGet("List")]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _tarefaServices.GetListAsync();

            if(!response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _tarefaServices.Delete(id);
            return Ok();
        }
    }
}
