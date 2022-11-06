using Blog.Domain.Models.Comments;
using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Blog.Services.Posts
{
    [Service]
    public class UpdatePost
    {
        private UserManager<User> _userManager;
        private IPostManager _postManager;
        private IHttpContextAccessor _httpContextAccessor;

        public UpdatePost(IHttpContextAccessor httpContextAccessor, IPostManager postManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _postManager = postManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Do(UpdatePostViewModel updatePostViewModel)
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var post = _postManager.GetPostById(updatePostViewModel.Id);
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (post.UserId != user.Id)
            {
                return false;
            }

            post.Title = updatePostViewModel.Title;
            post.Image = updatePostViewModel.Image;
            post.Body = updatePostViewModel.Body;
            post.Description = updatePostViewModel.Description;
            post.Tags = updatePostViewModel.Tags;
            post.Created = DateTime.Now;
            post.Category = updatePostViewModel.Category;

            await _postManager.UpdatePost(post);
            return true;
        }

        public class UpdatePostViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; } 
            public string Image { get; set; } 
            public string Body { get; set; } 
            public string Description { get; set; } 
            public string Tags { get; set; } 
            public string Category { get; set; } 
        }
    }
}
