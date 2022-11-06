using Blog.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.UserAuthorize
{
    [Service]
    public class Logout
    {
        private SignInManager<User> _signInManager;
        public Logout(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Do()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
