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
        public bool TryRegister(AccountRegisterVM viewModel)
        {
            // Todo: Try to create a new user
            return false;
        }

        public bool TryLoginAsync(AccountLoginVM viewModel)
        {
            // Todo: Try to sign user
            return true;
        }
    }
}
