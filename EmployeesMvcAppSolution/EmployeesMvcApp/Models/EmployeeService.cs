using EmployeesMvcApp.Models.Entities;
using EmployeesMvcApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models
{
    public class EmployeeService
    {
        //List<Employee> employees = new List<Employee>();
        //static int employeeCounter = 1;
        IContentService contentService;
        private readonly MyContext context;

        public EmployeeService(IContentService contentService, MyContext context)
        {
            this.contentService = contentService;
            this.context = context;
        }

        public void AddEmployee(EmployeeCreateVM viewModel)
        {
            //employee.Id = employeeCounter++;
            context.Employees.Add(new Employee
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                //CompanyId = viewModel.CompanyId
            });

            context.SaveChanges();
        }

        public EmployeeIndexVM[] GetAllEmployees()
        {
            return context.Employees.Select(x => new EmployeeIndexVM
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                ShowAsHighlighted = x.Email.ToLower().StartsWith("admin"),
                CompanyName = x.Company != null ? x.Company.Name : "N/A"
            })
                .ToArray();
        }

        public Employee GetEmployeeById(int id)
        {
            return context
                .Employees
                .Find(id);
        }

        //public AboutVM GetAbout()
        //{
        //    return new AboutVM
        //    {
        //        Header = contentService.GetHeader(),
        //        Body = contentService.GetBody(),
        //        EmployeeNames = GetAllEmployees()
        //        .Select(o => o.Name)
        //        .ToArray()
        //    };
        //}
    }
}
