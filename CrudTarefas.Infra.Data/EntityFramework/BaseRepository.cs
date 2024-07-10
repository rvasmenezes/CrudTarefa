using CrudTarefas.Domain.Interfaces;
using CrudTarefas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CrudTarefas.Infra.Data.EntityFramework
{
    public class BaseEFRepository<TEntity> : IBaseEFRepository<TEntity> where TEntity : class
    {

        private readonly CrudTarefasEFContext _context;

        public BaseEFRepository(CrudTarefasEFContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
            => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public async Task<TEntity> GetEntityByIdAsync(int Id)
            => await _context.Set<TEntity>().FindAsync(Id);

        public IQueryable<TEntity> GetAll()
            => _context.Set<TEntity>();

        public TEntity GetById(int Id)
            => _context.Set<TEntity>().Find(Id);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        private void Dispose(bool isDispose)
        {
            if (!isDispose) return;
        }

        ~BaseEFRepository()
        {
            Dispose(false);
        }
    }
}
