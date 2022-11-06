using Blog.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.UserAuthorize
{
    [Service]
    public class Register
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public Register(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Do(RegisterViewModel request)
        {
            var user = new User
            {
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return false;
            }
            await _signInManager.SignInAsync(user, false);
            return true;
        }

        public class RegisterViewModel
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
