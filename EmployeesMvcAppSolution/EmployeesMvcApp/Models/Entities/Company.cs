using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeesMvcApp.Models.Entities
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
