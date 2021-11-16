using CostTracker.Application.Models;
using CostTracker.Domain;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Services.Interfaces
{
    public interface IMaterialService
    {
        int InsertMaterial(MaterialModel materialModel);
        int UpdateMaterial(MaterialModel materialModel);
        Material GetMaterialData(MaterialModel materialModel);
    }
}
