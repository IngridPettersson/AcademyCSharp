using EmployeesMvcApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models
{
    public class EmployeeService
    {
        List<Employee> employees = new List<Employee>();
        static int employeeCounter = 1;
        IContentService contentService;
        public EmployeeService(IContentService contentService)
        {
            this.contentService = contentService;
        }

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

        public Employee GetEmployeeById(int id)
        {
            return employees
                .Where(o => o.Id == id)
                .Single();
        }

        public AboutVM GetAbout()
        {
            return new AboutVM
            {
                Header = contentService.GetHeader(),
                Body = contentService.GetBody(),
                EmployeeNames = GetAllEmployees()
                .Select(o => o.Name)
                .ToArray()
            };
        }
    }
}
