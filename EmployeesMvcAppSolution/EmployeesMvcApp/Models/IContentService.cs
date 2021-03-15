using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models
{
    public interface IContentService
    {
        string GetHeader();
        string GetBody();
    }
}
