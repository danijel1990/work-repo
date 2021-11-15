using CostTracker.Application.Models;
using CostTracker.Domain;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Services.Interfaces
{
    public interface IMaterialService
    {
        Material Insert(MaterialModel materialModel);
    }
}
