using MemoriesProject.Models.Entities;
using MemoriesProject.Models.ViewModels;
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

        internal Task AddUserLogin(UserLoginVM loginVM)
        {
            context.Users
                .Add(new User
                {
                    Username = loginVM.Username,
                    Password = loginVM.Password
                });

            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
