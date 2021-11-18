using System;
using System.Collections.Generic;

namespace CostTracker.Application.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int SupplierId { get; set; }
        public ICollection<InvoiceMaterialModel> Materials { get; set; }
    }
}
