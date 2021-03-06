using System;
using System.Collections.Generic;
using System.Text;

namespace CostTracker.Application.Models
{
    public class InvoiceQueryModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<InvoiceMaterialQueryModel> Materials { get; set; }
    }
}
