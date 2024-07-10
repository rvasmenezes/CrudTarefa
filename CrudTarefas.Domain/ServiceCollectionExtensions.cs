using CrudTarefas.Domain.Aggregates.Interfaces;
using CrudTarefas.Domain.Aggregates.TarefaAgg.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CrudTarefas.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITarefaServices, TarefaServices>();
            
            return services;
        }
    }
}
