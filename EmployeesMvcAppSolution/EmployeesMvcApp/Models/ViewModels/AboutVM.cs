using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models.ViewModels
{
    public class AboutVM
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string[] EmployeeNames { get; set; }
    }
}
