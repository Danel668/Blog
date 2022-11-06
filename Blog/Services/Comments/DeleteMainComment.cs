using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Comments
{
    [Service]
    public class DeleteMainComment
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private IMainCommentManager _mainCommentManager;

        public DeleteMainComment(IMainCommentManager mainCommentManager, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mainCommentManager = mainCommentManager;
        }


        public async Task<bool> Do(int id)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            var mainComment = _mainCommentManager.GetMainCommentById(id);

            if (user.Id != mainComment.UserId)
            {
                return false;
            }

            await _mainCommentManager.DeleteMainComment(id);
            return true;
        }
    }
}
