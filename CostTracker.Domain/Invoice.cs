using System;
using System.Collections.Generic;

namespace CostTracker.Domain
{
    public class Invoice:BaseEntity
    {
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<InvoiceMaterial> InvoiceMaterials { get; set; }
    }
}
