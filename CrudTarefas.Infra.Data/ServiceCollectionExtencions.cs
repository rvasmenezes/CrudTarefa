using CrudTarefas.Domain.Interfaces;
using CrudTarefas.Infra.Data.EntityFramework;
using CrudTarefas.Infra.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace CrudTarefas.Infra.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseEFRepository<>), typeof(BaseEFRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
