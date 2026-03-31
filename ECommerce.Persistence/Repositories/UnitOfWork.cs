using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using ECommerce.Persistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var EntityType = typeof(TEntity);
            if(_repositories.TryGetValue(EntityType, out var repository))
            {
                return (IGenericRepository<TEntity, TKey>) repository;
            }
            
            var newRepo = new GenericRepository<TEntity, TKey>(_dbContext);
            _repositories[EntityType] = newRepo;
            return newRepo;
        }

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
