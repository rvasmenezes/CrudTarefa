using CrudTarefas.Domain.Aggregates.TarefaAgg.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudTarefas.Infra.Data.Context
{
    public class CrudTarefasEFContext : DbContext
    {

        public CrudTarefasEFContext(DbContextOptions<CrudTarefasEFContext> options) : base(options) { }

        public CrudTarefasEFContext() { }

        public virtual DbSet<Tarefa> Tarefa { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
