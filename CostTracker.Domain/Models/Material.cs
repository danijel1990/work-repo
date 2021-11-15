namespace CostTracker.Domain.Models
{
    public class Material : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
