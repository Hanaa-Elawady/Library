using Library.Core.Entities.MainEntities;
using Library.Infastructure.Specifications.SpecificationBase;

namespace Library.Infastructure.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAllWithSpecsAsync(BaseSpecifications<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdWithSpecsAsync(BaseSpecifications<TEntity> specs);

    }
}
