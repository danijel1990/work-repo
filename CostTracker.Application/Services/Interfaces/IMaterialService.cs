using CostTracker.Application.Models;
using System.Collections.Generic;

namespace CostTracker.Application.Services.Interfaces
{
    public interface IMaterialService
    {
        int InsertMaterial(MaterialModel materialModel);
        void UpdateMaterial(int id, MaterialModel materialModel);
        IEnumerable<MaterialModel> GetMaterialData();
    }
}
