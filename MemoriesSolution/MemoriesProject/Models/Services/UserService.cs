using MemoriesProject.Models.Entities;
using MemoriesProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.Services
{
    public class UserService
    {
        MyContext context;

        UserManager<MyIdentityUser> userManager;
        SignInManager<MyIdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public UserService(
        UserManager<MyIdentityUser> userManager,
        SignInManager<MyIdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        MyContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;

        }

        internal Task CreateUser(UserCreateAccountVM viewModel)
        {
            context.Users
                .AddAsync(new User
                {
                    Username = viewModel.UsernameChoice,
                    Password = viewModel.PasswordChoice
                });

            context.SaveChanges();
            return Task.CompletedTask;
        }

        internal void LoginSuccess(UserLoginVM viewModel)
        {


            var user = context.Users
                .Where(o => o.Username == viewModel.Username && o.Password == viewModel.Password)
                .SingleOrDefault();

            bool existingAccount = user != null;

            if (!existingAccount)
                throw new Exception();
                


                //.Contains(o => o.Username == viewModel.Username && o.Password == viewModel.Password);




        }
    }
}
