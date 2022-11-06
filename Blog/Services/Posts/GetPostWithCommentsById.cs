using Blog.Data;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blog.Services.Posts.GetAllYourPostsWithComments;

namespace Blog.Services.Posts
{
    [Service]
    public class GetPostWithCommentsById
    {
        private IPostManager _postManager;

        public GetPostWithCommentsById(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public GetPostWithCommentsByIdViewModel Do(int id)
        {
            var post = _postManager.GetPostWithCommentsById(id);
            if (post == null)
                return null;

            return new GetPostWithCommentsByIdViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Image = post.Image,
                Body = post.Image,
                Description = post.Description,
                Category = post.Description,
                Created = post.Created,
                CountOfComments = post.CountOfComments,
                CountOfLike = post.CountOfLike,
                InFavorites = post.InFavorites,
                MainComments = post.MainComments.Select(x => new MainCommentViewModel
                {
                    Message = x.Message,
                    Created = x.Created,
                    CountOfLike = x.CountOfLike,
                    Image = x.Image,
                    SubComments = x.SubComments.Select(y => new SubCommentViewModel
                    {
                        Message = y.Message,
                        Created = y.Created,
                        CountOfLike = y.CountOfLike,
                        Image = y.Image

                    }).ToList()
                }).ToList()
            };
        }

        public class GetPostWithCommentsByIdViewModel
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
