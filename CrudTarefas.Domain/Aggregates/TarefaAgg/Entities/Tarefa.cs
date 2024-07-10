using System.ComponentModel.DataAnnotations;

namespace CrudTarefas.Domain.Aggregates.TarefaAgg.Entities
{
    public class Tarefa
    {
        public int Id { get; private set; }

        [StringLength(50)]
        public string Titulo { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Tarefa(string titulo, DateTime dataEntrega)
        {
            Titulo = titulo;
            DataEntrega = dataEntrega;
            DataCadastro = DateTime.Now;
        }

        public void Atualizar(string titulo, DateTime dataEntrega)
        {
            Titulo = titulo;
            DataEntrega = dataEntrega;
        }
    }
}
