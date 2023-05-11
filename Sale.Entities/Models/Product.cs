using System;
using System.Collections.Generic;

namespace Sale.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string ProductName { get; set; } = null!;
        public int ProductId { get; set; }
        public string? ProductSupplier { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
