using IdentityDemo.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDemo.Models
{
    public class AccountService
    {
        UserManager<MyIdentityUser> userManager;
        SignInManager<MyIdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountService(
        UserManager<MyIdentityUser> userManager,
        SignInManager<MyIdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<bool> TryRegisterAsync(AccountRegisterVM viewModel)
        {
            // Todo: Try to create a new user
            //Finns UserManager, RoleManager, SignIn manager
            //Identity vill att vi anv deras klasser (ovan) som i sin tur jobbar mot context

            var result = await userManager.CreateAsync(
                new MyIdentityUser { UserName = viewModel.Username }, viewModel.Password);

            return result.Succeeded;
        }

        public async Task<bool> TryLoginAsync(AccountLoginVM viewModel)
        {
            // Todo: Try to sign user

            var result = await signInManager.PasswordSignInAsync(
                viewModel.Username,
                viewModel.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            return result.Succeeded;
        }

        internal async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
