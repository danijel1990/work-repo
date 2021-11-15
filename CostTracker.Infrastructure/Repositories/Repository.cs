using CostTracker.Application.IRepositories;
using CostTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace CostTracker.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

		public TEntity Get(int id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		public TEntity Get<T>(T key, IQueryable<TEntity> baseQuery)
		{
			if (typeof(T) == typeof(int) && key is int intKey)
			{
				if (baseQuery.GetType() == typeof(InternalDbSet<TEntity>))
				{
					return Get(intKey);
				}
				else
				{
					var result = (baseQuery as IQueryable<BaseEntity>)
						.SingleOrDefault(x => x.Id == intKey);

					return result as TEntity;
				}
			}

			throw new System.Exception();
		}
	}
}
