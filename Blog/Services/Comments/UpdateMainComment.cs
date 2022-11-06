using Blog.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Models.Comments;
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
    public class UpdateMainComment
    {
        private IMainCommentManager _mainCommentManager;
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public UpdateMainComment(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMainCommentManager mainCommentManager)
        {
            _mainCommentManager = mainCommentManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Do(UpdateMainCommentViewModel updateMainCommentViewModel)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            var mainComment = _mainCommentManager.GetMainCommentById(updateMainCommentViewModel.Id);

            if (user.Id != mainComment.UserId)
                return false;

            mainComment.Created = DateTime.Now;
            mainComment.Message = updateMainCommentViewModel.Message;
            mainComment.Image = updateMainCommentViewModel.Image;

            await _mainCommentManager.UpdateMainComment(mainComment);
            return true;
        }

        public class UpdateMainCommentViewModel
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public string Image { get; set; } 
        }
    }
}
