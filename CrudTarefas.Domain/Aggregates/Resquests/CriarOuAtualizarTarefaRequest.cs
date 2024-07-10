namespace CrudTarefas.Domain.Aggregates.Resquests
{
    public class CriarOuAtualizarTarefaRequest
    {
        public string? Titulo { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
