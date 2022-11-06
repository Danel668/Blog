using Blog.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Models.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Blog.Services.Comments
{
    [Service]
    public class AddSubComment
    {
        private ISubCommentManager _subCommentManager;
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public AddSubComment(ISubCommentManager subCommentManager, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _subCommentManager = subCommentManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Do(SubCommentViewModel subCommentViewModel)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            var subComment = new SubComment
            {
                Message = subCommentViewModel.Message,
                Image = subCommentViewModel.Image,
                MainCommentId = subCommentViewModel.MainCommentId,
                UserId = user.Id
            };
            await _subCommentManager.AddSubComment(subComment);
            return true;
        }

        public class SubCommentViewModel
        {
            public string Message { get; set; }
            public string Image { get; set; }
            public int MainCommentId { get; set; }
        }
    }
}
