using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models
{
    public class EmployeeService
    {
        static List<Employee> employees = new List<Employee>();
        static int employeeCounter = 1;

        public void AddEmployee(Employee employee)
        {
            employee.Id = employeeCounter++;
            employees.Add(employee);
        }

        public Employee[] GetAllEmployees()
        {
            return employees
                .ToArray();
        }
    }
}
