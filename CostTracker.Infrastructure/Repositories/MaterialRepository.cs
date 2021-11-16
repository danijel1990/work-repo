using CostTracker.Application.Context;
using CostTracker.Application.IRepositories;
using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Infrastructure.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public ICostTrackerDbContext CostTrackerDbContext => _context as ICostTrackerDbContext;

        public MaterialRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(Material material)
        {
            _context.Set<Material>().Add(material);
        }
    }
}
