using Blog.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.AdminFunctionality
{
    [Service]
    public class AdminUpdatePost
    {
        private IPostManager _postManager;

        public AdminUpdatePost(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public async Task<bool> Do(PostViewModel post)
        {
            var bdPost = _postManager.GetPostById(post.Id);

            if (bdPost == null)
                return false;

            bdPost.Created = post.Created;
            bdPost.Description = post.Description;
            bdPost.Category = post.Category;
            bdPost.Body = post.Body;
            bdPost.Tags = post.Tags;
            bdPost.Title = post.Title;
            bdPost.Image = post.Image;

            await _postManager.UpdatePost(bdPost);
            return true;
        }

        public class PostViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; } 
            public string Image { get; set; }
            public string Body { get; set; } 
            public string Description { get; set; } 
            public string Tags { get; set; } 
            public string Category { get; set; } 
            public DateTime Created { get; set; } 
        }
    }
}
