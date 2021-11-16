using System.Collections.Generic;

namespace CostTracker.Application.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
