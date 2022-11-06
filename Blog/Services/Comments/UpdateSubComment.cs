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
    public class UpdateSubComment
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private ISubCommentManager _subCommentManager;

        public UpdateSubComment(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ISubCommentManager subCommentManager)
        {
            _subCommentManager = subCommentManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Do(UpdateSubCommentViewModel updateSubCommentViewModel)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            var subComment = _subCommentManager.GetSubCommentById(updateSubCommentViewModel.Id);

            if (user.Id != subComment.UserId)
                return false;

            subComment.Created = DateTime.Now;
            subComment.Message = updateSubCommentViewModel.Message;
            subComment.Image = updateSubCommentViewModel.Image;

            await _subCommentManager.UpdateSubComment(subComment);
            return true;
        }

        public class UpdateSubCommentViewModel
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public string Image { get; set; }
        }
    }
}
