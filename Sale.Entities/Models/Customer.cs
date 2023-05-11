using System;
using System.Collections.Generic;

namespace Sale.Entities.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string CustomerName { get; set; } = null!;
        public int CustomerId { get; set; }
        public int? CustomerPhone { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
