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

namespace Blog.Services.Posts
{
    [Service]
    public class GetAllYourPostsWithComments
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private IPostManager _postManager;

        public GetAllYourPostsWithComments(IPostManager postManager, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _postManager = postManager;
        }

        public async Task<IEnumerable<GetAllYourPostsWithCommentsViewModel>> Do()
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            return _postManager.GetAllPostsWithComments().Where(x => x.UserId == user.Id).Select(x => new GetAllYourPostsWithCommentsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                Body = x.Body,
                Description = x.Description,
                Category = x.Category,
                Created = x.Created,
                CountOfLike = x.CountOfLike,
                CountOfComments = x.CountOfComments,
                InFavorites = x.InFavorites,
                MainComments = x.MainComments.Select(y => new MainCommentViewModel
                {
                    Message = y.Message,
                    Created = y.Created,
                    CountOfLike = y.CountOfLike,
                    Image = y.Image,
                    SubComments = y.SubComments.Select(z => new SubCommentViewModel
                    {
                        Message = z.Message,
                        CountOfLike = z.CountOfLike,
                        Created = z.Created,
                        Image = z.Image
                    }).ToList()
                }).ToList()
            });
        }

        public class GetAllYourPostsWithCommentsViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Image { get; set; }
            public string Body { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Created { get; set; }
            public int CountOfLike { get; set; }
            public bool InFavorites { get; set; }
            public int CountOfComments { get; set; }
            public List<MainCommentViewModel> MainComments { get; set; }

        }

        public class MainCommentViewModel
        {
            public string Message { get; set; }
            public DateTime Created { get; set; }
            public int CountOfLike { get; set; } 
            public string Image { get; set; }
            public List<SubCommentViewModel> SubComments { get; set; }
        }

        public class SubCommentViewModel
        {
            public string Message { get; set; }
            public DateTime Created { get; set; }
            public int CountOfLike { get; set; } 
            public string Image { get; set; } 
        }
    }
}
