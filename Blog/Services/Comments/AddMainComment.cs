using Blog.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models.Comments;
using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Blog.Services.Comments
{
    [Service]
    public class AddMainComment
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private IMainCommentManager _mainCommentManager;

        public AddMainComment(IMainCommentManager mainCommentManager, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mainCommentManager = mainCommentManager;
        }

        public async Task<bool> Do(MainCommentViewModel mainCommentViewModel)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            var mainComment = new MainComment
            {
                Message = mainCommentViewModel.Message,
                Image = mainCommentViewModel.Image,
                PostId = mainCommentViewModel.PostId,
                UserId = user.Id,
            };
            await _mainCommentManager.AddMainComment(mainComment);
            return true;
        }

        public class MainCommentViewModel
        {
            public string Message { get; set; }
            public string Image { get; set; } 
            public int PostId { get; set; }
        }
    }
}
