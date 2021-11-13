using System;
using System.Collections.Generic;

namespace CostTracker.Application.Models
{
    public class InvoiceQueryModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string SupplierName { get; set; }
        public IEnumerable<InvoiceMaterialQueryModel> Materials { get; set; }
    }
}
