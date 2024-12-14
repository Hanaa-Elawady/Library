using Library.Core.Contexts;
using Library.Core.Entities.MainEntities;
using Library.Infastructure.Interfaces;
using System.Collections;

namespace Library.Infastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var entityKey = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<>);
                var erpositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(entityKey, erpositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[entityKey];

        }
    }
}
