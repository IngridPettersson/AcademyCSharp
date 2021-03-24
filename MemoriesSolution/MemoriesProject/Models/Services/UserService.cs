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

        internal Task CreateUser(UserCreateAccountVM viewModel)
        {

            context.Users
                .Add(new User
                {
                    Username = viewModel.UsernameChoice,
                    Password = viewModel.PasswordChoice
                });

            context.SaveChanges();
            return Task.CompletedTask;
        }

        internal Task LoginSuccess(UserLoginVM viewModel)
        {
            context.Users
                .Where(o => o.Username == viewModel.Username && o.Password == viewModel.Password)
                .Single();

            return Task.CompletedTask;
        }
    }
}
