using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models
{
    public class DevContentService : IContentService
    {
        public string GetHeader()
        {
            return "Dev header";
        }

        public string GetBody()
        {
            return "Dev body";
        }
    }
}
