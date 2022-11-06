using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Posts
{
    [Service]
    public class DeleteYourPostById
    {
        private UserManager<User> _userManager;
        private IPostManager _postManager;
        private IHttpContextAccessor _httpContextAccessor;

        public DeleteYourPostById(IHttpContextAccessor httpContextAccessor, IPostManager postManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _postManager = postManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Do(int id)
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (await _postManager.DeleteYourPostById(id, user.Id))
                return true;

            return false;
        }
    }
}
