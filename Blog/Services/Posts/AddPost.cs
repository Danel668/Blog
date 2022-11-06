using Blog.Domain.Models.Comments;
using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Blog.Domain.Interfaces;
using Blog.Data;
using Microsoft.AspNetCore.Identity;

namespace Blog.Services.Posts
{
    [Service]
    public class AddPost
    {
        private UserManager<User> _userManager;
        private IPostManager _postManager;
        private IHttpContextAccessor _httpContextAccessor;

        public AddPost(IHttpContextAccessor httpContextAccessor, IPostManager postManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _postManager = postManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Do(AddPostViewModel addPostViewModel)
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            
            var post = new Post()
            {
                UserId = user.Id,
                Title = addPostViewModel.Title,
                Image = addPostViewModel.Image,
                Body = addPostViewModel.Body,
                Description = addPostViewModel.Description,
                Tags = addPostViewModel.Tags,
                Category = addPostViewModel.Category,
            };
            await _postManager.AddPost(post);
            return true;
        }

        public class AddPostViewModel
        {
            public string Title { get; set; } = "";
            public string Image { get; set; } = "";
            public string Body { get; set; } = "";
            public string Description { get; set; } = "";
            public string Tags { get; set; } = "";
            public string Category { get; set; } = "";
        }
    }
}
