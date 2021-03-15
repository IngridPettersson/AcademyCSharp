using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesMvcApp.Models
{
    public class ReleaseContentService : IContentService
    {
        public string GetHeader()
        {
            return "Release header";
        }

        public string GetBody()
        {
            return "Realease body";
        }
    }
}
