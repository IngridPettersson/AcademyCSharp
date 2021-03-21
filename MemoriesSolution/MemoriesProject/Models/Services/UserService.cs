using MemoriesProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.Services
{
    public class UserService
    {
        MyContext context;

        public UserService(MyContext context)
        {
            this.context = context;
        }
    }
}
