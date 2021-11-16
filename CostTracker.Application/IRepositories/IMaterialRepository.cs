using CostTracker.Domain.Models;

namespace CostTracker.Application.IRepositories
{
    public interface IMaterialRepository
    {
        void Add(Material material);
    }
}
