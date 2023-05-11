using System;
using System.Collections.Generic;

namespace Sale.Entities.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public string SupplierName { get; set; } = null!;
        public int SupplierId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
