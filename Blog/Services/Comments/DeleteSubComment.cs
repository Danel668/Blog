using Blog.Data;
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
    public class DeleteSubComment
    {
        private ISubCommentManager _subCommentManager;
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public DeleteSubComment(ISubCommentManager subCommentManager, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _subCommentManager = subCommentManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Do(int id)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            var subComment = _subCommentManager.GetSubCommentById(id);

            if (user.Id != subComment.UserId)
            {
                return false;
            }

            await _subCommentManager.DeleteSubComment(id);
            return true;
        }
    }
}
