using System;
using System.Collections.Generic;

namespace Sale.Entities.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public DateOnly InvoiceDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
