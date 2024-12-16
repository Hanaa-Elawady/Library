using Library.Core.Contexts;
using Library.Core.Entities.MainEntities;
using Library.Infastructure.Interfaces;
using Library.Infastructure.Specifications.SpecificationBase;
using Microsoft.EntityFrameworkCore;

namespace Library.Infastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly LibraryDbContext _context;

        public GenericRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
           => _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
        => _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
           => await _context.Set<TEntity>().ToListAsync();
        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecsAsync(BaseSpecifications<TEntity> specs)
        => await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).AsNoTracking().ToListAsync();
        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync()
           => await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        public async Task<TEntity> GetByIdAsync(Guid id)
        => await _context.Set<TEntity>().FindAsync(id);
       
        public async Task<TEntity> GetByIdWithSpecsAsync(BaseSpecifications<TEntity> specs)
        => await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).AsNoTracking().FirstOrDefaultAsync();

    }
}
