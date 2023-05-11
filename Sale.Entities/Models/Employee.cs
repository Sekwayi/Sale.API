using System;
using System.Collections.Generic;

namespace Sale.Entities.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Invoices = new HashSet<Invoice>();
        }
        public string EmployeeName { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
