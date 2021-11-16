using System.Collections.Generic;

namespace CostTracker.Application.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
