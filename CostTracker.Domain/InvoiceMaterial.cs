namespace CostTracker.Domain
{
    public class InvoiceMaterial
    {
        public int InvoiceId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }

        public Invoice Invoice { get; set; }
        public Material Material { get; set; }
    }
}
